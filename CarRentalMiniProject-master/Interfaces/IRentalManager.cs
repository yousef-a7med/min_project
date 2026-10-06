using CarRentalMiniProject.Models;

namespace CarRentalMiniProject.Interfaces
{
    public interface IRentalManager
    {
        RentalBooking CreateBooking(Customer customer, Vehicle car, int rentalDays);
    }
}
