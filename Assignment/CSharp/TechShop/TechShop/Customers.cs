using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop
{
    public class Customers
    {
        //Private Fields
        private int _CustomerId;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _Phone;
        private string _Address;

        //Properties with Encapsulation
        public int CustomerId
        {
            get { return _CustomerId; }
            set { _CustomerId = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public Customers(int CustomerID, string FirstName, string LastName, string Email, string Phone, string Address)
        {
            this._CustomerId = CustomerID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this._Address = Address;
        }

        //Composition and Encapsulation
        private List<Orders> _orders = new List<Orders>();

        public List<Orders> Orders
        {
            get { return _orders; } // Only allows reading, not setting from outside
        }

        //Methods
        public void GetCustomerDetails()
        {
            Console.WriteLine("Customer Details:");
            Console.WriteLine($"Name     : {FirstName} {LastName}");
            Console.WriteLine($"Email    : {Email}");
            Console.WriteLine($"Phone    : {Phone}");
            Console.WriteLine($"Address  : {Address}");
        }

        public int CalculateTotalOrders()
        {
            return _orders.Count;
        }

       
    }
}
