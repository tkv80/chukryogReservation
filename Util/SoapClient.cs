using System.IO;
using System.Net;

namespace CampingReservation.Util
{
    internal static class SoapClient
    {
        /// <summary>
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static string GetSoapData(string parameter)
        {
            var httpWRequest =
                (HttpWebRequest)
                    WebRequest.Create("https://strawberry.mainticket.co.kr/C2Soft.Earth.Web.Service/FlexService.asmx");
            httpWRequest.Accept = "/*/";
            httpWRequest.Referer = "https://strawberry.mainticket.co.kr/strawberry/Strawberry.swf";
            httpWRequest.Headers.Add("x-flash-version", "11,8,800,94");
            httpWRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
            httpWRequest.Headers.Add("Accept-Language", "ko-KR");
            httpWRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            httpWRequest.ContentType = "text/xml; charset=utf-8";
            httpWRequest.KeepAlive = true;
            httpWRequest.Method = "Post";
            httpWRequest.ContentLength = parameter.Length;

            var sw = new StreamWriter(httpWRequest.GetRequestStream());
            sw.Write(parameter);
            sw.Close();

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream());

            return sr.ReadToEnd();
        }
    }
}