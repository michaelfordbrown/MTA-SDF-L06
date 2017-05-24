using System;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace QueryCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                SelectData(textBox1.Text);
            }
        }

        private void SelectData(string selectCommandText)
        {
            try
            {
                // Change the connection string to match with your system.
                string selectConnection =
                    "Data Source=LAPTOP-4OA6U478\\MSSQLSERVER01;Initial Catalog=Northwind;Integrated Security=True;Pooling=False";

                //  SqlDataAdapter - SqlDataAdapter is a part of the ADO.NET Data Provider and it resides in the System.Data.SqlClient namespace.SqlDataAdapter provides the communication between the Dataset and the SQL database.We can use SqlDataAdapter Object in combination with Dataset Object.Dim adapter As New SqlDataAdapter.
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);

                // DataTable - The DataTable is a central object in the ADO.NET library. Other objects that use the DataTable include the DataSet and the DataView.
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
