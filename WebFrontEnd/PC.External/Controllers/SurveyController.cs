using Microsoft.AspNetCore.Mvc;
using PC.DataLayer.Model.Survey;
using PC.External.Models;
using PC.Repository.SurveyUnitOfWork;
using System.Diagnostics;

namespace PC.External.Controllers
{
    public class SurveyController : Controller
    {
        public readonly ILogger<SurveyController> _logger;
        private readonly ISurveyUnitofWork _unitofWork;
        public SurveyController(ILogger<SurveyController> logger, ISurveyUnitofWork unitofWork)
        {
            _logger = logger;
            _unitofWork = unitofWork;
        }

        public async Task<IActionResult> PCSurvey(int? id)
        {
            try
            {
                //get patient record
                var patient = await _unitofWork.GeneralSurveyReport.GetByIdAsync((int)id);
                if (patient == null || patient.SurveyStatus == DataLayer.Enum.SurveyStatus.Answered || patient.SurveyStatus == DataLayer.Enum.SurveyStatus.Unsent)
                    return Redirect("https://procare.com.sa/");

                return View(patient);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("SurveyController - PCSurvey Exception" + ex.ToString(), DateTimeOffset.Now);
                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> SaveRecord(GeneralSurvey genenralSurvey)
        {
            try
            {
                var patient = await _unitofWork.GeneralSurveyReport.GetByIdAsync(genenralSurvey.ApptCopyGenSurveyId);
                FillGeneralSurvey(genenralSurvey, patient);

                _unitofWork.GeneralSurveyReport.Update(genenralSurvey);

                return Json("Done");
            }
            catch (Exception ex)
            {
                _logger.LogInformation("SurveyController - SaveRecord Exception" + ex.ToString(), DateTimeOffset.Now);
                return Json("error" + ex.ToString());
            }

        }

        private static void FillGeneralSurvey(GeneralSurvey genenralSurvey, GeneralSurvey patient)
        {
            try
            {
                genenralSurvey.ApptNo = patient.ApptNo;
                genenralSurvey.ApptDate = patient.ApptDate;
                genenralSurvey.AppointmentStatus = patient.AppointmentStatus;
                genenralSurvey.MRN = patient.MRN;
                genenralSurvey.PatientName = patient.PatientName;
                genenralSurvey.BirthDate = patient.BirthDate;
                genenralSurvey.Mobile = patient.Mobile;
                genenralSurvey.Doctor = patient.Doctor;
                genenralSurvey.Specialty = patient.Specialty;
                genenralSurvey.CreateStamp = patient.CreateStamp;

                genenralSurvey.SurveyStatus = DataLayer.Enum.SurveyStatus.Answered;
                genenralSurvey.UpdateStamp = DateTime.Now;
                genenralSurvey.RespondedDate = DateTime.Now;
            }
            catch (Exception ex)
            {

                //_logger.LogInformation("SurveyController - FillGeneralSurvey Exception" + ex.ToString(), DateTimeOffset.Now);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}