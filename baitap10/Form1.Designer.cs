namespace baitap10
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Nếu file này báo lỗi ở hàm Dispose, chúng ta sẽ tạm để trống 
        // vì chúng ta đang quản lý giao diện bằng code tay ở file chính.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 553);
            this.Name = "Form1";
            this.Text = "To-Do List";
            this.ResumeLayout(false);
        }
    }
}