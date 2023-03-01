using PC.AccessLayer.Models;

namespace PC.AccessLayer.Services.IServices;

public interface ISendService : IBaseService
{
    public T SendSmsAsync<T>(SurveyModelDto surveyModel);
    public T SendEmailAsync<T>(int smsCount);
}

