using BitlyAPI;
using System.Net;
using System.Web;
using System.Xml;

namespace PC.Services.Sms.LinkShortner
{
    public class BitlyShortner
    {

        public static async Task<string> ShortenAsync(string url, string login, string key, bool xml)
        {
            var bitly = new Bitly(key);
            var linkResponse = await bitly.PostShorten(url);
            var newLink = linkResponse.Link;

            return newLink;

        }

        //        public static string Shorten(string url, string login, string key, bool xml)
        //        {
        //#pragma warning disable SYSLIB0013 // Type or member is obsolete
        //            url = Uri.EscapeUriString(url);
        //#pragma warning restore SYSLIB0013 // Type or member is obsolete
        //            string reqUri =
        //                String.Format("http://api.bit.ly/v3/shorten?" +
        //                "login={0}&apiKey={1}&format={2}&longUrl={3}",
        //                login, key, xml ? "xml" : "txt", url);

        //#pragma warning disable SYSLIB0014 // Type or member is obsolete
        //            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(reqUri);
        //#pragma warning restore SYSLIB0014 // Type or member is obsolete
        //            req.Timeout = 10000; // 10 seconds

        //            // if the function fails and format==txt throws an exception
        //            Stream stm = req.GetResponse().GetResponseStream();

        //            if (xml)
        //            {
        //                XmlDocument doc = new XmlDocument();
        //                doc.Load(stm);

        //                // error checking for xml
        //                if (doc["response"]["status_code"].InnerText != "200")
        //                    throw new WebException(doc["response"]["status_txt"].InnerText);

        //                return doc["response"]["data"]["url"].InnerText;
        //            }
        //            else // Text
        //                using (StreamReader reader = new StreamReader(stm))
        //                    return reader.ReadLine();
        //        }
    }
}
