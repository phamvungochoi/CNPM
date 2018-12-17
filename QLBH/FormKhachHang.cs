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
    public partial class FormKhachHang : Form
    {
        private readonly KhachHangBUS khContext;
        private string message;
        void Enable(bool Edit)
        {
            btnHuy.Enabled = Edit;
            btnLuu.Enabled = Edit;
            btnThem.Enabled = !Edit;
            btnSua.Enabled = !Edit;
            btnXoa.Enabled = !Edit;
        }
        public FormKhachHang()
        {
            InitializeComponent();
            khContext = new KhachHangBUS();
            Enable(false);
            dgvKhachHang.DataSource = khContext.LayDanhSach();
        }
        public bool Check()
        {
            message = "";
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                message += "Vui lòng nhập tên.\n";
            }
            if (string.IsNullOrWhiteSpace(txtMaTV.Text))
            {
                message += "Vui lòng nhập mã nhân viên.\n";
            }
            return message == "" ? true : false;
        }
        private bool CheckMaTV()
        {
            for (int i = 0; i < dgvKhachHang.Rows.Count; i++)
            {
                if (txtMaTV.Text == dgvKhachHang.Rows[i].Cells[0].Value.ToString())
                {


                    message += "Mã đã tồn tại.\n";
                    return false;
                }
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (Check() && CheckMaTV())
            {
                var n = new KhachHang
                {
                    HoTen = txtHoTen.Text.Trim(),
                    MaTV = txtMaTV.Text,
                    GioiTinh = chkNu.Checked ? true : false,
                    DienThoai = txtDienThoai.Text,
                    DiaChi = txtDiaChi.Text,
                    Email = txtEmail.Text,
                };
                if (khContext.ThemKH(n))
                {
                    MessageBox.Show((txtHoTen.Text.Trim()) + "Đã thêm");
                    dgvKhachHang.DataSource = khContext.LayDanhSach();
                }
                else
                    MessageBox.Show((txtHoTen.Text.Trim()) + "Thêm thất bại. Vui lòng thử lại");
            }
            else
                MessageBox.Show(message);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                var n = new KhachHang
                {
                    HoTen = txtHoTen.Text.Trim(),
                    MaTV = txtMaTV.Text,
                    GioiTinh = chkNu.Checked ? true : false,
                    DienThoai = txtDienThoai.Text,
                    DiaChi = txtDiaChi.Text,
                    Email = txtEmail.Text,
                };
                string ten = txtHoTen.Text.Trim();
                if (khContext.SuaKH(n))
                {
                    MessageBox.Show(ten + " . Đã sửa.");
                    dgvKhachHang.DataSource = khContext.LayDanhSach();
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
                string ma = txtMaTV.Text;
                if (khContext.XoaKH(ma))
                {
                    MessageBox.Show(ma + " Đã xoá.");
                    dgvKhachHang.DataSource = khContext.LayDanhSach();
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

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvKhachHang.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvKhachHang.Rows[selectedrowindex];
                txtMaTV.Text = selectedRow.Cells[0].Value.ToString().Trim();
                txtHoTen.Text = selectedRow.Cells[1].Value.ToString();
                chkNu.Checked = selectedRow.Cells[2].Value.ToString() == "Nữ" ? true : false;
                txtDiaChi.Text = selectedRow.Cells[3].Value.ToString();
                txtEmail.Text = selectedRow.Cells[4].Value.ToString().Trim();
                txtDienThoai.Text = selectedRow.Cells[5].Value.ToString().Trim();
            }
        }

        private void chkNam_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNu.Checked)
            {
                chkNam.Checked = false;

            }
            else
                chkNam.Checked = true;
        }
    }
}
