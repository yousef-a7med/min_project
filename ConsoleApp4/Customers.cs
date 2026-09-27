using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public enum customerType
    {
        vip1,
        vip2,
        vip3,
        user
    }
    internal class Customers
    {
        public Customers(int iD, string name, string phone_Num, customerType customer_Type, string license_Num)
        {
            this.ID = iD;
            this.Name = name;
            this.Phone_Num = phone_Num;
            this.Customer_Type = customer_Type;
            this.License_Num = license_Num;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone_Num { get; set; }
        public customerType Customer_Type { get; set; }
        public string License_Num { get; set; }

    }
}
