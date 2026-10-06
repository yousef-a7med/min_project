using CarRentalMiniProject.Interfaces;
using CarRentalMiniProject.Models;

namespace CarRentalMiniProject.Services
{
    public class RentalService
    {
        private readonly IRentalRepository repository;
        private readonly INotificationService notificationService;
        private readonly IRentalManager rentalManager;
        private readonly IPricingService pricingService;

        public RentalService(
            IRentalRepository repository,
            INotificationService notificationService,
            IRentalManager rentalManager,
            IPricingService pricingService)
        {
            this.repository = repository;
            this.notificationService = notificationService;
            this.rentalManager = rentalManager;
            this.pricingService = pricingService;
        }

        public RentalBooking RentVehicle(Customer customer, Vehicle vehicle, int rentalDays)
        {
            RentalBooking booking = rentalManager.CreateBooking(
                customer, vehicle, rentalDays);

            if (booking == null)
            {
                notificationService.SendNotification("Vehicle is not available.");
                return null;
            }

            decimal discount = pricingService.CalculateDiscount(
                customer, vehicle, rentalDays, booking.BaseTotal, out string strategyName);

            booking.DiscountAmount = discount;
            booking.FinalTotal = booking.BaseTotal - discount;

            repository.AddBooking(booking);

            Invoice invoice = new Invoice
            {
                InvoiceId = repository.GetAllInvoices().Count + 1,
                BookingId = booking.BookingId,
                CustomerName = customer.Name,
                Amount = booking.FinalTotal,
                CreatedAt = DateTime.Now
            };

            repository.AddInvoice(invoice);

            repository.AddLog(new LogEntry
            {
                LogId = repository.GetAllLogs().Count + 1,
                Message = $"Booking #{booking.BookingId} created using {strategyName}.",
                CreatedAt = DateTime.Now
            });

            notificationService.SendNotification(
                $"Booking created successfully! Discount: {discount:0.00}");

            return booking;
        }

        public void ShowAllBookings()
        {
            List<RentalBooking> bookings = repository.GetAllBookings();

            if (bookings.Count == 0)
            {
                notificationService.SendNotification("No bookings found :(");
                return;
            }

            foreach (RentalBooking booking in bookings)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine($"Booking ID: {booking.BookingId}");
                Console.WriteLine($"Customer: {booking.Customer.Name}");
                Console.WriteLine($"Vehicle: {booking.Car.Brand} ({booking.Car.GetVehicleType()})");
                Console.WriteLine($"Rental Days: {booking.RentalDays}");
                Console.WriteLine($"Base Total: {booking.BaseTotal:0.00}");
                Console.WriteLine($"Discount: {booking.DiscountAmount:0.00}");
                Console.WriteLine($"Final Total: {booking.FinalTotal:0.00}");
                Console.WriteLine("------------------------------");
            }
        }

        public void ShowInvoices()
        {
            Console.WriteLine("\n===== INVOICES =====");
            foreach (Invoice invoice in repository.GetAllInvoices())
            {
                Console.WriteLine(
                    $"Invoice #{invoice.InvoiceId} | Booking #{invoice.BookingId} | " +
                    $"Customer: {invoice.CustomerName} | Amount: {invoice.Amount:0.00} | " +
                    $"Date: {invoice.CreatedAt}");
            }
        }

        public void ShowLogs()
        {
            Console.WriteLine("\n===== LOGS =====");
            foreach (LogEntry log in repository.GetAllLogs())
                Console.WriteLine($"#{log.LogId} | {log.CreatedAt} | {log.Message}");
        }
    }
}
