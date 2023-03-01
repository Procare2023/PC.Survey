using PC.AccessLayer.Models;

namespace PC.AccessLayer.Services.IServices;

public class SendService : BaseService, ISendService
{
    public readonly IHttpClientFactory _clientFactory;
    public SendService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public T SendEmailAsync<T>(int smsCount)
    {
        return this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.SendSmsAPIBase + "/api/Email/SendEmail/" + smsCount
        });
    }

    public T SendSmsAsync<T>(SurveyModelDto surveyModelDto)
    {
        return this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = surveyModelDto,
            Url = SD.SendSmsAPIBase + "/api/sendsms"
        });
    }
}

