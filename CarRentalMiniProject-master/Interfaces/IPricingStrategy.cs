using CarRentalMiniProject.Models;

namespace CarRentalMiniProject.Interfaces
{
    public interface IPricingStrategy
    {
        string Name { get; }
        decimal CalculateDiscount(Customer customer, Vehicle vehicle, int rentalDays, decimal baseTotal);
    }
}
