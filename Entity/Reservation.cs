using System.Xml.Serialization;

namespace CampingReservation.Entity
{
    [XmlRoot]
    public class Reservation
    {
        [XmlElement("BookNo")]
        public string BookNo { get; set; }

        [XmlElement("CustomerName")]
        public string CustomerName { get; set; }

        [XmlElement("GroupName")]
        public string GroupName { get; set; }

        [XmlElement("ProductName")]
        public string ProductName { get; set; }

        [XmlElement("StartDate")]
        public string StartDate { get; set; }

        [XmlElement("EndDate")]
        public string EndDate { get; set; }

        [XmlElement("BookStatus")]
        public string BookStatus { get; set; }

        [XmlElement("DepositStatus")]
        public string DepositStatus { get; set; }

        [XmlElement("BalanceAmount")]
        public string BalanceAmount { get; set; }
    }
}