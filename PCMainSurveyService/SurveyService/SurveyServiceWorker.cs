﻿using PC.AccessLayer.Services.IServices;
using PC.AccessLayer.Survey;
using PC.DataLayer.DbContexts;
using PC.Repository.SurveyUnitOfWork;

namespace PCMainSurveyService.SurveyService
{
    public class SurveyServiceWorker : BackgroundService
    {
        private readonly ILogger<SurveyServiceWorker> _logger;
        protected readonly IConfiguration _config;
        private Timer Schedular;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public SurveyServiceWorker(ILogger<SurveyServiceWorker> logger, IConfiguration config, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _config = config;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this.WriteToFile("Service started at: {0}" + DateTime.Now.ToString());
            while (!stoppingToken.IsCancellationRequested)
            {
                this.ScheduleService();
            }
            //_timer.Enabled = false;
        }

        public void ScheduleService()
        {
            try
            {
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
                Schedular = new Timer(new TimerCallback(SchedularCallback));
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

                DateTime scheduledTime = DateTime.MinValue;
                //Get the Scheduled Time from AppSettings.
                scheduledTime = DateTime.Parse(Convert.ToString(_config["Survey:TimeToRun"]));
                if (DateTime.Now.ToString() == scheduledTime.ToString())
                {
                    this.WriteToFile("Survey running at: {0}" + DateTimeOffset.Now);
                    _logger.LogInformation("Survey running at: {0}", DateTimeOffset.Now);

                    //run the process here
                    var baseLink = Convert.ToString(_config["Survey:SurveyLink"]);
                    var apptMonthOffset = 1;

                    SurveyManager surveyManager = new(_serviceScopeFactory);
                    surveyManager.ProcessSurveyAppointmentsSms(null, baseLink, apptMonthOffset);
                    //surveyManager.TestSave();
                    //If Scheduled Time is passed set Schedule for the next day.
                    scheduledTime = scheduledTime.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                WriteToFile("Simple Service Error on: {0} " + ex.Message + ex.StackTrace);
                _logger.LogInformation("Survey Worker Service Exception" + ex.ToString(), DateTimeOffset.Now);
                //Stop the Windows Service.
                //using (System.ServiceProcess.ServiceController serviceController = new System.ServiceProcess.ServiceController("Service"))
                //{
                //    serviceController.Stop();
                //}
            }
        }

        private void SchedularCallback(object e)
        {
            //this.WriteToFile("Service Log: {0}");
            this.ScheduleService();
        }

        private void WriteToFile(string text)
        {
            try
            {
                string path = @"C:\Temp\SurveyLog.txt";
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(string.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Survey Worker Service Exception - WriteToFile" + ex.ToString(), DateTimeOffset.Now);
            }

        }
    }
}

