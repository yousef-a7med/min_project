using CarRentalMiniProject.Interfaces;
using CarRentalMiniProject.Models;

namespace CarRentalMiniProject.Repositories
{
    public class InMemoryRentalRepository : IRentalRepository
    {
        private readonly List<Customer> customers = new();
        private readonly List<Vehicle> vehicles = new();
        private readonly List<RentalBooking> bookings = new();
        private readonly List<Invoice> invoices = new();
        private readonly List<LogEntry> logs = new();

        public void AddCustomer(Customer customer) => customers.Add(customer);
        public List<Customer> GetAllCustomers() => customers;

        public void AddVehicle(Vehicle vehicle) => vehicles.Add(vehicle);
        public List<Vehicle> GetAllVehicles() => vehicles;

        public void AddBooking(RentalBooking booking) => bookings.Add(booking);
        public List<RentalBooking> GetAllBookings() => bookings;

        public void AddInvoice(Invoice invoice) => invoices.Add(invoice);
        public List<Invoice> GetAllInvoices() => invoices;

        public void AddLog(LogEntry log) => logs.Add(log);
        public List<LogEntry> GetAllLogs() => logs;
    }
}
