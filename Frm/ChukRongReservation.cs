// *
// * @author  모바일 기술팀 KTG
// * @date    2013년 9월 5일 목요일 오전 10:11:39
// *

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Forms;
using CampingReservation.Entity;
using CampingReservation.Manager;

namespace CampingReservation.Frm
{
    public partial class ChukRongReservation : Form
    {
        private readonly Timer _timer = new Timer();
        private bool _isRunReservation;

        public ChukRongReservation()
        {
            InitializeComponent();

            comboBox1.DataSource = new SiteEntityManager().Sites(ReservationType.축령산자연휴양림);
            comboBox1.DisplayMember = "SiteName";
            comboBox1.ValueMember = "SiteCode";

            cbFacility.Items.Add(new Tuple<string, string>("숲속의집", "https://chukryong.gg.go.kr:456/new2006/appointment/reserve_list_check.asp"));
            cbFacility.Items.Add(new Tuple<string, string>("삼림휴양관", "https://chukryong.gg.go.kr:456/new2006/appointment/reserve_list_check_h.asp"));
            cbFacility.Items.Add(new Tuple<string, string>("야영데크", "https://chukryong.gg.go.kr:456/new2006/appointment/reserve_list_check_c.asp"));
            cbFacility.DisplayMember = "item1";
            cbFacility.ValueMember = "item2";

            dateTimePicker2.Value = DateTime.Now.AddDays(1);

            _timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DoReservation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UiSetting();
        }

        private void UiSetting()
        {
            if (!_isRunReservation)
            {
                DoReservation();

                _timer.Interval = Convert.ToInt16(txtDelay.Text)*1000;
                _timer.Start();

                _isRunReservation = !_isRunReservation;
                btnReserve.Text = @"예약취소";
            }
            else
            {
                _timer.Stop();
                _isRunReservation = !_isRunReservation;
                btnReserve.Text = @"예약걸기";
            }
        }


        private void DoReservation()
        {
            try
            {
                var sUrl =
                    "https://chukryong.gg.go.kr:456/new2006/appointment/reserve_write.asp?res_hu=A&res_si={0}&fdate=0";
                var parameter =
                    "res_name={0}&tel_1={1}&tel_2={2}&tel_3={3}&res_mail={4}&res_add={5}&res_qty=4&res_bank={6}&res_bankno={7}&res_bankname={8}&res_children=&money_chk=money&s_date={6}&e_date={7}&edd=0&t_money=4000";

                sUrl = string.Format(sUrl, comboBox1.SelectedValue);
                parameter = string.Format(parameter,
                    HttpUtility.UrlEncode(txtName.Text, Encoding.GetEncoding("euc-kr")),
                    txtTel1.Text,
                    txtTel2.Text,
                    txtTel3.Text,
                    txtMail.Text,
                    HttpUtility.UrlEncode(txtAddress.Text, Encoding.GetEncoding("euc-kr")),
                    dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                    dateTimePicker2.Value.ToString("yyyy-MM-dd"),
                    txtBankName.Text,
                    txtAccountNumber.Text);


                var httpWRequest = (HttpWebRequest) WebRequest.Create(sUrl);
                httpWRequest.Accept = "text/html, application/xhtml+xml";
                httpWRequest.Referer =
                    string.Format(
                        @"https://chukryong.gg.go.kr:456/new2006/appointment/reserve_rsv.asp?res_hu=A&res_si={0}&st_date={1}&ed_date={2}&su_date=0&su_qty=0",
                        comboBox1.SelectedValue,
                        dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                        dateTimePicker2.Value.ToString("yyyy-MM-dd"));
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

                if (data.Contains("예약이 완료되었습니다."))
                {
                    _isRunReservation = true;
                    UiSetting();

                    string message = string.Format("{0} - 예약완료~ {1}일 {2}사이트\r\n",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                        comboBox1.SelectedText);

                    txtLog.AppendText(message);

                    new GcmManager().SendNotification(message, "캠핑예약");
                }
                else
                {
                    string log = string.Format("{0} - 예약실패\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    txtLog.AppendText(log);
                }
            }
            catch (WebException webExcp)
            {
                var sr = new StreamReader(webExcp.Response.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

                string data = sr.ReadToEnd();
                MessageBox.Show(data);
            }
            catch (Exception ex) // get any other error
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
        }
    }
}