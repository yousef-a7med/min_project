namespace CarRentalMiniProject.Models
{
    public abstract class Vehicle
    {
        public int Vehicle_ID { get; set; }
        public string Brand { get; set; }
        public string License_plate { get; set; }
        public VehicleStatus Status { get; set; }
        public decimal Price { get; set; }

        protected Vehicle(int vehicleId, string brand, string licensePlate,
            VehicleStatus status, decimal price)
        {
            Vehicle_ID = vehicleId;
            Brand = brand;
            License_plate = licensePlate;
            Status = status;
            Price = price;
        }

        public abstract string GetVehicleType();
    }

    public class SedanVehicle : Vehicle
    {
        public SedanVehicle(int vehicleId, string brand, string licensePlate,
            VehicleStatus status, decimal price)
            : base(vehicleId, brand, licensePlate, status, price) { }

        public override string GetVehicleType() => "Sedan";
    }

    public class SuvVehicle : Vehicle
    {
        public SuvVehicle(int vehicleId, string brand, string licensePlate,
            VehicleStatus status, decimal price)
            : base(vehicleId, brand, licensePlate, status, price) { }

        public override string GetVehicleType() => "SUV";
    }

    public class ElectricVehicle : Vehicle
    {
        public ElectricVehicle(int vehicleId, string brand, string licensePlate,
            VehicleStatus status, decimal price)
            : base(vehicleId, brand, licensePlate, status, price) { }

        public override string GetVehicleType() => "Electric";
    }
}
