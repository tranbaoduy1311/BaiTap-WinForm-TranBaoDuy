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
            // Kiểm tra: Nếu KHÔNG phải là phím điều khiển (như Backspace) 
            // VÀ cũng KHÔNG phải là số (Digit)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // e.Handled = true nghĩa là: "Tôi đã xử lý rồi, đừng in ký tự này ra màn hình"
                // (Tức là chặn phím đó lại)
                e.Handled = true;
            }
        }

        private void tbYear_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Lấy dữ liệu trong ô text và chuyển sang số nguyên
            // Lưu ý: Nếu ô trống mà chạy dòng này sẽ lỗi, nhưng ta cứ làm theo bài mẫu trước
            if (tbYear.Text.Length > 0)
            {
                int year = int.Parse(tbYear.Text);

                // Nếu năm lớn hơn 2000
                if (year > 2000)
                {
                    // Cancel = true nghĩa là: "Dữ liệu sai rồi, hủy bỏ việc rời đi"
                    // Con trỏ chuột sẽ bị kẹt lại trong ô này cho đến khi bạn sửa đúng.
                    e.Cancel = true;
                }
            }
        }
    }
}