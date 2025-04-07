﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechShop.Exceptions;

namespace TechShop
{
    //Task 1,2,3
    public class Orders
    {
        //Private Fields
        private int _OrderId;
        private Customers _Customer; //Composition
        private DateTime _OrderDate;
        private decimal _TotalAmount;
        private List<OrderDetails> _orderDetails = new List<OrderDetails>(); // For products in the order
        private string _OrderStatus;

        //Public Properties with Encapsulation

        public List<OrderDetails> OrderDetails 
        { 
            get { return _orderDetails; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("OrderDetails list cannot be null.");
                _orderDetails = value;
            }
        }
        public int OrderId
        {
            get { return _OrderId; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Order ID must be greater than 0.");
                _OrderId = value;
            }
        }

        public Customers Customer
        {
            get { return _Customer; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Customer", "Customer cannot be null.");
                _Customer = value;
            }
        }

        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Order date cannot be in the future.");
                _OrderDate = value;
            }
        }

        public decimal TotalAmount
        {
            get { return _TotalAmount; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Total amount cannot be negative.");
                _TotalAmount = value;
            }
        }

        public string OrderStatus
        {
            get { return _OrderStatus; }
            set
            {
                string[] array = { "Pending", "Confirmed", "Shipped", "Delivered", "Cancelled" };
                if (!(array.Contains(value)))
                {
                    throw new InvalidDataException("Enter a Proper Data");
                }
                _OrderStatus = value;
            }
        }


        //Constructor

        public Orders() { }
        public Orders(int orderId, Customers customer, DateTime orderDate)
        {
            _OrderId = orderId;
            _Customer = customer;
            _OrderDate = orderDate;
            _OrderStatus = "Pending";
        }
        //Methods
        public void CalculateTotalAmount()
        {
            decimal total = 0;
            foreach (var item in _orderDetails)
            {
                total += (int)item.CalculateSubtotal();
            }
            TotalAmount = total;
        }

        public void GetOrderDetails()
        {
            Console.WriteLine($"Order ID: {OrderId}");
            Console.WriteLine($"Customer: {_Customer.FirstName} {_Customer.LastName}");
            Console.WriteLine($"Date: {OrderDate}");
            Console.WriteLine($"Status: {OrderStatus}");
            Console.WriteLine("Order Items:");
            foreach (var item in _orderDetails)
            {
                Console.WriteLine(item.GetOrderDetailInfo());
            }
            Console.WriteLine($"Total: ${TotalAmount}");
        }

        public void CancelOrder()
        {
            foreach (var detail in _orderDetails)
            {
                detail.Product.StockInQuantity += detail.Quantity; // Return stock
            }

            _orderDetails.Clear();
            TotalAmount = 0;
            OrderStatus = "Cancelled";
            Console.WriteLine("Order has been cancelled and stock has been adjusted.");
        }

        public void UpdateOrderStatus(string newStatus)
        {
            OrderStatus = newStatus;
            Console.WriteLine($"Order status updated to: {OrderStatus}");
        }

        //static void Main(string[] args)
        //{
        //    Customers customer = new Customers(1, "Sudharsan", "M", "sonu@gmail.com", "1234567890", "kolathur");
        //    Products laptop = new Products(1001, "Laptop", "Gaming Laptop", 1200.50, 10);
        //    Products mouse = new Products(1002, "Wireless Mouse", "Bluetooth mouse", 25.99, 30);

        //    Orders order = new Orders(1, customer, DateTime.Now);

        //    OrderDetails detail1 = new OrderDetails(1, order, laptop, 1);
        //    OrderDetails detail2 = new OrderDetails(2, order, mouse, 2);

        //    order.OrderDetails.Add(detail1);
        //    order.OrderDetails.Add(detail2);

        //    bool exit = false;

        //    while (!exit)
        //    {
        //        Console.WriteLine("\n=== ORDER MENU ===");
        //        Console.WriteLine("1. View Order Details");
        //        Console.WriteLine("2. Calculate Total Amount");
        //        Console.WriteLine("3. Update Order Status");
        //        Console.WriteLine("4. Cancel Order");
        //        Console.WriteLine("5. Exit");
        //        Console.Write("Enter your choice: ");
        //        string choice = Console.ReadLine();

        //        switch (choice)
        //        {
        //            case "1":
        //                order.GetOrderDetails();
        //                break;

        //            case "2":
        //                order.CalculateTotalAmount();
        //                Console.WriteLine("Total amount calculated.");
        //                break;

        //            case "3":
        //                Console.WriteLine("Enter new order status (Pending, Confirmed, Shipped, Delivered, Cancelled): ");
        //                string status = Console.ReadLine();
        //                try
        //                {
        //                    order.UpdateOrderStatus(status);
        //                }
        //                catch (InvalidDataException ex)
        //                {
        //                    Console.WriteLine("Error: " + ex.Message);
        //                }
        //                break;

        //            case "4":
        //                order.CancelOrder();
        //                break;

        //            case "5":
        //                exit = true;
        //                Console.WriteLine("Exiting...");
        //                break;

        //            default:
        //                Console.WriteLine("Invalid choice. Please try again.");
        //                break;
        //        }
        //    }
        //}
    }
}
