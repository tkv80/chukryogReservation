namespace CampingReservation.Entity
{
    public class ClientInfo
    {
        public string ShopCode = "0001";
        public string CompanyCode = "0013";

        public string CustomerEMail = "tkv80@naver.com";
        public string CustomerId = "tkv1980";
        public string CustomerMobileNo = "010-8226-7979";
        public string CustomerName = "김태권";
        public string CustomerSsn = "";
        public string CustomerTelephoneNo = "9999--";
        public string MemberCode = "001320130905000034";

        public override string ToString()
        {
            return string.Format("코드 : {3}\n\r이름 : {0}\n\r전화번호 : {1}\n\r이메일 : {2}", CustomerName, CustomerMobileNo,
                CustomerEMail, MemberCode);
        }
    }
}