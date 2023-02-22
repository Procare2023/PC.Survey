//using Mango.Services.CouponAPI.Models.Dto;
//using Mango.Services.CouponAPI.Respository;
using Microsoft.AspNetCore.Mvc;
using PC.Services.Sms.Models.Dto;
using PC.Services.Sms.Repository;
using RazorEngine.Templating;
using RazorLight;
using System.Reflection;

namespace PC.Services.Sms
{
    [Route("api/Email")]
    public class EmailController : Controller
    {
        //private readonly ICouponRepository _couponRepository;
        protected ResponseDto _response;
        protected readonly IConfiguration _config;
        private readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly ISendEmail _sendEmail;

        public EmailController(IConfiguration config, IWebHostEnvironment webHostEnvironment, ISendEmail sendEmail)
        {
            this._response = new ResponseDto();
            _config = config;
            _webHostEnvironment = webHostEnvironment;
            _sendEmail = sendEmail;
        }

        [HttpGet("SendEmail/{smsCount}")]
        public async Task<object> SendEmail(int smsCount)
        {
            try
            {
                //send Email
                string userEmail = null;
                //if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                userEmail = "ahmed.mohamed@procare.com.sa";
                //userEmail = "mussab87@gmail.com";
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                    userEmail = "mussab87@gmail.com";// "ahmed.mohamed@procare.com.sa"; //"mussab87@gmail.com";

                //get user logged in url
                //var Userurl = HttpContext.Request.GetEncodedUrl();
                //var url = Userurl.Split("/").ToList();
                //var sendUrl = url[0] + "//" + url[2];
                //sendUrl = sendUrl + "test link";

                string messageBody = "<font><h2>Patients Survey SMS Notification has been completed </h2></font><br />" +

                "<br /> " + smsCount.ToString() + " SMS";

                //send email here
                EmailInfo emailInfo = new EmailInfo();
                emailInfo.From = _config.GetValue<string>("AppSetting:FromEmail");
                emailInfo.SmtpCredentials = _config.GetValue<string>("AppSetting:SmtpCredentials");
                emailInfo.To = userEmail;
                emailInfo.Subject = _config.GetValue<string>("AppSetting:Subject");
                emailInfo.SmtpClient = _config.GetValue<string>("AppSetting:SmtpClient");
                emailInfo.SmtpPort = _config.GetValue<int>("AppSetting:SmtpPort");
                emailInfo.UseDefaultCredentials = _config.GetValue<bool>("AppSetting:UseDefaultCredentials");
                emailInfo.EnableSsl = _config.GetValue<bool>("AppSetting:EnableSsl");
                emailInfo.messageBody = messageBody;

                var result = await _sendEmail.SendEmail(emailInfo);

                if (result)
                    _response.IsSuccess = true;
                else
                    _response.IsSuccess = false;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
