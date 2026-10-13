namespace CSLab06
{
    partial class frmNhapLieu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSoDong;
        private System.Windows.Forms.Label lblSoCot;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.TextBox txtSoDong;
        private System.Windows.Forms.TextBox txtSoCot;
        private System.Windows.Forms.Button btnKhoiTao;
        private System.Windows.Forms.ErrorProvider errorProvider;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSoDong = new System.Windows.Forms.Label();
            this.lblSoCot = new System.Windows.Forms.Label();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.txtSoDong = new System.Windows.Forms.TextBox();
            this.txtSoCot = new System.Windows.Forms.TextBox();
            this.btnKhoiTao = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(24, 76, 120);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(480, 64);
            this.lblTitle.Text = "LAB 06 · MẢNG BUTTON";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSoDong.AutoSize = true;
            this.lblSoDong.Location = new System.Drawing.Point(30, 93);
            this.lblSoDong.Name = "lblSoDong";
            this.lblSoDong.Text = "Số &dòng:";
            this.lblSoDong.TabIndex = 0;
            this.txtSoDong.Location = new System.Drawing.Point(120, 89);
            this.txtSoDong.Name = "txtSoDong";
            this.txtSoDong.Size = new System.Drawing.Size(120, 25);
            this.txtSoDong.TabIndex = 1;
            this.txtSoDong.Text = "3";
            this.lblSoCot.AutoSize = true;
            this.lblSoCot.Location = new System.Drawing.Point(30, 139);
            this.lblSoCot.Name = "lblSoCot";
            this.lblSoCot.Text = "Số &cột:";
            this.lblSoCot.TabIndex = 2;
            this.txtSoCot.Location = new System.Drawing.Point(120, 135);
            this.txtSoCot.Name = "txtSoCot";
            this.txtSoCot.Size = new System.Drawing.Size(120, 25);
            this.txtSoCot.TabIndex = 3;
            this.txtSoCot.Text = "4";
            this.btnKhoiTao.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnKhoiTao.ForeColor = System.Drawing.Color.White;
            this.btnKhoiTao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhoiTao.FlatAppearance.BorderSize = 0;
            this.btnKhoiTao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKhoiTao.Location = new System.Drawing.Point(276, 89);
            this.btnKhoiTao.Name = "btnKhoiTao";
            this.btnKhoiTao.Size = new System.Drawing.Size(174, 71);
            this.btnKhoiTao.TabIndex = 4;
            this.btnKhoiTao.Text = "&Khởi tạo form";
            this.btnKhoiTao.UseVisualStyleBackColor = false;
            this.btnKhoiTao.Click += new System.EventHandler(this.btnKhoiTao_Click);
            this.lblHuongDan.ForeColor = System.Drawing.Color.FromArgb(80, 96, 112);
            this.lblHuongDan.Location = new System.Drawing.Point(30, 184);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(420, 65);
            this.lblHuongDan.Text = "Nhập từ 1 đến 50 dòng/cột. Nhấn Enter để tạo mảng.\r\nÔ trống hoặc không phải số nguyên sẽ được đặt thành 1.\r\nVí dụ trong đề: 3 dòng × 4 cột → 12 nút.";
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.AcceptButton = this.btnKhoiTao;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(480, 264);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSoDong);
            this.Controls.Add(this.txtSoDong);
            this.Controls.Add(this.lblSoCot);
            this.Controls.Add(this.txtSoCot);
            this.Controls.Add(this.btnKhoiTao);
            this.Controls.Add(this.lblHuongDan);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmNhapLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập liệu - CSLab06";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
