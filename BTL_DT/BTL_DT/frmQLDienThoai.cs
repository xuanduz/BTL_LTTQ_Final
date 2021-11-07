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
        private void HienChiTiet(bool hien)
        {
            txtMaDT.Enabled = hien;
            txtTenDT.Enabled = hien;
            txtSoIMEI.Enabled = hien;
            txtMau.Enabled = hien;
            txtGia.Enabled = hien;
            txtBaoHanh.Enabled = hien;
            rtbBoNho.Enabled = hien;
            rtbManHinh.Enabled = hien;
            rtbCamera.Enabled = hien;
            rtbGhiChu.Enabled = hien;
            rtbHDH_CPU.Enabled = hien;
            
            //Ẩn hiện 2 nút Lưu và Hủy
            btnLuu.Enabled = hien;
            btnHuy.Enabled = hien;
        }

        private void frmQLDienThoai_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(1000, 700);
            dgvDSDT.DataSource = dtbase.DataReader("select * from DIENTHOAI");
            this.dgvDSDT.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9);
            dgvDSDT.Columns[0].Width = 50;
            dgvDSDT.Columns[3].Width = 80;
            dgvDSDT.Columns[8].Width = 100;
            dgvDSDT.Columns[9].Width = 50;
            dgvDSDT.Columns[11].Width = 80;
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

            string sql = "SELECT * FROM DIENTHOAI where MADT is not null ";

            if (txtMaDT_Search.Text.Trim() != "")
            {
                sql += " and MADT like '%" + txtMaDT_Search.Text + "%'";
            }

            if (txtTenDT_Search.Text.Trim() != "")
            {
                sql += " AND TENDT like N'%" + txtTenDT_Search.Text + "%'";
            }
            dgvDSDT.DataSource = dtbase.DataReader(sql);
        }

        private void dgvDSDT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            HienChiTiet(false);
            try
            {
                txtMaDT.Text = dgvDSDT.CurrentRow.Cells[0].Value.ToString();
                txtTenDT.Text = dgvDSDT.CurrentRow.Cells[1].Value.ToString();
                txtSoIMEI.Text = dgvDSDT.CurrentRow.Cells[2].Value.ToString();
                txtMau.Text = dgvDSDT.CurrentRow.Cells[3].Value.ToString();
                txtGia.Text = dgvDSDT.CurrentRow.Cells[8].Value.ToString();
                txtBaoHanh.Text = dgvDSDT.CurrentRow.Cells[9].Value.ToString();
                rtbBoNho.Text = dgvDSDT.CurrentRow.Cells[7].Value.ToString();
                rtbManHinh.Text = dgvDSDT.CurrentRow.Cells[4].Value.ToString();
                rtbCamera.Text = dgvDSDT.CurrentRow.Cells[6].Value.ToString();
                rtbGhiChu.Text = dgvDSDT.CurrentRow.Cells[10].Value.ToString();
                rtbHDH_CPU.Text = dgvDSDT.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }
    }
}
