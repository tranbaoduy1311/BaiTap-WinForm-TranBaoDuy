using System;
using System.Drawing;
using System.Windows.Forms;

namespace baitap10 // Khớp chính xác với tên Project trong ảnh của bạn
{
    public partial class Form1 : Form
    {
        // Biến lưu trữ theo đúng ảnh "Article 10"
        decimal workingMemory = 0;
        string opr = "";

        // Các nút bấm và màn hình
        TextBox tbDisplay;
        Button bt0, bt1, bt2, bt3, btPlus, btMul, btDot, btEquals;

        public Form1()
        {
            // Quan trọng: Phải gọi InitializeComponent để không lỗi Designer
            InitializeComponent();

            this.Size = new Size(350, 400);
            this.Text = "Simple Calculator - Article 10";
            this.StartPosition = FormStartPosition.CenterScreen;

            InitCalculatorUI();
        }

        private void InitCalculatorUI()
        {
            // Màn hình hiển thị
            tbDisplay = new TextBox
            {
                Name = "tbDisplay",
                Location = new Point(15, 20),
                Width = 300,
                Font = new Font("Arial", 20),
                TextAlign = HorizontalAlignment.Right
            };
            this.Controls.Add(tbDisplay);

            // Tạo các nút bấm theo đúng sơ đồ trong ảnh của bạn
            bt0 = CreateBtn("0", 15, 80);
            bt1 = CreateBtn("1", 95, 80);
            bt2 = CreateBtn("2", 175, 80);
            bt3 = CreateBtn("3", 255, 80);

            btPlus = CreateBtn("+", 15, 160);
            btMul = CreateBtn("*", 95, 160);
            btDot = CreateBtn(".", 175, 160);
            btEquals = CreateBtn("=", 255, 160);

            // Gán sự kiện Click cho các nút số
            bt0.Click += (s, e) => tbDisplay.Text += "0";
            bt1.Click += (s, e) => tbDisplay.Text += "1";
            bt2.Click += (s, e) => tbDisplay.Text += "2";
            bt3.Click += (s, e) => tbDisplay.Text += "3";
            btDot.Click += (s, e) => tbDisplay.Text += ".";

            // Gán sự kiện cho các nút tính toán (Dựa theo code trong ảnh Article 10)
            btPlus.Click += (s, e) => {
                opr = "+";
                workingMemory = decimal.Parse(tbDisplay.Text);
                tbDisplay.Clear();
            };

            btMul.Click += (s, e) => {
                opr = "*";
                workingMemory = decimal.Parse(tbDisplay.Text);
                tbDisplay.Clear();
            };

            btEquals.Click += (s, e) => {
                decimal secondValue = decimal.Parse(tbDisplay.Text);
                if (opr == "+") tbDisplay.Text = (workingMemory + secondValue).ToString();
                if (opr == "*") tbDisplay.Text = (workingMemory * secondValue).ToString();
                opr = "";
            };
        }

        private Button CreateBtn(string text, int x, int y)
        {
            Button btn = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(70, 70),
                Font = new Font("Arial", 14, FontStyle.Bold)
            };
            this.Controls.Add(btn);
            return btn;
        }
    }
}