using CampingReservation.Entity;

namespace CampingReservation.Frm.Strawberry
{
    public partial class Yeunin : BaseReservation
    {
        public Yeunin()
        {
            Place = ReservationType.연인산;
            _client.ShopCode = "0002";
            InitializeComponent();
        }
    }
}