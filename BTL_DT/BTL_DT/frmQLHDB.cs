using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_DT
{
    public partial class frmQLHDB : Form
    {
        string strConnect = "Data Source=DESKTOP-S74IN6S\\SQLEXPRESS;" +
                "DataBase=QLDT;" +
                "Integrated Security=True";
        SqlConnection sqlConnect = null;
        //Phương thức mở kết nối
        void OpenConnect()
        {
            sqlConnect = new SqlConnection(strConnect);
            if (sqlConnect.State != ConnectionState.Open)
                sqlConnect.Open();
        }
        //Phương thức đóng kết nối
        void CloseConnect()
        {
            if (sqlConnect.State != ConnectionState.Closed)
            {
                sqlConnect.Close();
                sqlConnect.Dispose();
            }
        }
        //Phương thức thực thi câu lệnh Select trả về một DataTable
        public DataTable DataReader(string sqlSelct)
        {
            DataTable tblData = new DataTable();
            OpenConnect();
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlSelct, sqlConnect);
            sqlData.Fill(tblData);
            CloseConnect();
            return tblData;
        }
        //Phương thức thực hiện câu lệnh dạng insert,update,delete
        public void DataChange(string sql)
        {
            OpenConnect();
            SqlCommand sqlcomma = new SqlCommand();
            sqlcomma.Connection = sqlConnect;
            sqlcomma.CommandText = sql;
            sqlcomma.ExecuteNonQuery();
            CloseConnect();
        }
        private void HienChiTiet(bool hien)
        {
            txtDiaChi.Enabled = hien;
            txtDonGia.Enabled = hien;
            txtKhuyenMai.Enabled = hien;
            txtMaHD.Enabled = hien;
            txtSDT.Enabled = hien;
            txtSoLuong.Enabled = hien;
            txtTenDT.Enabled = hien;
            txtTenKH.Enabled = hien;
            txtTenNV.Enabled = hien;
            txtThanhTien.Enabled = hien;
            txtThue.Enabled = hien;           
        }


        public frmQLHDB()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
             if(MessageBox.Show("Bạn có chắc chắn muốn thoát !","thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Close();
            }    
        }

        private void frmQLHDB_Load(object sender, EventArgs e)
        {
            dgvQLHDB.DataSource = DataReader("select hoadon.MAHOADON,NGAYLAP,nhanvien.MANHANVIEN,nhanvien.HOTEN,KHACHHANG.MA_KH,KHACHHANG.HOTEN,KHACHHANG.SDT,khachhang.DIACHI,DIENTHOAI.MADIENTHOAI,DIENTHOAI.TEN_DT,DIENTHOAI.GIA,CHITIET.SOLUONG,HOADON.THUESUAT,HOADON.TRIGIA from HOADON join CHITIET on HOADON.MAHOADON=CHITIET.MAHOADON join DIENTHOAI on DIENTHOAI.MADIENTHOAI=CHITIET.MADIENTHOAI join NHANVIEN on NHANVIEN.MANHANVIEN=HOADON.MANHANVIEN join KHACHHANG on KHACHHANG.MA_KH=HOADON.MA_KH");      
            //Ẩn groupBox chi tiết
            HienChiTiet(false);

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //Cập nhật trên nhãn tiêu đề
            lblTieuDe.Text = "TÌM KIẾM MẶT HÀNG";
            //Cấm nút Sửa và Xóa
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            //Viet cau lenh SQL cho tim kiem 
            string sql = "select hoadon.MAHOADON,NGAYLAP,nhanvien.MANHANVIEN,nhanvien.HOTEN,KHACHHANG.MA_KH,KHACHHANG.HOTEN,KHACHHANG.SDT,khachhang.DIACHI,DIENTHOAI.MADIENTHOAI,DIENTHOAI.TEN_DT,DIENTHOAI.GIA,CHITIET.SOLUONG,HOADON.THUESUAT,HOADON.TRIGIA from HOADON join CHITIET on HOADON.MAHOADON=CHITIET.MAHOADON join DIENTHOAI on DIENTHOAI.MADIENTHOAI=CHITIET.MADIENTHOAI join NHANVIEN on NHANVIEN.MANHANVIEN=HOADON.MANHANVIEN join KHACHHANG on KHACHHANG.MA_KH=HOADON.MA_KH where hoadon.MAHOADON is not null ";
            //Tim theo MaSP khac rong
            if (txtTimKiemMHD.Text.Trim() != "")
            {
                sql += " and hoadon.MAHOADON like '%" + txtTimKiemMHD.Text + "%'";
            }          
            //Load dữ liệu tìm được lên dataGridView
            dgvQLHDB.DataSource = DataReader(sql);

        }

        private void txtTimKiemMHD_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvQLHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Hien thi nut sua
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            //Bắt lỗi khi người sử dụng kích linh tinh lên datagrid
            try
            {
                txtMaHD.Text = dgvQLHDB.CurrentRow.Cells[0].Value.ToString();            
                dtpNgayLap.Value = (DateTime)dgvQLHDB.CurrentRow.Cells[1].Value;          
                cboMaNV.Text = dgvQLHDB.CurrentRow.Cells[2].Value.ToString();
                txtTenNV.Text = dgvQLHDB.CurrentRow.Cells[3].Value.ToString();
                cboMaKH.Text = dgvQLHDB.CurrentRow.Cells[4].Value.ToString();
                txtTenKH.Text = dgvQLHDB.CurrentRow.Cells[5].Value.ToString();
                txtSDT.Text = dgvQLHDB.CurrentRow.Cells[6].Value.ToString();
                txtDiaChi.Text = dgvQLHDB.CurrentRow.Cells[7].Value.ToString();
                cboMaDT.Text = dgvQLHDB.CurrentRow.Cells[8].Value.ToString();
                txtTenDT.Text = dgvQLHDB.CurrentRow.Cells[9].Value.ToString();
                txtDonGia.Text = dgvQLHDB.CurrentRow.Cells[10].Value.ToString();
                txtSoLuong.Text = dgvQLHDB.CurrentRow.Cells[11].Value.ToString();
                txtThue.Text = dgvQLHDB.CurrentRow.Cells[12].Value.ToString();            
            }
            catch (Exception ex)
            {
            }

        }
    }
}
