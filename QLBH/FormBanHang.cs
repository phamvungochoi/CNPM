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
    public partial class FormBanHang : Form
    {
        private readonly KhoBUS kContext;
        private DataTable tb = new DataTable();
        void CreateColumn(DataTable tbOrder)
        {
            tbOrder.Columns.Add("MaHang");
            tbOrder.Columns.Add("TenHang");
            tbOrder.Columns.Add("SoLuong");
            tbOrder.Columns.Add("GiaTien");
            tbOrder.PrimaryKey = new DataColumn[] { tbOrder.Columns["MaHang"] };
        }
        public FormBanHang()
        {
            InitializeComponent();
            kContext = new KhoBUS();
            dgvKho.DataSource = kContext.LayDanhSach();
            CreateColumn(tb);
            dgvOrder.DataSource = tb;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvKho_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKho.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvKho.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvKho.Rows[selectedrowindex];
                txtMaHang.Text = selectedRow.Cells[0].Value.ToString().Trim();
                txtTenHang.Text = selectedRow.Cells[1].Value.ToString();
                txtGiaTien.Text = selectedRow.Cells[4].Value.ToString();
            }
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            
            int kt = 0;
            int tongtien = 0;
            foreach (DataRow a in tb.Rows)
                if (txtMaHang.Text == a["MaHang"].ToString())
                {
                    a["SoLuong"] = (int.Parse(a["SoLuong"].ToString()) + int.Parse(txtSoLuong.Text)).ToString();
                    kt = 1;
                }
            if (kt == 0)
            {
                DataRow r = tb.NewRow();
                tb.Rows.Add(txtMaHang.Text,txtTenHang.Text, txtSoLuong.Text , txtGiaTien.Text);
            }
            foreach (DataRow a in tb.Rows)
            {
                tongtien += int.Parse(a["SoLuong"].ToString()) * int.Parse(a["GiaTien"].ToString());
                txtTongTien.Text = tongtien.ToString();           
            }       
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtTienNhan.Text != null)
                txtTienThua.Text = (int.Parse(txtTienNhan.Text) - int.Parse(txtTongTien.Text)).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new FormKhachHang();
            frm.Show();
        }
    }
}
