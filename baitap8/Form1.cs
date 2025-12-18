using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// 1. QUAN TRỌNG: Thêm thư viện này để dùng StreamWriter
using System.IO;

namespace baitap8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Những hàm click thừa (label, y...) bạn có thể để nguyên hoặc xóa đi nếu không dùng
        private void label3_Click(object sender, EventArgs e) { }
        private void y_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }

        // 2. Cập nhật nút CỘNG: Cộng dồn lịch sử
        private void btCong_Click(object sender, EventArgs e)
        {
            int x = int.Parse(tbSoX.Text);
            int y = int.Parse(tbSoY.Text);
            int kq = x + y;

            // Cũ: tbKetQua.Text = kq.ToString();
            // Mới: Lấy text cũ + phép tính mới + xuống dòng (\r\n)
            tbKetQua.Text = tbKetQua.Text + x.ToString() + " + " + y.ToString() + " = " + kq.ToString() + "\r\n";
        }

        // 3. Cập nhật nút NHÂN: Cộng dồn lịch sử
        private void btNhan_Click(object sender, EventArgs e)
        {
            int x = int.Parse(tbSoX.Text);
            int y = int.Parse(tbSoY.Text);
            int kq = x * y;

            // Cộng dồn vào lịch sử
            tbKetQua.Text = tbKetQua.Text + x.ToString() + " * " + y.ToString() + " = " + kq.ToString() + "\r\n";
        }

        // 4. Thêm nút LƯU (Bạn nhớ tạo nút này bên giao diện và đặt tên là btLuu nhé)
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