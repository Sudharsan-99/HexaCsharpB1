using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Exceptions;

namespace TechShop
{
    //TASK 1,2,3 Main method is below
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
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("CustomerId can't be 0 or negative");
                }
                _CustomerId = value;
            }
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
            set 
            {
                if (!isValidEmail(value))
                {
                    throw new InValidDataException("Invalid Email Please enter a correct email");
                }

                _Email = value;
            }
        }

        public string Phone
        {
            get { return _Phone; }
            set
            {
                if (!isValidPhone(value))
                {
                    throw new InValidDataException("Invalid Number Please enter a correct Number");
                }
                _Phone = value;
            }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public Customers(int CustomerID, string FirstName, string LastName, string Email, string Phone, string Address)
        {
            if (!isValidEmail(Email)) 
            {
                throw new InvalidDataException("Invalid Email Please Enter a Valid Email");
            }

            if (!isValidPhone(Phone))
            {
                throw new InvalidDataException("Invalid PhoneNumber Please Enter a Valid Number");
            }
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

        public void UpdateCustomerInfo()
        {
            Console.WriteLine($"Updating info for Customer ID: {CustomerId} - {FirstName} {LastName}");
            Console.Write("Enter new Email (leave blank to keep current): ");
            string newEmail = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newEmail))
            {
                Email = newEmail;
            }
            Console.Write("Enter new Phone (leave blank to keep current): ");
            string newPhone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPhone))
            {
                Phone = newPhone;
            }
            Console.Write("Enter new Address (leave blank to keep current): ");
            string newAddress = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAddress))
            {
                Address = newAddress;
            }
            Console.WriteLine("Customer information updated successfully.");
        }


        public static  bool isValidEmail(string email)
        {
            if (!email.Contains("@"))
            {
                return false;
            }

            if (email[0] == '@')
            {
                return false;
            }

            if (email[email.Length - 1] == '@')
            {
                return false;
            }

            return true;
        }

        public static  bool isValidPhone(string phone) 
        {
            if (!(phone.Length == 10))
            {
                return false;
            }
            foreach (char c in phone)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            // Create a sample customer
            Customers customer = new Customers(1, "Sudharsan", "M", "sudharsan@gmail.com", "7604875003", "Kolathur, Chennai");

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== CUSTOMER METHOD MENU ===");
                Console.WriteLine("1. View Customer Details");
                Console.WriteLine("2. Update Customer Info");
                Console.WriteLine("3. View Total Orders");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        customer.GetCustomerDetails();
                        break;

                    case "2":
                        try
                        {
                            customer.UpdateCustomerInfo();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case "3":
                        int total = customer.CalculateTotalOrders();
                        Console.WriteLine($"Total Orders: {total}");
                        break;

                    case "4":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine(" Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

}
