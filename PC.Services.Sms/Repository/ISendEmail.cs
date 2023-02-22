using PC.Services.Sms.Models.Dto;

namespace PC.Services.Sms.Repository
{
    public interface ISendEmail
    {
        public Task<bool> SendEmail(EmailInfo email);
    }
}
