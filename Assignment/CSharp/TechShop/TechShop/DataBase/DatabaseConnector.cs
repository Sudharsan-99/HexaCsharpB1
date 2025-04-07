using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TechShop.DataBase.Task1;

using TechShop.DataBase.Task2;
using TechShop.DataBase.Task4;
using TechShop.DataBase.Task5;
using TechShop.DataBase.Task6;
using TechShop.DataBase.Task7;

namespace TechShop.DataBase
{
    public class DatabaseConnector
    {
        public static SqlConnection con ;
        public static SqlCommand cmd;
        public static SqlDataReader dr;

        public static SqlConnection getConnection()
        {
            con = new SqlConnection("data source = DESKTOP-R2484O8\\SQLEXPRESS;initial catalog = TechShop;integrated security = true;");
            con.Open();
            return con;
        }
        static void Main(string[] args)
        {
            bool running = true;
            while (running) 
            {
                Console.WriteLine("DataBase Connectivity Related Methods");
                Console.WriteLine("1.add Customer ");
                Console.WriteLine("2. Add Products ");
                Console.WriteLine("3. Update Products");
                Console.WriteLine("4.See Order Status");
                Console.WriteLine("5.Add To Inventory");
                Console.WriteLine("6.Update Inventory");
                Console.WriteLine("7.Delete From Inventory");
                Console.WriteLine("8.Generate Sale Report Based on Category");
                Console.WriteLine("9.Update Customer Details");
                Console.WriteLine("10.Exit");
                Console.Write("Enter Your Choice = ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CustomerRegistration.AddCustomer();
                        break;
                    case "2":
                        ProductCatalogManager productCatalogManager = new ProductCatalogManager();
                        productCatalogManager.AddProduct();
                        break;
                    case "3":
                        ProductCatalogManager pcm = new ProductCatalogManager();
                        pcm.UpdateProduct();
                        break;
                    case "4":
                        TrackingOrderStatus.SeeOrderStatus();
                        break;
                    case "5":
                        InventoryManagementSystem.AddInventory();
                        break;
                    case "6":
                        InventoryManagementSystem.UpdateInventory();
                        break;
                    case "7":
                        InventoryManagementSystem.RemoveDiscontinuedInventory();
                        break;
                    case "8":
                        SalesReport.GenerateSalesReportByCategory();
                        break;
                    case "9":
                        CustomerUpdates.UpdateCustomerAccount();
                        break;
                    case "10":
                        running = false;
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Enter a valid data");
                        break;
                }

            }
        }
       
    }
   
}
