using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CSLab06
{
    public partial class frmXuat : Form
    {
        public const int KichThuocToiDa = 50;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SoDong { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SoCot { get; set; }

        // Kích thước và khoảng cách theo mục 2.3 của đề.
        private readonly int h = 35;
        private readonly int margin = 5;
        private Button[,] mangButton;

        // Constructor không tham số phục vụ Windows Forms Designer; mặc định 1 × 1.
        public frmXuat()
        {
            InitializeComponent();
            SoDong = 1;
            SoCot = 1;
        }

        public frmXuat(int dong, int cot) : this()
        {
            KiemTraKichThuoc(dong, cot);
            SoDong = dong;
            SoCot = cot;
        }

        private static void KiemTraKichThuoc(int dong, int cot)
        {
            if (dong < 1 || dong > KichThuocToiDa)
                throw new ArgumentOutOfRangeException("dong", "Số dòng phải từ 1 đến 50.");
            if (cot < 1 || cot > KichThuocToiDa)
                throw new ArgumentOutOfRangeException("cot", "Số cột phải từ 1 đến 50.");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            if (mangButton != null) return;
            KiemTraKichThuoc(SoDong, SoCot);
            TaoMangButton();
        }

        private void TaoMangButton()
        {
            mangButton = new Button[SoDong, SoCot];
            panelContainer.SuspendLayout();
            try
            {
                for (int i = 0; i < SoDong; i++)
                {
                    for (int j = 0; j < SoCot; j++)
                    {
                        Button btn = new Button();
                        btn.Name = "btn_" + i + "_" + j;
                        btn.Width = h;
                        btn.Height = h;
                        btn.Left = margin * (j + 1) + h * j;
                        btn.Top = margin * (i + 1) + h * i;
                        btn.Text = (i * SoCot + j + 1).ToString();
                        // Chỉ số dòng/cột bắt đầu từ 0, giống mã mẫu trong đề.
                        btn.Tag = string.Format("Dòng {0} cột {1}", i, j);
                        btn.TabIndex = i * SoCot + j;
                        btn.UseVisualStyleBackColor = true;
                        btn.Click += btn_Click;
                        btn.MouseHover += HoChuotLenButton;
                        btn.MouseEnter += HoChuotLenButton;
                        mangButton[i, j] = btn;
                        panelContainer.Controls.Add(btn);
                    }
                }
                panelContainer.AutoScrollMinSize = new Size(
                    SoCot * (h + margin) + margin,
                    SoDong * (h + margin) + margin);
            }
            finally
            {
                panelContainer.ResumeLayout(true);
            }

            // Giữ công thức của đề; giới hạn cửa sổ theo màn hình, mảng lớn dùng thanh cuộn.
            Rectangle screen = Screen.FromControl(this).WorkingArea;
            int width = Math.Max(260, Math.Max(SoCot * (h + margin + 1), panelContainer.AutoScrollMinSize.Width));
            int height = Math.Max(100, Math.Max(SoDong * (h + margin + 1), panelContainer.AutoScrollMinSize.Height) + statusStrip.Height);
            ClientSize = new Size(Math.Min(width, Math.Max(260, screen.Width - 80)),
                                  Math.Min(height, Math.Max(100, screen.Height - 120)));
            Text = string.Format("Xuất mảng - {0} dòng × {1} cột", SoDong, SoCot);
            lblStatus.Text = (SoDong * SoCot) + " nút · Rê chuột xem vị trí";
        }

        private void HoChuotLenButton(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;
            Text = btn.Tag.ToString();
            lblStatus.Text = btn.Tag + " · Giá trị: " + btn.Text;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;
            MessageBox.Show(this, btn.Text, "Giá trị Button", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
