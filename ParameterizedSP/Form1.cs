using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ParameterizedSP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetTotalSalesButton_Click(object sender, EventArgs e)
        {
            TotalSalesLabel.Text = String.Format("Total Sales: {0}", GetTotalSales(CustomerIdTextBox.Text));
        }

        private double GetTotalSales(string customerId)
        {
            double totalSales = -1;
            try
            {
                // Change the connection string to match with your system
                string connectionString = "Data Source=LAPTOP-4OA6U478\\MSSQLSERVER01;Initial Catalog=Northwind;Integrated Security=True;Pooling=False";
                // SqlConnection - Represents an open connection to a SQL Server database.
                SqlConnection connection = new SqlConnection(connectionString);

                // Point to Stored Procedure GetCustomerSales
                // SqlCommand - Represents a Transact-SQL statement or stored procedure to execute against a SQL Server database.
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetCustomerSales";

                // Adds a value to the end of the SqlParameterCollection.
                // SqlParameterCollection - Represents a collection of parameters associated with a SqlCommand and their respective mappings to columns in a DataSet. This class cannot be inherited.
                command.Parameters.AddWithValue("@CustomerID", customerId);
                command.Parameters.AddWithValue("@TotalSales", null);

                // DbType - Specifies the data type of a field, a property, or a Parameter object of a .NET Framework data provider.
                // Direction - Gets or sets a value that indicates whether the parameter is input-only, output-only, bidirectional, or a stored procedure return value parameter.
                command.Parameters["@TotalSales"].DbType = DbType.Currency;
                command.Parameters["@Totalsales"].Direction = ParameterDirection.Output;

                //  SqlConnection.Open -  Opens a database connection with the property settings specified by the ConnectionString.              
                connection.Open();

                // ExecuteNonQuery - Executes a Transact-SQL statement against the connection and returns the number of rows affected.
                command.ExecuteNonQuery();

                totalSales = Double.Parse(command.Parameters["@TotalSales"].Value.ToString());

                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return totalSales;
        }

        private void CustomerIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
