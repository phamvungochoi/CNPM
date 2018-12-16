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
        //private string selectedMaNV;
        public FormNhanVien()
        {
            InitializeComponent();
            nvContext = new NhanVienBUS();
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

    }
}

