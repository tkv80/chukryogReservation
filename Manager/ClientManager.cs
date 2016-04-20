using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CampingReservation.Entity;
using CampingReservation.Util;

namespace CampingReservation.Manager
{
    internal class ClientManager
    {
        private readonly List<ClientInfo> _clients = new List<ClientInfo>();

        public ClientManager()
        {
            _clients.Add(new ClientInfo
            {
                CompanyCode = ((int) ReservationType.중랑가족캠핑숲).ToString("0000"),
            });

            _clients.Add(new ClientInfo
            {
                CompanyCode = ((int) ReservationType.강동그린웨이).ToString("0000"),
            });

            _clients.Add(new ClientInfo
            {
                CompanyCode = ((int) ReservationType.노을캠핑장).ToString("0000"),
            });

            _clients.Add(new ClientInfo
            {
                CompanyCode = ((int) ReservationType.용인자연휴양림).ToString("0000"),
            });
        }

        public ClientInfo GetClient(ReservationType type, string id, string pwd)
        {
            string member;

            if (type == ReservationType.한탄강)
            {
                string[] array = id.Split('|');
                if (array.Length != 2)
                {
                    MessageBox.Show(@"아이디|이름 형태로 넣어주세요");
                    return null;
                }

                member = SoapManager.Instance.GetUnMemberCode("0007", array[1], array[0]);
                member = member.Split('|')[2];
                member = SoapManager.Instance.GetMember("0007", member);
            }
            else
            {
                var parameter = new StringBuilder();
                parameter.AppendLine(
                    "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:s=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");

                parameter.AppendLine("    <SOAP-ENV:Body>");
                parameter.AppendLine("        <tns:GetMemberLogin xmlns:tns=\"http://tempuri.org/\">");
                parameter.AppendLine(string.Format("        <tns:companyCode>{0}</tns:companyCode>",
                    ((int) type).ToString("0000")));
                parameter.AppendLine(string.Format("        <tns:loginId>{0}</tns:loginId>", id));
                parameter.AppendLine(string.Format("        <tns:LoginPassword>{0}</tns:LoginPassword>", pwd));
                parameter.AppendLine("        </tns:GetMemberLogin>");
                parameter.AppendLine("    </SOAP-ENV:Body>");

                parameter.AppendLine("</SOAP-ENV:Envelope>");

                string data = SoapClient.GetSoapData(parameter.ToString());

                if (data.IndexOf("<MemberCode>") > 0)
                {
                    string memberCode = data.Substring(data.IndexOf("<MemberCode>") + 12,
                        data.IndexOf("</MemberCode>") - data.IndexOf("<MemberCode>") - 12);

                    member = SoapManager.Instance.GetMember(((int) type).ToString("0000"), memberCode);
                }
                else
                {
                    return null;
                }
            }

            string[] memberInfos = member.Split('|');

            var clientInfo = new ClientInfo
            {
                MemberCode = memberInfos[0],
                CustomerName = memberInfos[1],
                CustomerMobileNo = memberInfos[4],
                CustomerTelephoneNo = memberInfos[5],
                CustomerSsn = memberInfos[7],
                CustomerEMail = memberInfos[6],
                CustomerId = memberInfos[15],
                CompanyCode = ((int) type).ToString("0000")
            };
            if (type == ReservationType.연인산) clientInfo.ShopCode = "0002";
            
            return clientInfo;
        }

        public string GetShop(string companyCode, string shopCode)
        {
            var parameter = new StringBuilder();
            parameter.AppendLine(
                "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:s=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");

            parameter.AppendLine("    <SOAP-ENV:Body>");
            parameter.AppendLine("        <tns:GetBaseData xmlns:tns=\"http://tempuri.org/\">");
            parameter.AppendLine(string.Format("        <tns:companyCode>{0}</tns:companyCode>", companyCode));
            parameter.AppendLine(string.Format("        <tns:shopCode>{0}</tns:shopCode>", shopCode));
            parameter.AppendLine("        </tns:GetBaseData>");
            parameter.AppendLine("    </SOAP-ENV:Body>");

            parameter.AppendLine("</SOAP-ENV:Envelope>");

            string data = SoapClient.GetSoapData(parameter.ToString());

            if (data.IndexOf("<ShopName>") > 0)
            {
                string shopName = data.Substring(data.IndexOf("<ShopName>") + 10,
                    data.IndexOf("</ShopName>") - data.IndexOf("<ShopName>") - 10);

                return shopName + "-" + companyCode;
                //member = SoapManager.Instance.GetMember(((int)type).ToString("0000"), memberCode);
            }
            return null;
        }
    }
}