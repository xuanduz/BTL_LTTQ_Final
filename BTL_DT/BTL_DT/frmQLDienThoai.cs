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
    public partial class frmQLDienThoai : MetroFramework.Forms.MetroForm
    {
        DataBaseProcess dtbase = new DataBaseProcess();

        public frmQLDienThoai()
        {
            InitializeComponent();
        }


        private void frmQLDienThoai_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(1000, 700);
            dgvDSDT.DataSource = dtbase.DataReader("select * from DIENTHOAI");
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            string sql = "SELECT * FROM DIENTHOAI where MADIENTHOAI is not null ";

            if (txtMaDT_Search.Text.Trim() != "")
            {
                sql += " and MADIENTHOAI like '%" + txtMaDT_Search.Text + "%'";
            }

            if (txtTenDT_Search.Text.Trim() != "")
            {
                sql += " AND TEN_DT like N'%" + txtTenDT_Search.Text + "%'";
            }
            dgvDSDT.DataSource = dtbase.DataReader(sql);
        }
    }
}
