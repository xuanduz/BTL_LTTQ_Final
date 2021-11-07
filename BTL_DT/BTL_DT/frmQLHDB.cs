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
    public partial class frmQLHDB : MetroFramework.Forms.MetroForm
    {
        //string strConnect = "Data Source=DESKTOP-S74IN6S\\SQLEXPRESS;" +
        //        "DataBase=QLDT;" +
        //        "Integrated Security=True";
        string strConnect = "Data Source=NGUYENDUC;Initial Catalog=DienThoai;Integrated Security=True";
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
                //this.Close();
                this.Hide();
                frmMain frm = new frmMain();
                frm.Show();
            }    
        }

        private void frmQLHDB_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(1200, 600);
            dgvQLHDB.DataSource = DataReader("select hoadon.MAHOADON,NGAYLAP,nhanvien.MANHANVIEN,nhanvien.HOTEN,KHACHHANG.MA_KH,KHACHHANG.HOTEN,KHACHHANG.SDT,khachhang.DIACHI,DIENTHOAI.MADIENTHOAI,DIENTHOAI.TEN_DT,DIENTHOAI.GIA,CHITIET.SOLUONG,HOADON.THUESUAT,HOADON.TRIGIA from HOADON join CHITIET on HOADON.MAHOADON=CHITIET.MAHOADON join DIENTHOAI on DIENTHOAI.MADIENTHOAI=CHITIET.MADIENTHOAI join NHANVIEN on NHANVIEN.MANHANVIEN=HOADON.MANHANVIEN join KHACHHANG on KHACHHANG.MA_KH=HOADON.MA_KH");      
            //Ẩn groupBox chi tiết
            HienChiTiet(false);

        }
    }
}
