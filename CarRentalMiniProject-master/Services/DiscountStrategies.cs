using CarRentalMiniProject.Interfaces;
using CarRentalMiniProject.Models;

namespace CarRentalMiniProject.Services
{
    public class WeeklyDiscount : IPricingStrategy
    {
        public string Name => "Weekly Discount";

        public decimal CalculateDiscount(Customer customer, Vehicle vehicle,
            int rentalDays, decimal baseTotal)
        {
            if (rentalDays >= 7)
                return baseTotal * 0.10m;

            return 0;
        }
    }

    public class VipDiscount : IPricingStrategy
    {
        public string Name => "VIP Discount";

        public decimal CalculateDiscount(Customer customer, Vehicle vehicle,
            int rentalDays, decimal baseTotal)
        {
            if (customer.Customer_Type == CustomerType.Vip1)
                return baseTotal * 0.15m;

            if (customer.Customer_Type == CustomerType.Vip2)
                return baseTotal * 0.10m;

            if (customer.Customer_Type == CustomerType.Vip3)
                return baseTotal * 0.05m;

            return 0;
        }
    }

    public class StudentDiscount : IPricingStrategy
    {
        public string Name => "Student Discount";

        public decimal CalculateDiscount(Customer customer, Vehicle vehicle,
            int rentalDays, decimal baseTotal)
        {
            if (customer.IsStudent)
                return baseTotal * 0.08m;

            return 0;
        }
    }
}
