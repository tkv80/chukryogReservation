using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using CampingReservation.Entity;
using CampingReservation.Manager;
using CampingReservation.Util;

namespace CampingReservation.Frm.Reservation
{
    public partial class ReservationCheck : Form
    {
        public ReservationCheck()
        {
            InitializeComponent();

            comboBox1.DataSource = Enum.GetNames(typeof (ReservationType)).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == ReservationType.축령산자연휴양림.ToString())
            {
                const ReservationType type = ReservationType.중랑가족캠핑숲;
                ClientInfo client = new ClientManager().GetClient(type, txtId.Text, txtPwd.Text);

                if (client == null)
                {
                    MessageBox.Show(@"등록되지 않은 아이디 입니다.");
                    return;
                }

                string sURL = "https://chukryong.gg.go.kr:456/new2006/appointment/rsv_check_list.asp";
                string parameter = "rsv_check=R&idx={0}&tel_1={1}&tel_2={2}&tel_3={3}&cus_mail={4}";
                string[] phone = client.CustomerMobileNo.Split('-');

                sURL = string.Format(sURL, comboBox1.SelectedValue);
                parameter = string.Format(parameter,
                    HttpUtility.UrlEncode(client.CustomerName, Encoding.GetEncoding("euc-kr")),
                    phone[0],
                    phone[1],
                    phone[2],
                    client.CustomerEMail);


                var httpWRequest = (HttpWebRequest) WebRequest.Create(sURL);
                httpWRequest.Accept = "text/html, application/xhtml+xml";
                httpWRequest.Referer = "https://chukryong.gg.go.kr:456/new2006/appointment/rsv_check.asp";
                httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
                httpWRequest.Headers.Add("Accept-Language", "ko-KR");
                httpWRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                httpWRequest.Host = "chukryong.gg.go.kr:456";
                httpWRequest.ContentType = "application/x-www-form-urlencoded";
                httpWRequest.KeepAlive = true;
                httpWRequest.Method = "Post";
                httpWRequest.ContentLength = parameter.Length;
                httpWRequest.CookieContainer = new CookieContainer();
                httpWRequest.CookieContainer.Add(new Cookie("__utma",
                    "206204609.1877502704.1378257147.1378257147.1378257148.2", "/", "chukryong.gg.go.kr"));
                httpWRequest.CookieContainer.Add(new Cookie("__utmb", "206204609.45.10.1378257148", "/",
                    "chukryong.gg.go.kr"));
                httpWRequest.CookieContainer.Add(new Cookie("__utmz",
                    "06204609.1378257148.2.2.utmcsr=naver|utmccn=(organic)|utmcmd=organic|utmctr=%EC%B6%95%EB%A0%B9%EC%82%B0%EC%9E%90%EC%97%B0%ED%9C%B4%EC%96%91%EB%A6%BC",
                    "/", "chukryong.gg.go.kr"));
                httpWRequest.CookieContainer.Add(new Cookie("ASPSESSIONIDQAQTDRRQ", "LLNMHHBCJNPNGFELHMAHHJBF", "/",
                    "chukryong.gg.go.kr"));
                httpWRequest.CookieContainer.Add(new Cookie("__utmc", "206204609", "/", "chukryong.gg.go.kr"));

                var sw = new StreamWriter(httpWRequest.GetRequestStream());
                sw.Write(parameter);
                sw.Close();

                var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
                var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

                string data = sr.ReadToEnd();

                if (
                    data.Contains(
                        "<table width=\"100%\" border=\"0\" cellpadding=\"5\" cellspacing=\"1\" bgcolor=\"cccccc\">"))
                {
                    data =
                        data.Substring(
                            data.IndexOf(
                                "<table width=\"100%\" border=\"0\" cellpadding=\"5\" cellspacing=\"1\" bgcolor=\"cccccc\">") +
                            "<table width=\"100%\" border=\"0\" cellpadding=\"5\" cellspacing=\"1\" bgcolor=\"cccccc\">"
                                .Length,
                            data.IndexOf("</table>",
                                data.IndexOf(
                                    "<table width=\"100%\" border=\"0\" cellpadding=\"5\" cellspacing=\"1\" bgcolor=\"cccccc\">")) -
                            data.IndexOf(
                                "<table width=\"100%\" border=\"0\" cellpadding=\"5\" cellspacing=\"1\" bgcolor=\"cccccc\">") -
                            "<table width=\"100%\" border=\"0\" cellpadding=\"5\" cellspacing=\"1\" bgcolor=\"cccccc\">"
                                .Length
                            );
                    data = data.Replace("\r\n", "");
                    data = data.Replace("<tr>", "\r\n");
                    data = Regex.Replace(data, @"<(.|\n)*?>", string.Empty);

                    data = data.Replace("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t    \r\n", "");
                    data = data.Replace("취소    \r\n", "");
                    data = data.Replace("    ", "\t");
                    data = data.Replace("\r\n\t", "\r\n");
                    data = data.Replace("\t\t", "\t");
                    data = data.Replace("\t", "\t\t");
                    data = data.Replace("\r\n예약번호", "");


                    richTextBox1.Text = data;
                    string[] lines = richTextBox1.Lines;
                    richTextBox1.Clear();
                    lines[0] = "예약번호\t시설명\t\t\t\t사용일\t\t\t입금액\t\t예약자\t\t예약구분";
                    //lines[1] = "";
                    richTextBox1.Lines = lines;
                }
            }
            else
            {
                GetCommonReservation();
            }
        }

        private void GetCommonReservation()
        {
            var type = (ReservationType) Enum.Parse(typeof (ReservationType), comboBox1.Text);
            ClientInfo client = new ClientManager().GetClient(type, txtId.Text, txtPwd.Text);

            if (client == null)
            {
                MessageBox.Show("등록되지 않은 아이디 입니다.");
                return;
            }

            var parameter = new StringBuilder();
            parameter.AppendLine(
                "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:s=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
            parameter.AppendLine("    <SOAP-ENV:Body>");
            parameter.AppendLine("        <tns:GetMyPage xmlns:tns=\"http://tempuri.org/\">");
            parameter.AppendLine(string.Format("        <tns:companyCode>{0}</tns:companyCode>", client.CompanyCode));
            parameter.AppendLine(string.Format("        <tns:shopCode>{0}</tns:shopCode>", client.ShopCode));
            parameter.AppendLine(string.Format("        <tns:memberCode>{0}</tns:memberCode>", client.MemberCode));
            parameter.AppendLine("        </tns:GetMyPage>");
            parameter.AppendLine("    </SOAP-ENV:Body>");
            parameter.AppendLine("</SOAP-ENV:Envelope>");


            string data = SoapClient.GetSoapData(parameter.ToString());

            data = data.Replace("<anyType xsi:type=\"MyPage\">", "|");
            string[] reservationStrings = data.Split('|');

            var sb = new StringBuilder();
            foreach (string reservationString in reservationStrings)
            {
                string garbage = "";
                if (reservationString.Contains("ProductCode"))
                {
                    if (reservationString.Contains("ProductCode /"))
                    {
                        garbage = "취소";
                    }
                    else
                    {
                        garbage = "예약";
                    }

                    int startDate =
                        Convert.ToInt32(reservationString.Substring(reservationString.IndexOf("StartDate>") + 10, 8));
                    sb.Append(startDate.ToString("0000-00-00"));
                    sb.Append(" ~ ");
                    int endDate =
                        Convert.ToInt32(reservationString.Substring(reservationString.IndexOf("EndDate>") + 8, 8));
                    sb.Append(endDate.ToString("0000-00-00"));

                    sb.Append(" |  " + garbage);

                    sb.Append("  |  자리 : ");
                    sb.Append(reservationString.Substring(reservationString.IndexOf("ProductName>") + 12,
                        reservationString.IndexOf("</ProductName>") - reservationString.IndexOf("ProductName>") - 12));


                    if (garbage == "예약")
                    {
                        if (!reservationString.Contains("<DepositStatus>0<"))
                        {
                            sb.Append("  |  결재완료");
                        }
                        else
                        {
                            sb.Append("  |  결재안됨  |  ");

                            Int64 paymentDate =
                                Convert.ToInt64(
                                    reservationString.Substring(
                                        reservationString.IndexOf("PaymentLimitDatetime>") + 21, 12));
                            sb.Append(paymentDate.ToString("0000-00-00 00:00"));
                            sb.Append("까지 결재");
                        }
                    }

                    if (reservationString.Contains("<BookNo>"))
                    {
                        sb.Append(" |  code :  ");
                        sb.Append(reservationString.Substring(reservationString.IndexOf("<BookNo>") + 8, 11));
                        //14051600052
                    }

                    if (reservationString.Contains("<ProductCode>"))
                    {
                        sb.Append(",");
                        sb.Append(reservationString.Substring(reservationString.IndexOf("<ProductCode>") + 13, 8));
                    }

                    sb.AppendLine();
                }
            }

            richTextBox1.Text = sb.ToString();
        }
    }
}