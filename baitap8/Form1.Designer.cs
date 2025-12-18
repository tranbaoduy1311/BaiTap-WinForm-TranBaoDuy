namespace baitap8
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.x = new System.Windows.Forms.Label();
            this.y = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSoX = new System.Windows.Forms.TextBox();
            this.tbSoY = new System.Windows.Forms.TextBox();
            this.tbKetQua = new System.Windows.Forms.TextBox();
            this.btCong = new System.Windows.Forms.Button();
            this.btNhan = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // x
            // 
            this.x.AutoSize = true;
            this.x.Location = new System.Drawing.Point(143, 48);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(16, 20);
            this.x.TabIndex = 0;
            this.x.Text = "x";
            // 
            // y
            // 
            this.y.AutoSize = true;
            this.y.Location = new System.Drawing.Point(143, 106);
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(16, 20);
            this.y.TabIndex = 1;
            this.y.Text = "y";
            this.y.Click += new System.EventHandler(this.y_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "kết quả ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbSoX
            // 
            this.tbSoX.Location = new System.Drawing.Point(212, 48);
            this.tbSoX.Name = "tbSoX";
            this.tbSoX.Size = new System.Drawing.Size(100, 26);
            this.tbSoX.TabIndex = 3;
            // 
            // tbSoY
            // 
            this.tbSoY.Location = new System.Drawing.Point(212, 106);
            this.tbSoY.Name = "tbSoY";
            this.tbSoY.Size = new System.Drawing.Size(100, 26);
            this.tbSoY.TabIndex = 4;
            // 
            // tbKetQua
            // 
            this.tbKetQua.Location = new System.Drawing.Point(185, 156);
            this.tbKetQua.Multiline = true;
            this.tbKetQua.Name = "tbKetQua";
            this.tbKetQua.ReadOnly = true;
            this.tbKetQua.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbKetQua.Size = new System.Drawing.Size(147, 74);
            this.tbKetQua.TabIndex = 5;
            // 
            // btCong
            // 
            this.btCong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCong.Location = new System.Drawing.Point(406, 51);
            this.btCong.Name = "btCong";
            this.btCong.Size = new System.Drawing.Size(75, 23);
            this.btCong.TabIndex = 6;
            this.btCong.Text = "Cộng";
            this.btCong.UseVisualStyleBackColor = true;
            this.btCong.Click += new System.EventHandler(this.btCong_Click);
            // 
            // btNhan
            // 
            this.btNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNhan.Location = new System.Drawing.Point(406, 102);
            this.btNhan.Name = "btNhan";
            this.btNhan.Size = new System.Drawing.Size(75, 23);
            this.btNhan.TabIndex = 7;
            this.btNhan.Text = "Nhân";
            this.btNhan.UseVisualStyleBackColor = true;
            this.btNhan.Click += new System.EventHandler(this.btNhan_Click);
            // 
            // btThoat
            // 
            this.btThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThoat.Location = new System.Drawing.Point(406, 171);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 23);
            this.btThoat.TabIndex = 8;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // btLuu
            // 
            this.btLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btLuu.Location = new System.Drawing.Point(406, 231);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(75, 23);
            this.btLuu.TabIndex = 9;
            this.btLuu.Text = "Lưu";
            this.btLuu.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btNhan);
            this.Controls.Add(this.btCong);
            this.Controls.Add(this.tbKetQua);
            this.Controls.Add(this.tbSoY);
            this.Controls.Add(this.tbSoX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.y);
            this.Controls.Add(this.x);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label x;
        private System.Windows.Forms.Label y;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSoX;
        private System.Windows.Forms.TextBox tbSoY;
        private System.Windows.Forms.TextBox tbKetQua;
        private System.Windows.Forms.Button btCong;
        private System.Windows.Forms.Button btNhan;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Button btLuu;
    }
}

