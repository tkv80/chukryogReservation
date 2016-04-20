using CampingReservation.Entity;
using CampingReservation.ServiceReference1;

namespace CampingReservation.Manager
{
    internal static class SoapManager
    {
        private static readonly FlexServiceSoapClient Service = new FlexServiceSoapClient();

        public static FlexServiceSoapClient Instance
        {
            get { return Service; }
        }

        /// <summary>
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static ClientInfo GetClient(ClientInfo client)
        {
            string member = Service.GetMember(client.CompanyCode, client.MemberCode);
            string[] memberInfos = member.Split('|');

            client.MemberCode = memberInfos[0];
            client.CustomerName = memberInfos[1];
            client.CustomerMobileNo = memberInfos[4];
            client.CustomerTelephoneNo = memberInfos[5];
            client.CustomerSsn = memberInfos[7];
            client.CustomerEMail = memberInfos[6];
            client.CustomerId = memberInfos[15];

            return client;
        }
    }
}