using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CampingReservation.Entity;
using CampingReservation.Manager;
using CampingReservation.Util;

namespace CampingReservation.Frm.Reservation
{
    public partial class ReservationCancel : Form
    {
        private ReservationType _type = ReservationType.노을캠핑장;

        public ReservationCancel()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetNames(typeof (ReservationType)).Where(x => x != "0").ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _type = (ReservationType) Enum.Parse(typeof (ReservationType), comboBox1.Text);
            List<SiteEntity> sites = new SiteEntityManager().Sites(_type);
            comboBox2.DataSource = sites;
            comboBox2.DisplayMember = "SiteName";
            comboBox2.ValueMember = "SiteCode";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var parameter = new StringBuilder();
            parameter.AppendLine(
                "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:s=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
            parameter.AppendLine("    <SOAP-ENV:Body>");
            parameter.AppendLine("        <tns:LodgingRefundByWeb2  xmlns:tns=\"http://tempuri.org/\">");
            parameter.AppendLine(string.Format("        <tns:companyCode>{0}</tns:companyCode>",
                ((int) _type).ToString("0000")));
            parameter.AppendLine(string.Format("        <tns:shopCode>{0}</tns:shopCode>", "0001"));
            parameter.AppendLine(string.Format("        <tns:bookNo>{0}</tns:bookNo>", txtBookNo.Text));
            parameter.AppendLine(string.Format("        <tns:cancelAll>{0}</tns:cancelAll>", "true"));
            parameter.AppendLine(string.Format("        <tns:productCode>{0}</tns:productCode>", comboBox2.SelectedValue));
            parameter.AppendLine(string.Format("        <tns:playDate>{0}</tns:playDate>", txtDate.Text));
            parameter.AppendLine(string.Format("        <tns:playSequence>{0}</tns:playSequence>", 1));
            parameter.AppendLine(string.Format("        <tns:saleSequence>{0}</tns:saleSequence>", 1));
            parameter.AppendLine(string.Format("        <tns:uniqueNo>{0}</tns:uniqueNo>", ""));
            parameter.AppendLine("        </tns:LodgingRefundByWeb2 >");
            parameter.AppendLine("    </SOAP-ENV:Body>");
            parameter.AppendLine("</SOAP-ENV:Envelope>");


            SoapClient.GetSoapData(parameter.ToString());
        }
    }
}