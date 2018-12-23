using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using BLL;
namespace QLBH
{
    public partial class FormNhanVien : Form
    {
        private readonly NhanVienBUS nvContext;
        private string message;
        void Enable(bool Edit)
        {
            btnHuy.Enabled = Edit;
            btnLuu.Enabled = Edit;
            btnThem.Enabled = !Edit;
            btnSua.Enabled = !Edit;
            btnXoa.Enabled = !Edit;
        }
        public FormNhanVien()
        {
            InitializeComponent();
            nvContext = new NhanVienBUS();
            Enable(false);
            dgvNhanVien.DataSource = nvContext.LayDanhSach();
        }
        public bool Check()
        {
            message = "";
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                message += "Vui lòng nhập tên.\n";
            }
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                message += "Vui lòng nhập mã nhân viên.\n";
            }
            return message == "" ? true : false;
        }
        private bool CheckMaNV()
        {
            for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
            {
                if (txtMaNV.Text == dgvNhanVien.Rows[i].Cells[0].Value.ToString())
                {


                    message += "Mã đã tồn tại.\n";
                    return false;
                }
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Enable(true);
            if (dgvNhanVien.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvNhanVien.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvNhanVien.Rows[selectedrowindex];
                txtMaNV.Text = null;
                txtHoTen.Text = null;
                txtMaCV.Text = null;
                dtpNgaySinh.Value = DateTime.Parse(selectedRow.Cells[3].Value.ToString());
                chkNu.Checked = selectedRow.Cells[4].Value.ToString() == "Nữ" ? true : false;
                txtCMND.Text = null;
                txtQueQuan.Text = null;
                txtSDT.Text = null;
                txtDiaChi.Text = null;
            }

        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvNhanVien.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvNhanVien.Rows[selectedrowindex];
                txtMaNV.Text = selectedRow.Cells[0].Value.ToString().Trim();        
                txtHoTen.Text = selectedRow.Cells[1].Value.ToString();
                txtMaCV.Text = selectedRow.Cells[2].Value.ToString().Trim();
                dtpNgaySinh.Value = DateTime.Parse(selectedRow.Cells[3].Value.ToString());
                chkNu.Checked = selectedRow.Cells[4].Value.ToString() == "Nữ" ? true : false;
                txtCMND.Text = selectedRow.Cells[5].Value.ToString().Trim();
                txtQueQuan.Text = selectedRow.Cells[6].Value.ToString().Trim();
                txtSDT.Text = selectedRow.Cells[7].Value.ToString().Trim();
                txtDiaChi.Text = selectedRow.Cells[8].Value.ToString();
            }
        }
        private void chkGioiTinh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNu.Checked)
            {
                chkNam.Checked = false;

            }
            else
                chkNam.Checked = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                var n = new NhanVien
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = chkNu.Checked ? true : false,
                    NgaySinh = dtpNgaySinh.Value,
                    CMND = txtCMND.Text,
                    QueQuan = txtQueQuan.Text,
                    SDT = txtSDT.Text,
                    DiaChi = txtDiaChi.Text,
                    MaCV = txtMaCV.Text,
                };
                string ten = txtHoTen.Text.Trim();
                if (nvContext.SuaNV(n))
                {
                    MessageBox.Show(ten + " . Đã sửa.");
                    dgvNhanVien.DataSource = nvContext.LayDanhSach();
                }
                else
                    MessageBox.Show(ten + "Sửa thất bại. Vui lòng thử lại.");
            }
            else
                MessageBox.Show(message);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                string ma = txtMaNV.Text;
                if (nvContext.XoaNV(ma))
                {
                    MessageBox.Show(ma + " Đã xoá.");
                    dgvNhanVien.DataSource = nvContext.LayDanhSach();
                }
                else
                    MessageBox.Show(ma + " Xoá thất bại. Vui lòng thử lại!");
            }
            else
                MessageBox.Show(message);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Check() && CheckMaNV())
            {
                var n = new NhanVien
                {
                    HoTen = txtHoTen.Text.Trim(),
                    MaNV = txtMaNV.Text,
                    GioiTinh = chkNu.Checked ? true : false,
                    NgaySinh = dtpNgaySinh.Value,
                    CMND = txtCMND.Text,
                    QueQuan = txtQueQuan.Text,
                    SDT = txtSDT.Text,
                    DiaChi = txtDiaChi.Text,
                    MaCV = txtMaCV.Text,
                };
                if (nvContext.ThemNV(n))
                {
                    MessageBox.Show((txtHoTen.Text.Trim()) + "Đã thêm");
                    dgvNhanVien.DataSource = nvContext.LayDanhSach();
                }
                else
                    MessageBox.Show((txtHoTen.Text.Trim()) + "Thêm thất bại. Vui lòng thử lại");
            }
            else
                MessageBox.Show(message);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Enable(false);
            dgvNhanVien_SelectionChanged(sender, e);
        }
    }
}

