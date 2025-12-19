using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace baitap11
{
    public partial class Form1 : Form
    {
        // --- BIẾN LƯU TRỮ ---
        decimal memory = 0;
        decimal workingMemory = 0;
        string opr = "";

        TextBox txtDisplay;

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(360, 500);
            this.Text = "My Calculator - Article 11";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            InitCalculatorUI();
        }

        private void InitCalculatorUI()
        {
            // 1. Màn hình hiển thị
            txtDisplay = new TextBox
            {
                Location = new Point(15, 15),
                Width = 315,
                Font = new Font("Arial", 24),
                TextAlign = HorizontalAlignment.Right,
                ReadOnly = true,
                BackColor = Color.White
            };
            txtDisplay.Text = "0";
            this.Controls.Add(txtDisplay);

            // Định nghĩa kích thước chuẩn
            int btnW = 58;
            int btnH = 50;
            int spacing = 6;
            int startX = 15;
            int startY = 80;

            // Mảng các nút theo từng hàng để dễ quản lý tọa độ
            string[][] rows = new string[][] {
                new string[] { "MC", "MR", "MS", "M+", "M-" },
                new string[] { "←", "CE", "C", "±", "√" },
                new string[] { "7", "8", "9", "/", "%" },
                new string[] { "4", "5", "6", "*", "1/x" },
                new string[] { "1", "2", "3", "-", "=" }, // Nút = sẽ xử lý riêng
                new string[] { "0", ".", "+" }             // Nút 0 sẽ xử lý riêng
            };

            for (int r = 0; r < rows.Length; r++)
            {
                for (int c = 0; c < rows[r].Length; c++)
                {
                    string text = rows[r][c];
                    Button btn = new Button
                    {
                        Text = text,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        BackColor = Color.FromArgb(245, 245, 245),
                        FlatStyle = FlatStyle.Standard
                    };

                    // TÍNH TOÁN VỊ TRÍ ĐẶC BIỆT
                    if (text == "0")
                    {
                        btn.Size = new Size(btnW * 2 + spacing, btnH);
                        btn.Location = new Point(startX, startY + r * (btnH + spacing));
                    }
                    else if (text == ".")
                    {
                        btn.Size = new Size(btnW, btnH);
                        btn.Location = new Point(startX + 2 * (btnW + spacing), startY + r * (btnH + spacing));
                    }
                    else if (text == "+")
                    {
                        btn.Size = new Size(btnW, btnH);
                        btn.Location = new Point(startX + 3 * (btnW + spacing), startY + r * (btnH + spacing));
                    }
                    else if (text == "=")
                    {
                        btn.Size = new Size(btnW, btnH * 2 + spacing);
                        btn.Location = new Point(startX + 4 * (btnW + spacing), startY + r * (btnH + spacing));
                    }
                    else
                    {
                        // Các nút bình thường
                        btn.Size = new Size(btnW, btnH);
                        btn.Location = new Point(startX + c * (btnW + spacing), startY + r * (btnH + spacing));
                    }

                    btn.Click += new EventHandler(Button_Click);
                    this.Controls.Add(btn);
                }
            }
        }

        // ================= LOGIC XỬ LÝ (GIỮ NGUYÊN THEO ARTICLE 11) =================
        private void Button_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            string s = bt.Text;

            // Nhập số
            if ((char.IsDigit(s, 0) && s.Length == 1) || s == ".")
            {
                if (txtDisplay.Text == "0" && s != ".") txtDisplay.Clear();
                if (s == "." && txtDisplay.Text.Contains(".")) return;
                txtDisplay.Text += s;
            }
            // Phép tính
            else if (s == "+" || s == "-" || s == "*" || s == "/")
            {
                opr = s;
                workingMemory = decimal.Parse(txtDisplay.Text);
                txtDisplay.Text = "0";
            }
            // Kết quả
            else if (s == "=")
            {
                if (opr == "") return;
                decimal secondValue = decimal.Parse(txtDisplay.Text);
                switch (opr)
                {
                    case "+": txtDisplay.Text = (workingMemory + secondValue).ToString(); break;
                    case "-": txtDisplay.Text = (workingMemory - secondValue).ToString(); break;
                    case "*": txtDisplay.Text = (workingMemory * secondValue).ToString(); break;
                    case "/": if (secondValue != 0) txtDisplay.Text = (workingMemory / secondValue).ToString(); break;
                }
                opr = "";
            }
            // Các nút chức năng khác
            else if (s == "C") { txtDisplay.Text = "0"; workingMemory = 0; opr = ""; }
            else if (s == "CE") { txtDisplay.Text = "0"; }
            else if (s == "←")
            {
                if (txtDisplay.Text.Length > 0) txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
                if (txtDisplay.Text == "") txtDisplay.Text = "0";
            }
            else if (s == "±") { txtDisplay.Text = (-decimal.Parse(txtDisplay.Text)).ToString(); }
            else if (s == "√") { txtDisplay.Text = Math.Sqrt((double)decimal.Parse(txtDisplay.Text)).ToString(); }
            else if (s == "%") { txtDisplay.Text = (decimal.Parse(txtDisplay.Text) / 100).ToString(); }
            else if (s == "1/x") { txtDisplay.Text = (1 / decimal.Parse(txtDisplay.Text)).ToString(); }
            // Bộ nhớ
            else if (s == "MC") memory = 0;
            else if (s == "MR") txtDisplay.Text = memory.ToString();
            else if (s == "MS") { memory = decimal.Parse(txtDisplay.Text); txtDisplay.Text = "0"; }
            else if (s == "M+") memory += decimal.Parse(txtDisplay.Text);
            else if (s == "M-") memory -= decimal.Parse(txtDisplay.Text);
        }
    }
}