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
    public partial class FormKho : Form
    {
        private readonly KhoBUS kContext;
        private string message;
        void Enable(bool Edit)
        {
            btnHuy.Enabled = Edit;
            btnLuu.Enabled = Edit;
            btnThem.Enabled = !Edit;
            btnSua.Enabled = !Edit;
            btnXoa.Enabled = !Edit;
        }
        public FormKho()
        {
            InitializeComponent();
            kContext = new KhoBUS();
            Enable(false);
            dgvKho.DataSource = kContext.LayDanhSach();
        }
        public bool Check()
        {
            message = "";
            if (string.IsNullOrWhiteSpace(txtTenHang.Text))
            {
                message += "Vui lòng nhập tên.\n";
            }
            if (string.IsNullOrWhiteSpace(txtMaHang.Text))
            {
                message += "Vui lòng nhập mã nhân viên.\n";
            }
            return message == "" ? true : false;
        }
        private bool CheckMaHH()
        {
            for (int i = 0; i < dgvKho.Rows.Count; i++)
            {
                if (txtMaHang.Text == dgvKho.Rows[i].Cells[0].Value.ToString())
                {


                    message += "Mã đã tồn tại.\n";
                    return false;
                }
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (Check() && CheckMaHH())
            {
                var n = new HangHoa
                {
                    TenHang = txtTenHang.Text.Trim(),
                    MaHang = txtMaHang.Text,
                    MaDVT = txtMaDVT.Text,
                    SoLuong = int.Parse(txtSoLuong.Text),
                    GiaBan = double.Parse(txtGiaBan.Text),
                    MaNCC = txtMaNCC.Text,
                    NgayNhap = dtpNgayNhap.Value,
                    TinhTrang = txtTinhTrang.Text,
                };
                if (kContext.ThemHH(n))
                {
                    MessageBox.Show((txtTenHang.Text.Trim()) + "Đã thêm");
                    dgvKho.DataSource = kContext.LayDanhSach();
                }
                else
                    MessageBox.Show((txtTenHang.Text.Trim()) + "Thêm thất bại. Vui lòng thử lại");
            }
            else
                MessageBox.Show(message);
        }

        private void dgvKho_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKho.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvKho.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvKho.Rows[selectedrowindex];
                txtMaHang.Text = selectedRow.Cells[0].Value.ToString().Trim();
                txtTenHang.Text = selectedRow.Cells[1].Value.ToString();
                txtMaDVT.Text = selectedRow.Cells[2].Value.ToString().Trim();
                txtSoLuong.Text = selectedRow.Cells[3].Value.ToString();
                txtGiaBan.Text = selectedRow.Cells[4].Value.ToString();
                txtMaNCC.Text = selectedRow.Cells[5].Value.ToString();
                dtpNgayNhap.Value = DateTime.Parse(selectedRow.Cells[6].Value.ToString());
                txtTinhTrang.Text = selectedRow.Cells[7].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                var n = new HangHoa
                {
                    TenHang = txtTenHang.Text.Trim(),
                    MaHang = txtMaHang.Text,
                    MaDVT = txtMaDVT.Text,
                    SoLuong = int.Parse(txtSoLuong.Text),
                    GiaBan = double.Parse(txtGiaBan.Text),
                    MaNCC = txtMaNCC.Text,
                    NgayNhap = dtpNgayNhap.Value,
                    TinhTrang = txtTinhTrang.Text,
                };
                string ten = txtTenHang.Text.Trim();
                if (kContext.SuaHH(n))
                {
                    MessageBox.Show(ten + " . Đã sửa.");
                    dgvKho.DataSource = kContext.LayDanhSach();
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
                string ma = txtMaHang.Text;
                if (kContext.XoaHH(ma))
                {
                    MessageBox.Show(ma + " Đã xoá.");
                    dgvKho.DataSource = kContext.LayDanhSach();
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
    }
}
