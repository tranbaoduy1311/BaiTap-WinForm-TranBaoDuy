using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace baitap8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void y_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }

     
        private void btCong_Click(object sender, EventArgs e)
        {
            int x = int.Parse(tbSoX.Text);
            int y = int.Parse(tbSoY.Text);
            int kq = x + y;

            // Cũ: tbKetQua.Text = kq.ToString();
            // Mới: Lấy text cũ + phép tính mới + xuống dòng (\r\n)
            tbKetQua.Text = tbKetQua.Text + x.ToString() + " + " + y.ToString() + " = " + kq.ToString() + "\r\n";
        }

      
        private void btNhan_Click(object sender, EventArgs e)
        {
            int x = int.Parse(tbSoX.Text);
            int y = int.Parse(tbSoY.Text);
            int kq = x * y;

            // Cộng dồn vào lịch sử
            tbKetQua.Text = tbKetQua.Text + x.ToString() + " * " + y.ToString() + " = " + kq.ToString() + "\r\n";
        }

      
        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Lưu vào file Calculator.txt, chế độ true (ghi nối tiếp)
                StreamWriter sw = new StreamWriter("Calculator.txt", true);
                sw.Write(tbKetQua.Text);
                sw.Close();
                MessageBox.Show("Đã lưu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
