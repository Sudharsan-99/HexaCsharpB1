using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace TechShop.DataBase
{
    public class DatabaseConnector
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader dr;

        static void Main(string[] args)
        {
            AddCustomer();
        }
        public static SqlConnection getConnection()
        {
            con = new SqlConnection("data source = DESKTOP-R2484O8\\SQLEXPRESS;initial catalog = TechShop;integrated security = true;");
            con.Open();
            return con;
        }

        public static void AddCustomer()
        {
            con = getConnection();
            string FirstName, LastName, Email, Phone, Address;
            Console.Write("Enter The FirstName = ");
            FirstName = Console.ReadLine();
            Console.Write("Enter The LastName = ");
            LastName = Console.ReadLine();
            Console.Write("Enter The Email = ");
            Email = Console.ReadLine();
            Console.Write("Enter The Phone = ");
            Phone = Console.ReadLine();
            Console.Write("Enter The Address = ");
            Address = Console.ReadLine();

            cmd = new SqlCommand("insert into Customers(FirstName, LastName, Email, Phone, [Address]) values (@FirstName,@LastName,@Email,@Phone,@Address)",con);

            cmd.Parameters.AddWithValue("FirstName", FirstName);
            cmd.Parameters.AddWithValue("LastName", LastName);
            cmd.Parameters.AddWithValue("Email", Email);
            cmd.Parameters.AddWithValue("Phone", Phone);
            cmd.Parameters.AddWithValue("Address", Address);

            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                Console.WriteLine("Record added successfully..");
            }
            else { Console.WriteLine("Unable to add a record .."); }
                
        }
    }
   
}
