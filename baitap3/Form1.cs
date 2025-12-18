using System;
using System.Drawing; // Thêm thư viện đồ họa
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace baitap3
{
    public partial class Form1 : Form
    {
        // Lưu file tên form3.xml
        string path = "form3.xml";

        public Form1()
        {
            InitializeComponent();
        }

        // 1. Hàm GHI
        public void Write(InfoWindows iw)
        {
            try
            {
                XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
                StreamWriter file = new StreamWriter(path);
                writer.Serialize(file, iw);
                file.Close();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi ghi: " + ex.Message); }
        }

        // 2. Hàm ĐỌC
        public InfoWindows Read()
        {
            try
            {
                if (!File.Exists(path)) return null;

                XmlSerializer reader = new XmlSerializer(typeof(InfoWindows));
                StreamReader file = new StreamReader(path);
                InfoWindows iw = (InfoWindows)reader.Deserialize(file);
                file.Close();
                return iw;
            }
            catch (Exception ex) { return null; }
        }

        // 3. Sự kiện khi MỞ Form (Load) -> Khôi phục kích thước VÀ vị trí
        private void Form1_Load(object sender, EventArgs e)
        {
            InfoWindows iw = Read();
            if (iw != null)
            {
                this.Width = iw.Width;
                this.Height = iw.Height;

                // Đây là dòng quan trọng của bài 3: Khôi phục vị trí
                this.Location = iw.Location;

                // Đặt tiêu đề để kiểm tra
                this.Text = $"Đã mở lại tại: X={iw.Location.X}, Y={iw.Location.Y}";
            }
        }

        // 4. Sự kiện khi TẮT Form (FormClosing) -> Lưu tất cả lại
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            InfoWindows iw = new InfoWindows();

            // Lấy kích thước hiện tại
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;

            // Lấy vị trí hiện tại (Bài 3 yêu cầu cái này)
            iw.Location = this.Location;

            // Ghi ra file
            Write(iw);
        }
    }
}