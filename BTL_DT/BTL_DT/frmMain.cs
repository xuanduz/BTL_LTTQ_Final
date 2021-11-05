using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_DT
{
    public partial class frmMain : MetroFramework.Forms.MetroForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(1000, 600);
        }

        private void metroProgressSpinner1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            frmQLDienThoai frm = new frmQLDienThoai();
            frm.Show();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            frmQLHDB frm = new frmQLHDB();          
            frm.Show();
        }
    }
}
