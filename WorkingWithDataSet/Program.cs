using System;
using System.Data;
using System.Data.SqlClient;

namespace WorkingWithDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkingWithDataSet();
        }
        static void WorkingWithDataSet()
        {
            string cString = "Data Source=LAPTOP-4OA6U478\\MSSQLSERVER01;Initial Catalog=Northwind;Integrated Security=True;Pooling=False";

            // SqlConnection - Represents an open connection to a SQL Server database. This class cannot be inherited.
            SqlConnection northwindConnection = new SqlConnection(cString);

            string customerCommandText = "SELECT * FROM Customers";

            // SqlDataAdapter - Represents a set of data commands and a database connection that are used to fill the DataSet and update a SQL Server database. This class cannot be inherited.
            SqlDataAdapter customerAdapter = new SqlDataAdapter(customerCommandText, northwindConnection);

            string ordersCommandText = "SELECT * FROM Orders";

            SqlDataAdapter ordersAdapter = new SqlDataAdapter(ordersCommandText, northwindConnection);

            // DataSet - A DataSet is an in-memory representation of relational data.
            DataSet customerOrders = new DataSet();
            customerAdapter.Fill(customerOrders, "Customer");
            ordersAdapter.Fill(customerOrders, "Order");

            // DataRelation - Represents a parent/child relationship between two DataTable objects.
            // DataTable - Represents one table of in-memory data.
            // DataColumns  - Represents the schema of a column in a DataTable.
            DataRelation relation = customerOrders.Relations.Add("CustomerOrders", customerOrders.Tables["Customers"].Columns["CustomerID"], 
                customerOrders.Tables["Orders"].Columns["CustomerID"]);

            foreach (DataRow customerRow in customerOrders.Tables["Customer"].Rows)
            {
                Console.WriteLine(customerRow["CustomerID"]);

                // GetChildRows - Gets the child rows of this DataRow using the specified DataRelation..
                foreach (DataRow orderRow in customerRow.GetChildRows(relation))
                {
                    Console.WriteLine("\t" + orderRow["OrderID"]);
                    Console.ReadKey();
                }
            }
        }
    }
}
