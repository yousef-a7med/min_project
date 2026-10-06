using CarRentalMiniProject.Interfaces;
using CarRentalMiniProject.Models;
using CarRentalMiniProject.Repositories;
using CarRentalMiniProject.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        IRentalRepository repository = new InMemoryRentalRepository();
        INotificationService notificationService = new ConsoleNotificationService();

        BookingCalculator calculator = new BookingCalculator();
        IRentalManager rentalManager = new RentalManager(calculator);

        List<IPricingStrategy> strategies = new List<IPricingStrategy>
        {
            new WeeklyDiscount(),
            new VipDiscount(),
            new StudentDiscount()
        };

        IPricingService pricingService = new PricingService(strategies);

        RentalService rentalService = new RentalService(
            repository,
            notificationService,
            rentalManager,
            pricingService);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("       CAR RENTAL MINI PROJECT");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Add Vehicle");
            Console.WriteLine("3. Show Customers");
            Console.WriteLine("4. Show Vehicles");
            Console.WriteLine("5. Rent Vehicle");
            Console.WriteLine("6. Show Bookings");
            Console.WriteLine("7. Show Invoices");
            Console.WriteLine("8. Show Logs");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        AddCustomer(repository);
                        break;
                    case "2":
                        AddVehicle(repository);
                        break;
                    case "3":
                        ShowCustomers(repository);
                        break;
                    case "4":
                        ShowVehicles(repository);
                        break;
                    case "5":
                        RentVehicle(repository, rentalService);
                        break;
                    case "6":
                        rentalService.ShowAllBookings();
                        Pause();
                        break;
                    case "7":
                        rentalService.ShowInvoices();
                        Pause();
                        break;
                    case "8":
                        rentalService.ShowLogs();
                        Pause();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Pause();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Pause();
            }
        }
    }

    private static void AddCustomer(IRentalRepository repository)
    {
        Console.Clear();
        Console.WriteLine("===== ADD CUSTOMER =====");

        Console.Write("Enter Customer ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Customer Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Customer Phone_Num: ");
        string phone = Console.ReadLine();

        Console.WriteLine("Enter Customer_Type By choice (1-4)");
        Console.WriteLine("1 ==> Vip1");
        Console.WriteLine("2 ==> Vip2");
        Console.WriteLine("3 ==> Vip3");
        Console.WriteLine("4 ==> User");
        int typeChoice = int.Parse(Console.ReadLine());

        CustomerType customerType = typeChoice switch
        {
            1 => CustomerType.Vip1,
            2 => CustomerType.Vip2,
            3 => CustomerType.Vip3,
            _ => CustomerType.User
        };

        Console.Write("Enter Customer License_Num: ");
        string license = Console.ReadLine();

        Console.Write("Is the customer a student? (y/n): ");
        bool isStudent = Console.ReadLine().Trim().ToLower() == "y";

        Customer customer = new Customer(
            id, name, phone, customerType, license, isStudent);

        repository.AddCustomer(customer);

        Console.WriteLine("Customer added successfully!");
        Pause();
    }

    private static void AddVehicle(IRentalRepository repository)
    {
        Console.Clear();
        Console.WriteLine("===== ADD VEHICLE =====");

        Console.Write("Enter Vehicle ID: ");
        int vehicleId = int.Parse(Console.ReadLine());

        Console.Write("Enter Vehicle Brand: ");
        string brand = Console.ReadLine();

        Console.Write("Enter Vehicle License_plate: ");
        string plate = Console.ReadLine();

        Console.WriteLine("Enter Status By choice (1-3)");
        Console.WriteLine("1 ==> Available");
        Console.WriteLine("2 ==> Rented");
        Console.WriteLine("3 ==> Maintenance");
        int statusChoice = int.Parse(Console.ReadLine());

        VehicleStatus status = statusChoice switch
        {
            1 => VehicleStatus.Available,
            2 => VehicleStatus.Rented,
            _ => VehicleStatus.Maintenance
        };

        Console.WriteLine("Enter Vehicle Type By choice (1-3)");
        Console.WriteLine("1 ==> Sedan");
        Console.WriteLine("2 ==> SUV");
        Console.WriteLine("3 ==> Electric");
        int typeChoice = int.Parse(Console.ReadLine());

        Console.Write("Enter Vehicle Price Per Day: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Vehicle vehicle = typeChoice switch
        {
            1 => new SedanVehicle(vehicleId, brand, plate, status, price),
            2 => new SuvVehicle(vehicleId, brand, plate, status, price),
            3 => new ElectricVehicle(vehicleId, brand, plate, status, price),
            _ => new SedanVehicle(vehicleId, brand, plate, status, price)
        };

        repository.AddVehicle(vehicle);

        Console.WriteLine("Vehicle added successfully!");
        Pause();
    }

    private static void ShowCustomers(IRentalRepository repository)
    {
        Console.Clear();
        Console.WriteLine("===== CUSTOMERS =====");

        List<Customer> customers = repository.GetAllCustomers();

        if (customers.Count == 0)
        {
            Console.WriteLine("No customers found.");
            Pause();
            return;
        }

        foreach (Customer c in customers)
        {
            Console.WriteLine(
                $"ID: {c.ID} | Name: {c.Name} | Phone: {c.Phone_Num} | " +
                $"Type: {c.Customer_Type} | License: {c.License_Num} | Student: {c.IsStudent}");
        }

        Pause();
    }

    private static void ShowVehicles(IRentalRepository repository)
    {
        Console.Clear();
        Console.WriteLine("===== VEHICLES =====");

        List<Vehicle> vehicles = repository.GetAllVehicles();

        if (vehicles.Count == 0)
        {
            Console.WriteLine("No vehicles found.");
            Pause();
            return;
        }

        foreach (Vehicle v in vehicles)
        {
            Console.WriteLine(
                $"ID: {v.Vehicle_ID} | Brand: {v.Brand} | " +
                $"Plate: {v.License_plate} | Status: {v.Status} | " +
                $"Type: {v.GetVehicleType()} | Price: {v.Price:0.00}");
        }

        Pause();
    }

    private static void RentVehicle(
        IRentalRepository repository,
        RentalService rentalService)
    {
        Console.Clear();
        Console.WriteLine("===== RENT VEHICLE =====");

        List<Customer> customers = repository.GetAllCustomers();
        List<Vehicle> vehicles = repository.GetAllVehicles();

        if (customers.Count == 0 || vehicles.Count == 0)
        {
            Console.WriteLine("You need at least one customer and one vehicle.");
            Pause();
            return;
        }

        ShowCustomersWithoutPause(repository);
        Console.Write("\nEnter Customer ID: ");
        int customerId = int.Parse(Console.ReadLine());

        Customer customer = customers.FirstOrDefault(c => c.ID == customerId);

        if (customer == null)
        {
            Console.WriteLine("Customer not found.");
            Pause();
            return;
        }

        ShowVehiclesWithoutPause(repository);
        Console.Write("\nEnter Vehicle ID: ");
        int vehicleId = int.Parse(Console.ReadLine());

        Vehicle vehicle = vehicles.FirstOrDefault(v => v.Vehicle_ID == vehicleId);

        if (vehicle == null)
        {
            Console.WriteLine("Vehicle not found.");
            Pause();
            return;
        }

        Console.Write("Enter Rental Days: ");
        int rentalDays = int.Parse(Console.ReadLine());

        RentalBooking booking = rentalService.RentVehicle(
            customer, vehicle, rentalDays);

        if (booking != null)
        {
            Console.WriteLine("\n===== BOOKING SUMMARY =====");
            Console.WriteLine($"Booking ID: {booking.BookingId}");
            Console.WriteLine($"Customer: {booking.Customer.Name}");
            Console.WriteLine($"Vehicle: {booking.Car.Brand}");
            Console.WriteLine($"Days: {booking.RentalDays}");
            Console.WriteLine($"Base Total: {booking.BaseTotal:0.00}");
            Console.WriteLine($"Discount: {booking.DiscountAmount:0.00}");
            Console.WriteLine($"Final Total: {booking.FinalTotal:0.00}");
        }

        Pause();
    }

    private static void ShowCustomersWithoutPause(IRentalRepository repository)
    {
        Console.WriteLine("\n--- Customers ---");
        foreach (Customer c in repository.GetAllCustomers())
            Console.WriteLine($"{c.ID} - {c.Name} - {c.Customer_Type}");
    }

    private static void ShowVehiclesWithoutPause(IRentalRepository repository)
    {
        Console.WriteLine("\n--- Vehicles ---");
        foreach (Vehicle v in repository.GetAllVehicles())
            Console.WriteLine($"{v.Vehicle_ID} - {v.Brand} - {v.GetVehicleType()} - {v.Status}");
    }

    private static void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}
