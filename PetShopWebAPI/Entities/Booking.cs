namespace PetShopWebAPI.Entities
{
    public class Booking
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public int ClientID { get; set; }
        public DateTime BookingDate { get; set; }
        public int Amount { get; set; }
        public DateTime BookingDateStop { get; set; }
        public string BookingNumber { get; set; }
        public string Status { get; set; }
    }
}
