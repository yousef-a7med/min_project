using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public enum Statue
    {
        avaliable,
        Rented,
        Maintenance
    }
    public enum Category
    {
        Electric_Car,
        Gas_Car,
        Fuel_Car
    }
    internal class Vehicles
    {
        public Vehicles(int vehicle_ID, string brand, string license_plate, Statue statue, Category category, decimal price)
        {
            this.Vehicle_ID = vehicle_ID;
            this.Brand = brand;
            this.License_plate = license_plate;
            this.statue = statue;
            this.category = category;
            this.Price = price;
        }

        public int Vehicle_ID { get; set; }
        public string Brand { get; set; }
        public string License_plate { get; set; }
        public Statue statue { get; set; }
        public Category category { get; set; }
        public decimal Price { get; set; }
    }
}
