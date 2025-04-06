using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TechShop
{
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

        public List<OrderDetails> OrderDetails { get { return _orderDetails; } }
        public int OrderId
        {
            get { return _OrderId; }
            set { _OrderId = value; }
        }

        public Customers Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }

        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }

        public decimal TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }

        public string OrderStatus
        {
            get { return _OrderStatus; }
            set { _OrderStatus = value; }
        }


        //Constructor
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
            Console.WriteLine($"Total: ₹{TotalAmount}");
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

    }
}
