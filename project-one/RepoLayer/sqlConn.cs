using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RepoLayer
{
    public class sqlConn
    {

        public static void connect()
        {
            SqlConnection conn = new SqlConnection("");
                
            string insert = "INSERT INTO Customers(FirstName, Lastname, Notes) VALUES('X', 'Y', 'Z')";
            string join = "SELECT * FROM dbo.Customers JOIN dbo.Orders ON dbo.Customers.CustomerId = dbo.Orders.FK_Customer ORDER BY dbo.Customers.FirstName";
            
            SqlCommand command = new SqlCommand(join, conn);
            conn.Open();
            SqlDataReader myReader = command.ExecuteReader();

            while (myReader.Read())
            {
                Console.WriteLine($"\t{myReader.GetInt32(0)}\t{myReader.GetString(1)}\t{myReader.GetString(2)}\t{myReader.GetString(3)}\t{myReader.GetInt32(4)}");
            }

            conn.Close();
        }
    }
}