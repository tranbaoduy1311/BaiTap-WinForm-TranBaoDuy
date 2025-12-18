using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace baitap2
{
    public partial class Form1 : Form
    {
        string path = "form2.xml";

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
            catch (Exception ex) { MessageBox.Show("Lỗi ghi: " + ex.Message); }
        }

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
            catch (Exception ex)
            {
                return null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InfoWindows iw = Read();
            if (iw != null) 
            {
                this.Width = iw.Width;
                this.Height = iw.Height;
                this.Text = "Đã khôi phục kích thước cũ: " + iw.Width + "x" + iw.Height;
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            Write(iw);
            this.Text = "Đã lưu kích thước mới: " + iw.Width + "x" + iw.Height;
        }
    }
}