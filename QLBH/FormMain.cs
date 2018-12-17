using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QLBH
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var frm = new FormNhanVien();
            frm.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var frm = new FormKhachHang();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var frm = new FormKho();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new FormBanHang();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new FormHoaDon();
            frm.Show();
        }
    }
}
