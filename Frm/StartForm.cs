using System;
using System.Net;
using System.Windows.Forms;
using CampingReservation.Frm.Reservation;
using CampingReservation.Frm.Strawberry;
using CampingReservation.Manager;

namespace CampingReservation.Frm
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();

            ServicePointManager.DefaultConnectionLimit = 200;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ChukRongReservation().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new JungrangReservation().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new YoungInReservation().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new GangDongReservation().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new WorldCupParkReservation().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new ReservationCheck().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new ZaraSeum().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new Hantan().Show();
        }

        private void btnSearchReservation_Click(object sender, EventArgs e)
        {
            var manager = new ClientManager();
            for (int i = 0; i < 100; i++)
            {
                string shopName = manager.GetShop(i.ToString("0000"), "0001");
                if (shopName != null)
                {
                    txtShopList.AppendText(shopName + "\r\n");
                }
            }
        }

        private void btnReservationCancel_Click(object sender, EventArgs e)
        {
            new ReservationCancel().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Yeunin().Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new Yain().Show();
        }
    }
}