using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace baitap1
{
    public partial class Form1 : Form
    {
        string path = @"D:\form.xml";

        public Form1()
        {
            InitializeComponent();
        }

        public void Write(InfoWindows iw)
        {
            try
            {
                XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
                StreamWriter file = new StreamWriter(path);
                writer.Serialize(file, iw);
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lưu file: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            Write(iw); 
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            Write(iw); 

            this.Text = "Đã lưu kích thước: " + iw.Width + "x" + iw.Height;
        }
    }
}