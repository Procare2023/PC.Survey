using Microsoft.Extensions.DependencyInjection;
using PC.AccessLayer.Models;
using PC.AccessLayer.Services.IServices;
using PC.AccessLayer.Utility.Check;
using PC.DataLayer.DbContexts;
using PC.DataLayer.Enum;
using PC.DataLayer.Model.Survey;
using PC.DataLayer.Oracle;
using PC.Repository.SurveyUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PC.AccessLayer.Survey
{
    public class SurveyManager
    {
        #region Sending SMS using this class        
        public readonly ISendService _sendSmsService;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ISurveyUnitofWork _unitOfWork;
        public SurveyManager(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            var scope = _serviceScopeFactory.CreateScope();
            _unitOfWork = scope.ServiceProvider.GetRequiredService<ISurveyUnitofWork>();
            _sendSmsService = scope.ServiceProvider.GetRequiredService<ISendService>();
        }

        public async void ProcessSurveyAppointmentsSms(DateTime? appointmentDate, string externalUrlBaseLink,
            int apptMonthOffset)
        {
            Check.Argument.IsNotEmptyOrWhitespace(externalUrlBaseLink, "externalUrlBaseLink");
            Check.Argument.IsNotNegative(apptMonthOffset, "apptMonthOffset");

            try
            {
                // Get all appointments which are candidates for the general survey.
                // This is basically all appointments of the previous day which.
                var oasisDb = new PCOasisWrapperDb();
                var yesterday = DateTime.Today.AddDays(-1);
                //check if appointmentDate has a value this is prod otherwise it's testing
                if (appointmentDate.HasValue)
                    yesterday = appointmentDate.Value;

                // First, get all appointments for that specific date from oracle db view V_APPOINTMENT_DUMP.
                var appts = await oasisDb.GetAppointmentsByDay(yesterday.ToString());

                if (appts == null || appts.Count == 0)
                    return;

                apptMonthOffset = apptMonthOffset * -1;

                // Next, loop through each appointment and check that they have not been already
                // surveyed for the past n months.
                await CreateAndSaveAppt(apptMonthOffset, yesterday, appts);

                var unsent = await _unitOfWork.GeneralSurveyReport.FindAllAsync(criteria: q => q.SurveyStatus == SurveyStatus.Unsent, null);
                //_context.GeneralSurveyReport.Where(q => q.SurveyStatus == SurveyStatus.Unsent).ToList();

                if (unsent == null || unsent.ToList().Count < 0)
                    return;

                await SendSmsAndUpdateDatabaseAsync(externalUrlBaseLink, unsent);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task SendSmsAndUpdateDatabaseAsync(string externalUrlBaseLink, IEnumerable<GeneralSurveyReport> unsent)
        {
            int count = 0;
            foreach (var record in unsent)
            {
                try
                {
                    // Get the first name for this person.
                    var firstName = Regex.Replace(record.PatientName.Split()[0], @"[^0-9a-zA-Z\ ]+", "");
                    var urlToShorten = string.Format("{0}?i={1}%26k={2}%26lang=ar", externalUrlBaseLink, record.ApptId.ToString(), record.CreateStamp.Value.Ticks.ToString());

                    // Create the model for this.
                    var generalSurveyModel = new GeneralSurveyModel();
                    generalSurveyModel.Name = firstName;
                    generalSurveyModel.Link = urlToShorten;

                    // Construct the SMS message for this record.
                    // Then queue it to be sent off.
                    //GeneralSurveySMSNotifier.SendSurveyOursms(MessageManager.C_SOURCE_GeneralSurvey, Language.English, record.Mobile, generalSurveyModel, ALBConstants.C_SYSTEM_USER_ID);
                    SurveyModelDto model = FillDto(record, firstName, urlToShorten);
                    var response = await _sendSmsService.SendSmsAsync<ResponseDto>(model);
                    if (response != null && response.IsSuccess)
                    {
                        // Once done, mark as sent.
                        //genSvyDb.UpdateToSent(record.ApptCopyGenSurveyId.Value, urlToShorten, shortenedLink, ALBConstants.C_SYSTEM_USER_ID);
                        record.SurveyStatus = SurveyStatus.Sent;
                        record.UpdateStamp = DateTime.Now;
                        _unitOfWork.GeneralSurveyReport.Update(record);
                        //_context.GeneralSurveyReport.Update(record);
                        //await _context.SaveChangesAsync();
                        count++;
                        Thread.Sleep(10000);
                    }
                }
                catch (Exception unsentException)
                {
                    //FileTrace.WriteLine("XXX SurveyManager XXX inner exception (unsentException) found: " + unsentException.Message);
                    //FileTrace.WriteException(unsentException);
                }
            }
            try
            {
                var sendEmail = await _sendSmsService.SendEmailAsync<ResponseDto>(count);
            }
            catch (Exception)
            {
            }


        }

        private static SurveyModelDto FillDto(GeneralSurveyReport record, string firstName, string shortenedLink)
        {
            return new SurveyModelDto()
            {
                Link = shortenedLink,
                Name = firstName,
                Mobile = record.Mobile,
                Source = "PCSurvey"
            };
        }

        private async Task CreateAndSaveAppt(int apptMonthOffset, DateTime yesterday, List<DataLayer.Model.Patient.Appointment.v_appointment_dump> appts)
        {
            var startDate = yesterday.AddMonths(apptMonthOffset);

            foreach (var a in appts)
            {
                try
                {
                    // Only interested in Checked-In appointments.
                    //if (a.AppointmentStatus != AppointmentStatus.CheckedIn)
                    //    continue;
                    if (a.time_complete == null)
                        continue;

                    if (string.IsNullOrWhiteSpace(a.mobile))
                        continue;

                    //var surveyed = await _unitOfWork.GeneralSurveyReport.FindAllAsync(criteria: q => q.MRN == a.mrn_no && a.Session_Date.Month > startDate.Month && a.Session_Date < yesterday, null);
                    //if (surveyed == null || surveyed.ToList().Count < 0)
                    //{
                    // Patient has not been surveyed in the past, so insert the record.
                    var ac = new GeneralSurveyReport();
                    ac.ApptId = a.appointment_id;
                    ac.ApptNo = a.appointment_id.ToString();
                    ac.ApptDate = a.appt_time;
                    ac.AppointmentStatus = AppointmentStatus.Closed;
                    ac.MRN = a.mrn_no;
                    ac.PatientName = a.NAME;
                    ac.BirthDate = null;
                    ac.Mobile = a.mobile;
                    ac.Doctor = a.doctor_name;
                    ac.Specialty = "";
                    ac.SurveyStatus = SurveyStatus.Unsent;
                    ac.CreateStamp = DateTime.Now;

                    await _unitOfWork.GeneralSurveyReport.AddAsync(ac);
                    //await _context.SaveChangesAsync();
                    //}
                }
                catch (Exception apptFetchException)
                {
                    //FileTrace.WriteLine("XXX SurveyManager XXX inner exception (apptFetchException) found: " + apptFetchException.Message);
                    //FileTrace.WriteException(apptFetchException);
                }
            }
        }
        #endregion


        //public async void TestSave()
        //{
        //    var test = new Test()
        //    {
        //        Name = "test"
        //    };


        //    await _unitOfWork.Test.AddAsync(test);
        //}
    }
}
