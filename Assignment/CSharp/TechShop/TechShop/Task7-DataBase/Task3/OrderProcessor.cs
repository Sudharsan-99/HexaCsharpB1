using System;
using System.Data.SqlClient;
using TechShop.Mains;

namespace TechShop.DataBase.Task3
{
    public class OrderProcessor
    {
        public static void PlaceOrder()
        {
            SqlConnection con = DatabaseConnector.getConnection();

            Console.Write("Enter CustomerID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            // Create the order
            DateTime orderDate = DateTime.Now;
            decimal totalAmount = 0;

            string insertOrderQuery = "insert into Orders (CustomerID, OrderDate, TotalAmount)VALUES (@customerId, @orderDate, @totalAmount)";
            SqlCommand insertOrderCmd = new SqlCommand(insertOrderQuery, con);
            insertOrderCmd.Parameters.AddWithValue("@customerId", customerId);
            insertOrderCmd.Parameters.AddWithValue("@orderDate", orderDate);
            insertOrderCmd.Parameters.AddWithValue("@totalAmount", totalAmount);

            // Step 2: Get last inserted ID (not safe for concurrent users)
            SqlCommand idCmd = new SqlCommand("SELECT MAX(OrderID) FROM Orders", con);
            int orderId = (int)idCmd.ExecuteScalar();

            bool addingProducts = true;

            while (addingProducts)
            {
                Console.Write("Enter ProductID to order: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                // Get product price
                string getPriceQuery = "select Price from Products where ProductID = @productId";
                SqlCommand priceCmd = new SqlCommand(getPriceQuery, con);
                priceCmd.Parameters.AddWithValue("@productId", productId);
                decimal price = (decimal)priceCmd.ExecuteScalar();

                // Calculate subtotal and update total
                decimal subtotal = price * quantity;
                totalAmount += subtotal;

                // Insert into OrderDetails
                string insertDetailQuery = "insert into OrderDetails (OrderID, ProductID, Quantity) values (@orderId, @productId,@quantity)";
                SqlCommand detailCmd = new SqlCommand(insertDetailQuery, con);
                detailCmd.Parameters.AddWithValue("@orderId", orderId);
                detailCmd.Parameters.AddWithValue("@productId", productId);
                detailCmd.Parameters.AddWithValue("@quantity", quantity);
                detailCmd.ExecuteNonQuery();

                // Update Inventory
                string updateInventoryQuery = "update Inventory set QuantityInStock = QuantityInStock - @quantity WHERE ProductID = @productId";
                SqlCommand invCmd = new SqlCommand(updateInventoryQuery, con);
                invCmd.Parameters.AddWithValue("@quantity", quantity);
                invCmd.Parameters.AddWithValue("@productId", productId);
                invCmd.ExecuteNonQuery();

                Console.Write("Add another product? (yes/no): ");
                string s = Console.ReadLine().ToLower();
                if (!(s == "yes"))
                {
                    addingProducts = false;
                }
            }

            // Update total in order
            string updateTotalQuery = "update Orders SET TotalAmount = @total WHERE OrderID = @orderId";
            SqlCommand updateCmd = new SqlCommand(updateTotalQuery, con);
            updateCmd.Parameters.AddWithValue("@total", totalAmount);
            updateCmd.Parameters.AddWithValue("@orderId", orderId);
            updateCmd.ExecuteNonQuery();

            Console.WriteLine($"\nOrder #{orderId} placed successfully! Total Amount: ${totalAmount}");
            Console.WriteLine("-------------------");
            con.Close();
        }
    }
}

