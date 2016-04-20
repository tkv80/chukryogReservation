// *
// * @author  모바일 기술팀 KTG
// * @date    2013년 9월 6일 금요일 오전 11:49:38
// *

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using CampingReservation.Entity;
using CampingReservation.Manager;
using CampingReservation.ServiceReference1;
using CampingReservation.Util;

namespace CampingReservation.Worker
{
    internal class SoapBackgroundWorker : BackgroundWorker
    {
        public bool IsSuccess;

        public SoapBackgroundWorker()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        public BookingByGroupNewRequestBody BookingRequest { get; set; }

        public List<SiteEntity> Sites { get; set; }

        public int Interval { get; set; }


        protected override void OnDoWork(DoWorkEventArgs e)
        {
            while (!CancellationPending)
            {
                try
                {
                    XDocument doc =
                        XDocument.Load(
                            string.Format(
                                "http://strawberry.mainticket.co.kr/C2Soft.Earth.Web.Service/CampingPublicKey{0}.xml",
                                (int) DateTime.Now.DayOfWeek + 1), LoadOptions.None);

                    var rsa = new RsaCrypto();
                    var rsaEntity = rsa.GenerateKey(doc.ToString(), false);

                    var input = DateTime.Now.ToString("yyyyMMdd") + BookingRequest.memberCode +
                                   DateTime.Now.ToString("HHmmss");
                    var ss = rsa.RsaEncrypt(input, rsaEntity);

                    //ss = "BgAwZOF3yopDLtsU5rHEidcN0W5GQDOo0He4Ick0gd4ivJwTCGfVzGY+GZHcALvlla/L6XsXZc7MM+1tut9S4pXGm9GVPakLJZ81cWRFKWx+IkxEUP6Ddg+oxcy38UG5w1E7SvJ2boLxchv1MR6L2yeyjf5BmBcNIqtVRvsO08Q=";
                    foreach (var site in Sites)
                    {
                        string message;
                        try
                        {
                            if (CancellationPending)
                            {
                                CancelAsync();
                                break;
                            }

                            string response = SoapManager.Instance.BookingByGroupNew(
                                BookingRequest.companyCode,
                                BookingRequest.shopCode,
                                BookingRequest.customerName,
                                BookingRequest.customerSSN,
                                BookingRequest.customerTelephoneNo,
                                BookingRequest.customerMobileNo,
                                BookingRequest.customerEMail,
                                BookingRequest.paymentLimitHour,
                                BookingRequest.terminalCode,
                                BookingRequest.userId,
                                BookingRequest.memberYn,
                                BookingRequest.memberCode,
                                BookingRequest.memberKindCode,
                                BookingRequest.discountValue,
                                BookingRequest.saleKindCode,
                                site.SiteCode,
                                BookingRequest.startDate,
                                BookingRequest.endDate,
                                BookingRequest.optionYn,
                                BookingRequest.cancelLimitDays,
                                BookingRequest.cancelLimitHour,
                                BookingRequest.nearLimitDays,
                                BookingRequest.nearPaymentLimitHour,
                                BookingRequest.accountKind,
                                BookingRequest.ProductOption,
                                FromJulian(),
                                ss,
                                BookingRequest.MemberId
                                );

                            if (response.Contains("true|NO ERROR"))
                            {
                                message = string.Format("{1}일 {2}사이트 {3} - {0}\r\n",
                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                    BookingRequest.startDate,
                                    site.SiteName,
                                    site.Type
                                    );
                                IsSuccess = true;

                                new GcmManager().SendNotification(message, "캠핑예약");

                                CancelAsync();
                            }
                            else
                            {
                                message = string.Format("{0} - 실패 {1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                    site.SiteName);
                            }
                        }
                        catch (WebException webExcp)
                        {
                            var sr = new StreamReader(webExcp.Response.GetResponseStream(),
                                Encoding.GetEncoding("euc-kr"));
                            message = string.Format("{0} - 에러 {1} {2}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                site.SiteName, sr.ReadToEnd());
                        }
                        catch (Exception ex)
                        {
                            message = string.Format("{0} - 에러 {1} {2}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                site.SiteName, ex.Message);
                        }

                        ReportProgress(0, message);

                        Thread.Sleep(1000);
                    }

                    Thread.Sleep(Interval*1000);
                }
                catch (Exception ex)
                {
                    ReportProgress(0, ex.Message);
                }
            }
        }

        private static string FromJulian()
        {
            return (DateTime.Now.Year.ToString().Substring(2, 2) + "0"+ DateTime.Now.DayOfYear).ToString(CultureInfo.InvariantCulture);
            //DateTime.Now.DayOfYear;
            /*
            var yy = DateTime.Now.ToString("yy");
            var yymm = DateTime.Now.ToString("yyyy");
            var yymmdd = DateTime.Now.ToString("yyyyMMdd");

            var a7 = 1000*60*60*24;
            var a8 = 1000*60*60;
            var a9 = 1000*60;

            var a10 = 
            */
        }
    }
}