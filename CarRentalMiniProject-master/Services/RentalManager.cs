using CarRentalMiniProject.Interfaces;
using CarRentalMiniProject.Models;

namespace CarRentalMiniProject.Services
{
    public class RentalManager : IRentalManager
    {
        private readonly BookingCalculator calculator;
        private int nextBookingId = 1;

        public RentalManager(BookingCalculator calculator)
        {
            this.calculator = calculator;
        }

        public RentalBooking CreateBooking(Customer customer, Vehicle car, int rentalDays)
        {
            if (car.Status != VehicleStatus.Available)
                return null;

            decimal baseTotal = calculator.PriceTotal(car.Price, rentalDays);

            RentalBooking booking = new RentalBooking
            {
                BookingId = nextBookingId++,
                Customer = customer,
                Car = car,
                RentalDays = rentalDays,
                BaseTotal = baseTotal,
                DiscountAmount = 0,
                FinalTotal = baseTotal
            };

            car.Status = VehicleStatus.Rented;
            return booking;
        }
    }
}
