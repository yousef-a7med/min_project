namespace CarRentalMiniProject.Services
{
    public class BookingCalculator
    {
        public decimal PriceTotal(decimal dailyPrice, int rentalDays)
        {
            if (rentalDays <= 0)
                throw new ArgumentException("Rental days must be greater than zero.");

            return dailyPrice * rentalDays;
        }
    }
}
