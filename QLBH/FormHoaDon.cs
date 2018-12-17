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
    public partial class FormHoaDon : Form
    {
        private readonly HoaDonBUS hdContext;
        private string message;
        void Enable(bool Edit)
        {
            btnHuy.Enabled = Edit;
        }
        public FormHoaDon()
        {
            InitializeComponent();
            hdContext = new HoaDonBUS();
            Enable(false);
            dgvHoaDon.DataSource = hdContext.LayDanhSach();
        }

        private void chkIn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuaIn.Checked)
            {
                chkIn.Checked = false;

            }
            else
                chkIn.Checked = true;
        }

        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvHoaDon.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvHoaDon.Rows[selectedrowindex];
                txtMaHD.Text = selectedRow.Cells[0].Value.ToString();
                txtMaNV.Text = selectedRow.Cells[1].Value.ToString();
                dtpThoiGian.Value = DateTime.Parse(selectedRow.Cells[2].Value.ToString());
                txtThanhTien.Text = selectedRow.Cells[3].Value.ToString();
                chkChuaIn.Checked = selectedRow.Cells[4].Value.ToString() == "Chưa In" ? true : false;
                txtMaTV.Text = selectedRow.Cells[5].Value.ToString();
                txtNote.Text = selectedRow.Cells[6].Value.ToString().Trim();
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
