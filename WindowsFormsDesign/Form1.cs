using System;
using System.Windows.Forms;

namespace WindowsFormsDesign
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // DateTimePicker.ValueChanged Event - Occurs when the Value property changes.
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // DateTimePicker.Value Property - Gets or sets the date/time value assigned to the control.
            label1.Text = dateTimePicker1.Value.ToLongDateString();
        }
    }
}
