using CarRentalMiniProject.Interfaces;
using CarRentalMiniProject.Models;

namespace CarRentalMiniProject.Services
{
    public class PricingService : IPricingService
    {
        private readonly List<IPricingStrategy> strategies;

        public PricingService(List<IPricingStrategy> strategies)
        {
            this.strategies = strategies;
        }

        public decimal CalculateDiscount(Customer customer, Vehicle vehicle,
            int rentalDays, decimal baseTotal, out string strategyName)
        {
            decimal bestDiscount = 0;
            strategyName = "No Discount";

            foreach (IPricingStrategy strategy in strategies)
            {
                decimal discount = strategy.CalculateDiscount(
                    customer, vehicle, rentalDays, baseTotal);

                if (discount > bestDiscount)
                {
                    bestDiscount = discount;
                    strategyName = strategy.Name;
                }
            }

            return bestDiscount;
        }
    }
}
