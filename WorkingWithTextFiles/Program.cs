using System;
using System.Data.SqlClient;
using System.IO;

namespace WorkingWithTextFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            CopyDataToTextFile(myDocumentsPath + @"\CustomerList.txt");
            DisplayTextFile(myDocumentsPath + @"\CustomerList.txt");
        }
        static private void CopyDataToTextFile(string fileName)
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-4OA6U478\\MSSQLSERVER01;Initial Catalog=Northwind;Integrated Security=True;Pooling=False";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT CustomerID, CompanyName," + "ContactName, Phone FROM Customers";
                using (connection)
                {
                    connection.Open();

                    // ExecuteReader - Sends the CommandText to the Connection and builds a SqlDataReader.
                    SqlDataReader reader = command.ExecuteReader();

                    // StreamWriter - Streaming support between SQL Server and an application (new in .NET Framework 4.5) supports unstructured data on the server (documents, images, and media files). A SQL Server database can store binary large objects (BLOBs), but retrieving BLOBS can use a lot of memory.
                   // Streaming support to and from SQL Server simplifies writing applications that stream data, without having to fully load the data into memory, resulting in fewer memory overflow exceptions.
                    // Streaming support will also enable middle-tier applications to scale better, especially in scenarios where business objects connect to SQL Azure in order to send, retrieve, and manipulate large BLOBs.
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        while (reader.Read())
                        {
                            string customerRow = String.Format("{0}, {1}, {2}, {3}", reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3));
                            sw.WriteLine(customerRow);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DisplayTextFile(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
