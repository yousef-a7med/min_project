namespace CarRentalMiniProject.Models
{
    public class RentalBooking
    {
        public int BookingId { get; set; }
        public Customer Customer { get; set; }
        public Vehicle Car { get; set; }
        public int RentalDays { get; set; }
        public decimal BaseTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalTotal { get; set; }
    }
}
