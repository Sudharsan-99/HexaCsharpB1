using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Exceptions;

namespace TechShop
{
    public class Inventory
    {
        // Private fields
        private int _inventoryID;
        private Products _product; // Composition: Inventory "has a" Product
        private int _quantityInStock;
        private DateTime _lastStockUpdate;

        // Properties
        public int InventoryID
        {
            get { return _inventoryID; }
            set { _inventoryID = value; }
        }

        public Products Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public int QuantityInStock
        {
            get { return _quantityInStock; }
            set
            {
                _quantityInStock = value;
                LastStockUpdate = DateTime.Now; // Automatically update stock time
            }
        }

        public DateTime LastStockUpdate
        {
            get { return _lastStockUpdate; }
            private set { _lastStockUpdate = value; }
        }

        // Constructor
        public Inventory(int inventoryID, Products product, int quantity)
        {
            InventoryID = inventoryID;
            Product = product;
            QuantityInStock = quantity;
            LastStockUpdate = DateTime.Now;
        }

        // Methods

        public Products GetProduct()
        {
            return Product;
        }

        public int GetQuantityInStock()
        {
            return QuantityInStock;
        }

        public void AddToInventory(int quantity)
        {
            QuantityInStock += quantity;
        }

        public void RemoveFromInventory(int quantity)
        {
            if (quantity > QuantityInStock)
            {
                throw new InsufficientStockException(
                    $"Requested quantity ({quantity}) exceeds available stock ({QuantityInStock}).");
            }

            QuantityInStock -= quantity;
        }

        public void UpdateStockQuantity(int newQuantity)
        {
            QuantityInStock = newQuantity;
        }

        public bool IsProductAvailable(int quantityToCheck)
        {
            return QuantityInStock >= quantityToCheck;
        }

        public double GetInventoryValue()
        {
            return Product.Price * QuantityInStock;
        }

        //ListLowStockProducts(int threshold)

        //ListOutOfStockProducts() 

        // Lists all products in the inventory with their quantity and basic details
        public static void ListAllProducts(List<Inventory> inventoryList)
        {
            Console.WriteLine("All Products in Inventory:\n");
            foreach (var item in inventoryList)
            {
                Console.WriteLine($"Product ID   : {item.Product.ProductID}");
                Console.WriteLine($"Product Name : {item.Product.ProductName}");
                Console.WriteLine($"Price        : {item.Product.Price:C}");
                Console.WriteLine($"Quantity     : {item.QuantityInStock}");
                Console.WriteLine($"Last Updated : {item.LastStockUpdate}");
                Console.WriteLine("------------------------");
            }
        }
    }
}
