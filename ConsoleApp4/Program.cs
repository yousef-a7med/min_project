using ConsoleApp4;
using System.Security.Cryptography;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        
        Console.WriteLine( "Enter Customer ID");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Customer Name");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Customer Phone_Num");
        string Phone_num =Console.ReadLine();

        Console.WriteLine("Enter Customer_Type By choice (1-4)");
        Console.WriteLine("1 ==> vip1");
        Console.WriteLine("2 ==> vip2");
        Console.WriteLine("3 ==> vip3");
        Console.WriteLine("4 ==> user");
 
        int choice1 = int.Parse(Console.ReadLine());
        customerType customer_type;

        switch (choice1)
        {
            case 1:
                customer_type = customerType.vip1;
                break;
            case 2:
                customer_type = customerType.vip2;
                break;
            case 3:
                customer_type = customerType.vip3;
                break;
            case 4:
                customer_type = customerType.user;
                break;
            default:
                Console.WriteLine("Invalid choice setting to default user");
                customer_type = customerType.user;
                break;
        }

        Console.WriteLine("Enter Customer License_Num");
        string license_num = Console.ReadLine();

        Customers c1 = new Customers(id, name, Phone_num, customer_type, license_num);
        Customers c2 = new Customers(id, name, Phone_num, customer_type, license_num);
        Console.Clear();

        Console.WriteLine("To Print The List Of Customer Press 1");
        int x1 = int.Parse(Console.ReadLine());
        if (x1 == 1)
        {
            foreach (Customers c in Customers.custumer_list)
            {
                Console.WriteLine($"ID: {c.ID} | Name: {c.Name} | Phone: {c.Phone_Num} | Type: {c.Customer_Type} | License: {c.License_Num}");
            }

        }
        else
            Console.Clear();

        //==========================================================================================

        Console.WriteLine("Enter  Vehicle_ID");
        int vehicle_id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Vehicle Brand");
        string brand = Console.ReadLine();

        Console.WriteLine("Enter Vehicle License_plate");
        string license_plate = Console.ReadLine();

        Console.WriteLine("Enter Statue By choice (1-3)");
        Console.WriteLine("1 ==> avaliable");
        Console.WriteLine("2 ==> Rented");
        Console.WriteLine("3 ==> Maintenance");
        int choice2 = int.Parse(Console.ReadLine());
        Statue statue;

        switch (choice2)
        {
            case 1:
                statue = Statue.avaliable;
                break;
            case 2:
                statue = Statue.Rented;
                break;
            case 3:
                statue = Statue.Maintenance;
                break;
            default:
                Console.WriteLine("Invalid choice setting to default user");
                statue = Statue.Maintenance;
                break;
        }

        Console.WriteLine("Enter Category By choice (1-3)");
        Console.WriteLine("1 ==>  Electric_Car");
        Console.WriteLine("2 ==> Gas_Car");
        Console.WriteLine("3 ==> Fuel_Car");
        int choice3 = int.Parse(Console.ReadLine());
        Category category;

        switch (choice3)
        {
            case 1:
                category = Category.Electric_Car;
                break;
            case 2:
                category = Category.Gas_Car;
                break;
            case 3:
                category = Category.Fuel_Car;
                break;
            default:
                Console.WriteLine("Invalid choice setting to default user");
                category = Category.Fuel_Car;
                break;
        }

        Console.WriteLine("Enter Vehicle Price");
        int price = int.Parse(Console.ReadLine());

        Vehicles v1 = new Vehicles(vehicle_id, brand, license_plate, statue, category, price);
        Console.Clear();

        Console.WriteLine("To Print The List Of Vehicle Press 1");
        int x2 = int.Parse(Console.ReadLine());
        if (x2 == 1)
        {
            foreach (Vehicles v in Vehicles.vehicles_list)
            {
                Console.WriteLine($"vehicle_id: {v.Vehicle_ID} | Brand: {v.Brand} | License_plate: {v.License_plate} | statue: {v.statue} | category: {v.category} | Price: {v.Price}");
            }

        }
        else
            Console.Clear();
    }
}