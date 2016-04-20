// *
// * @author  모바일 기술팀 KTG
// * @date    2013년 9월 6일 금요일 오전 10:49:28
// *

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CampingReservation.Entity;
using CampingReservation.Manager;
using CampingReservation.ServiceReference1;
using CampingReservation.Worker;

namespace CampingReservation.Frm
{
    public partial class BaseReservation : Form
    {
        #region field

        protected  ClientInfo _client = new ClientInfo();
        private bool _isRunReservation;
        private ReservationType _reservationType = ReservationType.중랑가족캠핑숲;

        private List<SiteEntity> _sites = new List<SiteEntity>();

        protected ReservationType Place
        {
            set { _reservationType = value; }
        }

        #endregion

        /// <summary>
        ///     ctor
        /// </summary>
        public BaseReservation()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     폼로드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseReservation_Load(object sender, EventArgs e)
        {
            _sites = new SiteEntityManager().Sites(_reservationType);
            comboBox1.DataSource = _sites;
            comboBox1.DisplayMember = "SiteName";
            comboBox1.ValueMember = "SiteCode";

            dateTimePicker2.Value = DateTime.Now.AddDays(1);
            _work.ProgressChanged += work_ProgressChanged;
            _work.RunWorkerCompleted += work_RunWorkerCompleted;

            gbSetting.Enabled = false;
            btnReserve.Enabled = false;
            Text = _reservationType.ToString();
        }

        #region worker

        private readonly SoapBackgroundWorker _work = new SoapBackgroundWorker();

        /// <summary>
        ///     예약 완료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void work_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                _isRunReservation = !_isRunReservation;
                btnReserve.Text = @"예약걸기";
                gbSetting.Enabled = true;
            }
        }

        /// <summary>
        ///     진행
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void work_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (_work.IsSuccess)
            {
                lbSuccessMessage.Text = e.UserState.ToString();
                _work.IsSuccess = false;
            }

            if (txtLog.Lines.Count() <= 150)
            {
                txtLog.AppendText(e.UserState.ToString());
            }
            else
            {
                txtLog.Clear();
                txtLog.AppendText(e.UserState.ToString());
            }
        }

        #endregion

        #region form event

        /// <summary>
        ///     예약걸기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (!_isRunReservation)
            {
                _work.BookingRequest = new BookingByGroupNewRequestBody
                {
                    companyCode = _client.CompanyCode,
                    shopCode = _client.ShopCode,
                    customerName = _client.CustomerName,
                    customerSSN = _client.CustomerSsn,
                    customerTelephoneNo = _client.CustomerTelephoneNo,
                    customerMobileNo = _client.CustomerMobileNo,
                    customerEMail = _client.CustomerEMail,
                    paymentLimitHour = 48,
                    terminalCode = "98",
                    userId = "web",
                    memberYn = "1",
                    memberCode = _client.MemberCode,
                    memberKindCode = "",
                    discountValue = "0",
                    saleKindCode = "230001",
                    productCode = null,
                    startDate = dateTimePicker1.Value.ToString("yyyyMMdd"),
                    endDate = dateTimePicker2.Value.AddDays(-1).ToString("yyyyMMdd"),
                    optionYn = (_reservationType == ReservationType.중랑가족캠핑숲) ? "1" : "0",
                    cancelLimitDays = 1,
                    cancelLimitHour = 24,
                    nearLimitDays = 6,
                    nearPaymentLimitHour = 6,
                    accountKind = "0",
                    ProductOption = "0",
                    MemberId = _client.CustomerId
                };

                var selectedSite = new List<SiteEntity>();

                if (chbAll.Checked)
                {
                    selectedSite = _sites;

                    if (chbMainSite.Checked)
                    {
                        selectedSite = _sites.Where(t => t.SiteName.Contains("명당")).ToList();
                    }

                    if (txtFilter.Text != "")
                    {
                        selectedSite = selectedSite.Where(t => t.SiteName.Contains(txtFilter.Text)).ToList();
                    }
                }
                else
                {
                    selectedSite.Add(new SiteEntity
                    {
                        SiteCode = comboBox1.SelectedValue.ToString(),
                        SiteName = ((SiteEntity) comboBox1.SelectedItem).SiteName,
                        Type = _reservationType
                    });
                }

                _work.Interval = Convert.ToInt16(udDelay.Value);
                _work.Sites = selectedSite;

                _work.RunWorkerAsync();

                _isRunReservation = !_isRunReservation;
                btnReserve.Text = @"예약취소";
                gbSetting.Enabled = false;
            }
            else
            {
                _work.CancelAsync();
                _work.IsSuccess = true;

                _isRunReservation = !_isRunReservation;
                btnReserve.Text = @"예약걸기";
                gbSetting.Enabled = true;
            }
        }


        /// <summary>
        ///     멤버정보 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetMemberInfo_Click(object sender, EventArgs e)
        {
            //000720121009000007

            _client = new ClientManager().GetClient(_reservationType, txtID.Text, txtPwd.Text);

            if (_client != null)
            {
                _client = SoapManager.GetClient(_client);

                lbMemberInfo.Text = _client.ToString();

                gbSetting.Enabled = true;
                btnReserve.Enabled = true;
            }
            else
            {
                MessageBox.Show(@"등록되지 않은 아이디 입니다.");
            }
        }

        /// <summary>
        ///     날짜변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
        }

        /// <summary>
        ///     사이트 전체 선택
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbAll_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = !chbAll.Checked;
        }

        #endregion
    }
}