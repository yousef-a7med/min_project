namespace CarRentalMiniProject.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone_Num { get; set; }
        public CustomerType Customer_Type { get; set; }
        public string License_Num { get; set; }
        public bool IsStudent { get; set; }

        public Customer(int id, string name, string phoneNum,
            CustomerType customerType, string licenseNum, bool isStudent = false)
        {
            ID = id;
            Name = name;
            Phone_Num = phoneNum;
            Customer_Type = customerType;
            License_Num = licenseNum;
            IsStudent = isStudent;
        }
    }
}
