namespace PC.Services.Sms.Loger
{
    public class ServiceLogger
    {
        public static void WriteToFile(string text)
        {
            try
            {
                string path = @"C:\Temp\APIServiceLog.txt";
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(string.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
                    writer.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
