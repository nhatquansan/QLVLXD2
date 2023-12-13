using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlyvatlieuxaydung
{
  
    public partial class frmThongTinTaiKhoan : Form
    {
        DataTable dt_login = new DataTable();
        DBConnect db = new DBConnect();
        public frmThongTinTaiKhoan()
        {
            dt_login = db.getDataTable("select * from NhanVien");
            DataColumn[] key = new DataColumn[1];
            key[0] = dt_login.Columns[0];
            dt_login.PrimaryKey = key;
            InitializeComponent();
        }
        public void uplabel()
        {
            DataRow dr = dt_login.Rows.Find(lb_manv.Text);
            if (dr != null)
            {
                lb_ten.Text = dr["TenNV"].ToString();
                lb_sdth.Text = dr["SDT"].ToString();
                lb_loai.Text = dr["Loai"].ToString();
                lb_chucvu.Text = dr["ChucVu"].ToString();
                lb_diachi.Text = dr["DiaChi"].ToString();
                lb_gioitinh.Text = dr["GioiTinh"].ToString();
                lb_ns.Text = dr["NgaySinh"].ToString() ;
                lb_trangthai.Text = dr["TrangThai"].ToString();
            }
        }
        private void frmThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            lb_manv.Text = Properties.Settings.Default.username;
            uplabel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau formdmk = new frmDoiMatKhau();
            formdmk.Show();
        }
    }
}
