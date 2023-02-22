using PC.AccessLayer.Models;

namespace PC.AccessLayer.Services.IServices;

public interface ISendService : IBaseService
{
    public Task<T> SendSmsAsync<T>(SurveyModelDto surveyModel);
    public Task<T> SendEmailAsync<T>(int smsCount);
}

