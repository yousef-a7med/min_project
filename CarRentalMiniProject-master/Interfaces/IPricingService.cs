using CarRentalMiniProject.Models;

namespace CarRentalMiniProject.Interfaces
{
    public interface IPricingService
    {
        decimal CalculateDiscount(Customer customer, Vehicle vehicle, int rentalDays, decimal baseTotal, out string strategyName);
    }
}
