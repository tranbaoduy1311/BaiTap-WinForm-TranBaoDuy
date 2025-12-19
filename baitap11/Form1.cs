using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace baitap11
{
    public partial class Form1 : Form
    {
        decimal memory = 0;
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

            int btnW = 58, btnH = 50, spacing = 6, startX = 15, startY = 80;
            string[][] rows = new string[][] {
                new string[] { "MC", "MR", "MS", "M+", "M-" },
                new string[] { "←", "CE", "C", "±", "√" },
                new string[] { "7", "8", "9", "/", "%" },
                new string[] { "4", "5", "6", "*", "1/x" },
                new string[] { "1", "2", "3", "-", "=" },
                new string[] { "0", ".", "+" }
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
                        BackColor = Color.FromArgb(245, 245, 245)
                    };

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
                        btn.Size = new Size(btnW, btnH);
                        btn.Location = new Point(startX + c * (btnW + spacing), startY + r * (btnH + spacing));
                    }

                    btn.Click += new EventHandler(Button_Click);
                    this.Controls.Add(btn);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            string s = bt.Text;

            // 1. Nhập số và dấu chấm
            if ((char.IsDigit(s, 0) && s.Length == 1) || s == ".")
            {
                if (txtDisplay.Text == "0" && s != ".") txtDisplay.Text = s;
                else txtDisplay.Text += s;
            }

            // 2. Nhập phép tính (Hiện luôn lên màn hình ví dụ: 2+)
            else if (s == "+" || s == "-" || s == "*" || s == "/")
            {
                // Tránh việc nhập 2 dấu phép tính liên tiếp (ví dụ 2++)
                char lastChar = txtDisplay.Text[txtDisplay.Text.Length - 1];
                if ("+-*/".Contains(lastChar))
                {
                    txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1) + s;
                }
                else
                {
                    txtDisplay.Text += s;
                }
            }

            // 3. Xử lý dấu Bằng (=) - Phân tích chuỗi để tính toán
            else if (s == "=")
            {
                try
                {
                    string expression = txtDisplay.Text;
                    char[] operators = { '+', '-', '*', '/' };
                    int opIndex = expression.IndexOfAny(operators);

                    if (opIndex > 0)
                    {
                        string firstPart = expression.Substring(0, opIndex);
                        string secondPart = expression.Substring(opIndex + 1);
                        char op = expression[opIndex];

                        decimal v1 = decimal.Parse(firstPart);
                        decimal v2 = decimal.Parse(secondPart);
                        decimal result = 0;

                        switch (op)
                        {
                            case '+': result = v1 + v2; break;
                            case '-': result = v1 - v2; break;
                            case '*': result = v1 * v2; break;
                            case '/': if (v2 != 0) result = v1 / v2; break;
                        }
                        txtDisplay.Text = result.ToString();
                    }
                }
                catch
                {
                    txtDisplay.Text = "Error";
                }
            }

            // 4. Các nút chức năng khác
            else if (s == "C" || s == "CE") { txtDisplay.Text = "0"; }
            else if (s == "←")
            {
                if (txtDisplay.Text.Length > 1) txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
                else txtDisplay.Text = "0";
            }
            else if (s == "±")
            {
                // Đảo dấu kết quả hiện tại
                decimal val = decimal.Parse(txtDisplay.Text);
                txtDisplay.Text = (-val).ToString();
            }
            else if (s == "MC") memory = 0;
            else if (s == "MR") txtDisplay.Text = memory.ToString();
            else if (s == "MS") memory = decimal.Parse(txtDisplay.Text);
            else if (s == "M+") memory += decimal.Parse(txtDisplay.Text);
            else if (s == "M-") memory -= decimal.Parse(txtDisplay.Text);
        }
    }
}
