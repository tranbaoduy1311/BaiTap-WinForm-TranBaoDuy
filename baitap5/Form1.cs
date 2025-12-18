using System;
using System.Windows.Forms;
using System.IO; 

namespace baitap5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("Key_Logger.txt", true);

                sw.Write(e.KeyCode + " ");

                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}