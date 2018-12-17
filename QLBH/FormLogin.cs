using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
namespace QLBH
{
    public partial class FormLogin : Form
    {
        public bool Result { get; private set; }
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "admin" && txtMatKhau.Text == "admin")
            {
                Result = true;
                Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại.\nTài khoản hoặc mật khẩu bị sai.");
            }
        }

    }
} 
