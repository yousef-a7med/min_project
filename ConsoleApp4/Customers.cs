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
        

        public Customers( int iD, string name, string phone_Num, customerType customer_Type, string license_Num)
        {
            
            ID = iD;
            Name = name;
            Phone_Num = phone_Num;
            Customer_Type = customer_Type;
            License_Num = license_Num;
            custumer_list.Add(this);
        }

        

        public static List<Customers> custumer_list = new List<Customers>();
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone_Num { get; set; }
        public customerType Customer_Type { get; set; }
        public string License_Num { get; set; }

    }
}
