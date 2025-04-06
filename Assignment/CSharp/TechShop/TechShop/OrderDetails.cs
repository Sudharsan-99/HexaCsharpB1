using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Exceptions;

namespace TechShop
{
    public class OrderDetails
    {
        private int _orderDetailID;
        private Orders _order;
        private Products _product;
        private int _quantity;
        private double _discountPercentage;

        // Public properties
        public int OrderDetailID
        {
            get { return _orderDetailID; }
            set { _orderDetailID = value; }
        }

        public Orders Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public Products Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public double DiscountPercentage
        {
            get { return _discountPercentage; }
            private set { _discountPercentage = value; }
        }
        //COnstructor
        public OrderDetails(int orderDetailId, Orders order, Products product, int quantity)
        {
            if (product == null)
            {
                throw new IncompleteOrderException("Order detail must have a valid product reference.");
            }

            OrderDetailID = orderDetailId;
            Order = order;
            Product = product;
            Quantity = quantity;
            DiscountPercentage = 0; // optional default
        }
        //Methods
        public double CalculateSubtotal()
        {
            double subtotal = Product.Price * Quantity;
            if (DiscountPercentage > 0)
            {
                subtotal -= subtotal * (DiscountPercentage / 100);
            }
            return subtotal;
        }

        public string GetOrderDetailInfo()
        {
            return $"OrderDetail ID: {OrderDetailID}\n" +
                   $"Product: {Product.ProductName}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Price per unit: {Product.Price:C}\n" +
                   $"Subtotal: {CalculateSubtotal():C}";
        }

        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
            Quantity = newQuantity;
        }

        public void AddDiscount(double discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new ArgumentException("Discount must be between 0 and 100.");
            }
            DiscountPercentage = discountPercentage;
        }

    }
}
