using PC.AccessLayer.Models;

namespace PC.AccessLayer.Services.IServices;

public class SendService : BaseService, ISendService
{
    public readonly IHttpClientFactory _clientFactory;
    public SendService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<T> SendEmailAsync<T>(int smsCount)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.SendSmsAPIBase + "/api/Email/SendEmail/" + smsCount
        });
    }

    public async Task<T> SendSmsAsync<T>(SurveyModelDto surveyModelDto)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = surveyModelDto,
            Url = SD.SendSmsAPIBase + "/api/sendsms"
        });
    }
}

