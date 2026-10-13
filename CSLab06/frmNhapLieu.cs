using System;
using System.Windows.Forms;

namespace CSLab06
{
    public partial class frmNhapLieu : Form
    {
        public frmNhapLieu()
        {
            InitializeComponent();
        }

        // Theo mục 2.4: không chuyển được sang số nguyên thì dùng giá trị 1.
        private bool DocKichThuoc(TextBox input, string ten, out int value)
        {
            if (!int.TryParse(input.Text, out value)) value = 1;
            if (value < 1 || value > frmXuat.KichThuocToiDa)
            {
                errorProvider.SetError(input, ten + " phải từ 1 đến " + frmXuat.KichThuocToiDa + ".");
                input.Focus();
                input.SelectAll();
                return false;
            }
            input.Text = value.ToString();
            return true;
        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            int sodong, socot;
            if (!DocKichThuoc(txtSoDong, "Số dòng", out sodong)) return;
            if (!DocKichThuoc(txtSoCot, "Số cột", out socot)) return;

            // Truyền dữ liệu giữa hai form thông qua constructor.
            using (frmXuat frmX = new frmXuat(sodong, socot))
            {
                frmX.StartPosition = FormStartPosition.CenterParent;
                frmX.ShowDialog(this);
            }
        }
    }
}
