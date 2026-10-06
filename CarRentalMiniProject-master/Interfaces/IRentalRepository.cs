using CarRentalMiniProject.Models;

namespace CarRentalMiniProject.Interfaces
{
    public interface IRentalRepository
    {
        void AddCustomer(Customer customer);
        List<Customer> GetAllCustomers();

        void AddVehicle(Vehicle vehicle);
        List<Vehicle> GetAllVehicles();

        void AddBooking(RentalBooking booking);
        List<RentalBooking> GetAllBookings();

        void AddInvoice(Invoice invoice);
        List<Invoice> GetAllInvoices();

        void AddLog(LogEntry log);
        List<LogEntry> GetAllLogs();
    }
}
