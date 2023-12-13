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
using System.Data;

namespace Quanlyvatlieuxaydung
{
    public partial class frm_DangNhap : Form
    {
        DataTable dt_login = new DataTable();
        DBConnect db = new DBConnect();
        public frm_DangNhap()
        {
            dt_login = db.getDataTable("select * from NhanVien");
            DataColumn[] key = new DataColumn[1];
            key[0] = dt_login.Columns[0];
            dt_login.PrimaryKey = key;
            InitializeComponent();
        }
        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
            txt_manhanvien.Focus();
            txt_manhanvien.Clear();
            txt_matkhau.Clear();
            btn_DangNhap.Enabled = false;
            txt_matkhau.PasswordChar = '*';
            txt_manhanvien.Text = Properties.Settings.Default.username;
            txt_matkhau.Text = Properties.Settings.Default.password;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            dangnhap();
        }
        public void dangnhap()
        {
            DataRow dr = dt_login.Rows.Find(txt_manhanvien.Text);
            if (dr != null)
            {
                DataEncryptor encryptedstring = new DataEncryptor();

                save_session();
                
                if (txt_matkhau.Text == encryptedstring.Decrypt(dr["MatKhau"].ToString()) && dr["Loai"].ToString() == "Admin")
                {
                    this.Hide();
                    frmTrangchu_AD formtrangchu = new frmTrangchu_AD();
                    formtrangchu.Show();
                }
                else if (txt_matkhau.Text == encryptedstring.Decrypt(dr["MatKhau"].ToString()) && dr["Loai"].ToString() == "Nhan Vien")
                {
                    this.Hide();
                    frmTrangChu_NV formtrangchu = new frmTrangChu_NV();
                    formtrangchu.Show();
                }
                else
                {
                    MessageBox.Show("Mã Nhân Viên Hoặc Mật Khẩu Không Tồn Tại !!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Mã Nhân Viên Hoặc Mật Khẩu Không Tồn Tại !!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Thoát 
        private void frm_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ketqua;
            ketqua = MessageBox.Show("Bạn có đồng ý thoát ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ketqua == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_manhanvien_TextChanged(object sender, EventArgs e)
        {
            if (txt_manhanvien.Text != string.Empty && txt_matkhau.Text != string.Empty)
            {
                btn_DangNhap.Enabled = true;
            }
            else btn_DangNhap.Enabled = false;
        }

         public void save_session()
         {
            string manv = txt_manhanvien.Text;
            string pwd = txt_matkhau.Text;
            Properties.Settings.Default.username = manv;
            Properties.Settings.Default.password = pwd;
         }
        
    }
}
