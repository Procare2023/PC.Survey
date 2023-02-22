using PC.Services.Sms.Models.Dto;
using System.Net.Mail;

namespace PC.Services.Sms.Repository
{
    public class SendEmail : ISendEmail
    {
        async Task<bool> ISendEmail.SendEmail(EmailInfo email)
        {
            try
            {
                MailMessage Email = new MailMessage();
                //SmtpClient client = new SmtpClient(emailInfo.SmtpClient);
                Email.To.Add(email.To);
                //mail.To.Add("Secondry@gmail.com");
                Email.From = new MailAddress(email.From);
                Email.Subject = email.Subject;
                Email.Body = email.messageBody;
                Email.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(email.SmtpClient, email.SmtpPort);
                // smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.UseDefaultCredentials = email.UseDefaultCredentials;
                smtp.EnableSsl = email.EnableSsl;
                smtp.Credentials = new System.Net.NetworkCredential(email.From, email.SmtpCredentials);
                // smtp.Port = 587;
                //Or your Smtp Email ID and Password
                await smtp.SendMailAsync(Email);

                return Task.CompletedTask.IsCompleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
