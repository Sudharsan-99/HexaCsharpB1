using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Exceptions;

namespace TechShop.Collections
{
    class InventoryManager
    {
        private SortedList<int, Inventory> _inventory = new SortedList<int, Inventory>();

        // Add new inventory item
        public void AddInventoryItem(Inventory item)
        {
            int productId = item.Product.ProductID;

            if (_inventory.ContainsKey(productId))
            {
                Console.WriteLine("Product already exists in inventory. Consider updating stock.");
                return;
            }

            _inventory.Add(productId, item);
            Console.WriteLine($"Product '{item.Product.ProductName}' added to inventory.");
        }

        // Update stock quantity
        // Updates inventory when an order is processed
        public void UpdateInventoryOnOrder(List<OrderDetails> orderDetails)
        {
            foreach (var detail in orderDetails)
            {
                int productId = detail.Product.ProductID;
                int requestedQty = detail.Quantity;

                if (!_inventory.ContainsKey(productId))
                {
                    throw new InsufficientStockException($"Product ID {productId} not found in inventory.");
                }

                Inventory inventoryItem = _inventory[productId];

                if (inventoryItem.QuantityInStock < requestedQty)
                {
                    throw new InsufficientStockException(
                        $"Insufficient stock for product '{inventoryItem.Product.ProductName}'. Available: {inventoryItem.QuantityInStock}, Requested: {requestedQty}");
                }

                inventoryItem.RemoveFromInventory(requestedQty); // Updates quantity and LastStockUpdate
                Console.WriteLine($"Inventory updated for Product ID {productId}. Remaining: {inventoryItem.QuantityInStock}");
            }
        }


        // Remove item from inventory
        public void RemoveInventoryItem(int productId)
        {
            if (_inventory.Remove(productId))
            {
                Console.WriteLine($"Product ID {productId} removed from inventory.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void DisplayAllInventory()
        {
            Console.WriteLine("INVENTORY LIST:");
            foreach (var kv in _inventory)
            {
                Inventory item = kv.Value;
                Console.WriteLine($"Product ID: {item.Product.ProductID}, Name: {item.Product.ProductName}, Quantity: {item.QuantityInStock}, Updated: {item.LastStockUpdate}");
            }
        }
    }
}
