﻿//using Mango.Services.CouponAPI.Models.Dto;
//using Mango.Services.CouponAPI.Respository;
using Microsoft.AspNetCore.Mvc;
using PC.Services.Sms.Models.Dto;
using RazorEngine.Templating;
using RazorLight;
using System.Reflection;

namespace PC.Services.Sms
{
    [Route("api/sendsms")]
    public class SendSmsController : Controller
    {
        //private readonly ICouponRepository _couponRepository;
        protected ResponseDto _response;
        protected readonly IConfiguration _config;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SendSmsController(IConfiguration config, IWebHostEnvironment webHostEnvironment)
        {
            this._response = new ResponseDto();
            _config = config;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] SurveyModelDto surveytDto)
        {
            try
            {
                //send sms
                var baseAddress = new Uri("https://api.unifonic.com/rest/");
                var appSid = _config.GetValue<string>("AppSetting:AppSid");

                string SMScontent = string.Empty;
                string responseData = String.Empty;
                string templateFolderPath = Path.Combine(_webHostEnvironment.ContentRootPath, @"SMSTemplate\SMSGeneralSurveyEn.cshtml");


                var template = System.IO.File.ReadAllText(templateFolderPath);
                RazorLightEngine engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(Assembly.GetEntryAssembly())
                .Build();

                SMScontent = await engine.CompileRenderStringAsync(
                   "SMSTemplate",  // cache key
                   template,
                 surveytDto);
                using (var httpClient = new HttpClient { BaseAddress = baseAddress })
                {
                    using (var content = new StringContent("AppSid=" + appSid + "& Recipient=" + surveytDto.Mobile + "&Body=" + SMScontent, System.Text.Encoding.Default, "application/x-www-form-urlencoded"))
                    {
                        using (var response = await httpClient.PostAsync("Messages/Send", content))
                        {
                            responseData = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
                if (responseData != null)
                {
                    responseData = responseData.Replace("\"", string.Empty);
                    responseData.Replace("{", string.Empty);
                    responseData.Replace("}", string.Empty);
                    _response.Result = surveytDto;

                    if (responseData.Split(",")[0].Split(":")[0] == "{success")
                        _response.IsSuccess = true;
                    else
                        _response.IsSuccess = false;
                }
                else
                {
                    _response.Result = surveytDto;
                    _response.IsSuccess = false;
                }
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