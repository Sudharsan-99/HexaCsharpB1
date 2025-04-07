using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Mains;

namespace TechShop.DataBase.Task6
{
    public class SalesReport
    {
        public static void GenerateSalesReportByCategory()
        {
            SqlConnection con = DatabaseConnector.getConnection();
            string query = "SELECT p.category, SUM(od.Quantity * p.Price) AS TotalEarnings FROM OrderDetails od JOIN Products p ON od.ProductID = p.ProductID GROUP BY p.category";
            DatabaseConnector.cmd = new SqlCommand(query, DatabaseConnector.con);
            DatabaseConnector.dr = DatabaseConnector.cmd.ExecuteReader();

            if (!DatabaseConnector.dr.HasRows)
            {
                Console.WriteLine("No orders found for this customer.");
                return;
            }
            while (DatabaseConnector.dr.Read())
            {
                Console.WriteLine($" Category=={DatabaseConnector.dr[0]} \n TotalAmount=={DatabaseConnector.dr[1]}");
            }
        }
    }
}
