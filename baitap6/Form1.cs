using System;
using System.Windows.Forms;

namespace Example01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            this.Text = "Article for Button";

            this.Size = new System.Drawing.Size(500, 500);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
               
                e.Handled = true;
            }
        }

        private void tbYear_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            if (tbYear.Text.Length > 0)
            {
                int year = int.Parse(tbYear.Text);

                // Nếu năm lớn hơn 2000
                if (year > 2000)
                {
                   
                    e.Cancel = true;
                }
            }
        }
    }

}
