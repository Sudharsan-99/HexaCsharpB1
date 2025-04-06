using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public Orders Order { get; set; }
        public double Amount { get; set; }
        public string PaymentStatus { get; set; } // e.g., Pending, Completed, Failed

        public DateTime PaymentDate { get; set; }

        public Payment(Orders order, double amount, string status, DateTime date)
        {
            this.Order = order;
            this.Amount = amount;
            this.PaymentStatus = status;
            this.PaymentDate = date;
        }

        public string GetPaymentDetails()
        {
            return $"Payment ID: {PaymentID}\n" +
                   $"Order ID: {Order.OrderId}\n" +
                   $"Amount: ₹{Amount}\n" +
                   $"Status: {PaymentStatus}\n" +
                   $"Date: {PaymentDate.ToString("dd-MM-yyyy HH:mm:ss")}";
        }
    }
}
