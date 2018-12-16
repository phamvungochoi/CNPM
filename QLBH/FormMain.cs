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
            //Thread t = new Thread(new ThreadStart(Login));
            //t.Start();
            InitializeComponent();
        }
        //public void Login()
        //{
        //    Application.Run(new FormLogin());
        //}

        private void button4_Click(object sender, EventArgs e)
        {
            var frm = new FormNhanVien();
            frm.Show();

        }
    }
}
