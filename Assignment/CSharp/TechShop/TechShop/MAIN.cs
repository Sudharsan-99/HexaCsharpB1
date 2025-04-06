using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop
{
    class MAIN
    {
        public static void Main(string[] args)
        {
            // Setup sample data

            Customers csudharsan = new Customers(1, "Sudharsan", "M", "sudharsan.m@gmail.com", "7604875003", "Kolathur,Chennai");

            Products phone = new Products(1, "Smartphone", "AI smartphone", 12000, 50);
            Products earbuds = new Products(2, "Wireless Earbuds", "Noise-canceling", 599.99, 30);

            Inventory inventory1 = new Inventory(1, phone, 50);
            Inventory inventory2 = new Inventory(2, earbuds, 30);
            List<Inventory> allInventory = new List<Inventory> { inventory1, inventory2 };

            Orders sorder = new Orders(1, csudharsan, DateTime.Now);
            OrderDetails detail1 = new OrderDetails(1, sorder, phone, 2);
            OrderDetails detail2 = new OrderDetails(2, sorder, earbuds, 1);
            detail1.AddDiscount(10); // 10% discount
            sorder.OrderDetails.Add(detail1);
            sorder.OrderDetails.Add(detail2);
            sorder.CalculateTotalAmount();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== TechShop Menu ===");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. View Customer Info");
                Console.WriteLine("3. View Order Summary");
                Console.WriteLine("4. Update Order Status");
                Console.WriteLine("5. Cancel Order");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice (1-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n--- Inventory ---");
                        Inventory.ListAllProducts(allInventory);
                        break;

                    case "2":
                        Console.WriteLine("\n--- Customer Info ---");
                        csudharsan.GetCustomerDetails();
                        break;

                    case "3":
                        Console.WriteLine("\n--- Order Summary ---");
                        sorder.GetOrderDetails();
                        break;

                    case "4":
                        Console.Write("Enter new status (e.g., Shipped, Delivered): ");
                        string newStatus = Console.ReadLine();
                        sorder.UpdateOrderStatus(newStatus);
                        break;

                    case "5":
                        sorder.CancelOrder();
                        break;

                    case "6":
                        exit = true;
                        Console.WriteLine("Exiting the application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select an option between 1 and 6.");
                        break;
                }
            }
        }
    }
}
