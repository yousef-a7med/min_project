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
        Console.WriteLine($" {c1.ID} ,{c1.Name},{c1.Phone_Num},{c1.Customer_Type},{c1.License_Num}");

        Console.WriteLine( "==========================================================================");

        //==========================================================================================

        Console.WriteLine("Enter Customer Vehicle_ID");
        int vehicle_id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Customer Brand");
        string brand = Console.ReadLine();

        Console.WriteLine("Enter Customer License_plate");
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

        Console.WriteLine("Enter Customer Price");
        int price = int.Parse(Console.ReadLine());

        Vehicles v1 = new Vehicles(vehicle_id, brand, license_plate, statue, category, price);
        Console.WriteLine($" {v1.Vehicle_ID} ,{v1.Brand},{v1.License_plate},{v1.statue},{v1.category},{v1.Price}");


    }
}