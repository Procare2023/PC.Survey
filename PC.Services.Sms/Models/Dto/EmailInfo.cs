namespace PC.Services.Sms.Models.Dto
{
    public class EmailInfo
    {
        public string From { get; set; }
        public string SmtpCredentials { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string SmtpClient { get; set; }
        public int SmtpPort { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public bool EnableSsl { get; set; }
        public string messageBody { get; set; }
    }
}
