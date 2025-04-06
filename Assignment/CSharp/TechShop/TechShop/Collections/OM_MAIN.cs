using System;
using System.Collections.Generic;
using TechShop.Exceptions;

namespace TechShop.Collections
{
    class OM_MAIN
    {
        static void Main(string[] args)
        {
            OrderManager orderManager = new OrderManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== TechShop Order Management =====");
                Console.WriteLine("1. View All Orders");
                Console.WriteLine("2. Add New Order ");
                Console.WriteLine("3. Cancel Order");
                Console.WriteLine("4. Update Order Status");
                Console.WriteLine("5. Sort Orders by Date (Ascending)");
                Console.WriteLine("6. Sort Orders by Date (Descending)");
                Console.WriteLine("7. Display Orders by Date Range");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine().Trim();

                switch (choice)
                {
                    case "1":
                        orderManager.DisplayAllOrders();
                        break;

                    case "2":
                        try
                        {
                            Console.WriteLine("Adding a new order...");

                            Console.Write("Enter Order ID: ");
                            int orderId = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Product ID: ");
                            int productId = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Product Name: ");
                            string productName = Console.ReadLine();

                            Console.Write("Enter Product Price: ");
                            double productPrice = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Enter Quantity: ");
                            int quantity = Convert.ToInt32(Console.ReadLine());

                            // Create product and order detail
                            Products product = new Products
                            {
                                ProductID = productId,
                                ProductName = productName,
                                Price = productPrice
                            };

                            OrderDetails orderDetail = new OrderDetails
                            {
                                Product = product,
                                Quantity = quantity
                            };

                            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
                            orderDetailsList.Add(orderDetail);

                            Orders newOrder = new Orders
                            {
                                OrderId = orderId,
                                OrderDate = DateTime.Now,
                                OrderStatus = "Pending",
                                OrderDetails = orderDetailsList,
                                TotalAmount = (decimal)product.Price * quantity
                            };

                            orderManager.AddOrder(newOrder);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                        break;

                    case "3":
                        Console.Write("Enter Order ID to cancel: ");
                        int cancelId = Convert.ToInt32(Console.ReadLine());
                        orderManager.CancelOrder(cancelId);
                        break;

                    case "4":
                        Console.Write("Enter Order ID to update: ");
                        int updateId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new status: ");
                        string newStatus = Console.ReadLine();
                        orderManager.UpdateOrderStatus(updateId, newStatus);
                        break;

                    case "5":
                        orderManager.SortOrdersByDateAscending();
                        break;

                    case "6":
                        orderManager.SortOrdersByDateDescending();
                        break;

                    case "7":
                        Console.Write("Enter start date (yyyy-MM-dd): ");
                        DateTime start = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter end date (yyyy-MM-dd): ");
                        DateTime end = DateTime.Parse(Console.ReadLine());
                        orderManager.DisplayOrdersByDateRange(start, end);
                        break;

                    case "8":
                        running = false;
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
