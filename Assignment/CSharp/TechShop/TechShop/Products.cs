using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop
{
    public class Products
    {
        //Private Fields
        private int _ProductID;
        private string _ProductName;
        private string _Description;
        private int _StockInQuantity;
        private double _Price;


        public Products() { }
        //Properties with Encapsulation
        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }

        public int StockInQuantity
        {
            get { return _StockInQuantity; }
            set { _StockInQuantity = value; }
        }

        public Products(int ProductId,string ProductName,String Description,double price,int StockInQuantity)
        {
            this.ProductID = ProductId;
            this.ProductName = ProductName;
            this.Description = Description;
            this.Price = price;
            this.StockInQuantity = StockInQuantity;
        }

        //Methods
        public string GetProductDetails()
        {
            return $"Product ID: {ProductID}\n" +
              $"Name: {ProductName}\n" +
              $"Description: {Description}\n" +
              $"Price: ${Price}";
        }

        //public void UpdateProductInfo() { }

        public bool IsProductInStock() 
        {
            return this.StockInQuantity > 0;
        }
    }
}
