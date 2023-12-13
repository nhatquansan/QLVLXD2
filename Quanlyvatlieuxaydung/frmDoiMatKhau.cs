using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quanlyvatlieuxaydung
{
    public partial class frmDoiMatKhau : Form
    {
        //
   

        //
        DataTable dt_login = new DataTable();
        DBConnect db = new DBConnect();
        DataEncryptor StringCipher = new DataEncryptor();
        public frmDoiMatKhau()
        {
            dt_login = db.getDataTable("select * from NhanVien");
            DataColumn[] key = new DataColumn[1];
            key[0] = dt_login.Columns[0];
            dt_login.PrimaryKey = key;
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txt_manv.Focus();
            txt_mkcu.PasswordChar = '*';
            txt_mkmoi.PasswordChar = '*';
            txt_retypepass.PasswordChar = '*';
            btn_save.Enabled = false;
        }

       
        private void frmDoiMatKhau_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ketqua;
            ketqua = MessageBox.Show("Bạn có đồng ý thoát ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ketqua == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DataRow dr = dt_login.Rows.Find(txt_manv.Text);
            if (dr != null)
            {
                if (txt_mkcu.Text == StringCipher.Decrypt(dr["MatKhau"].ToString()))
                {
                    if (txt_mkmoi.Text == txt_retypepass.Text)
                    {
                        // Mã hóa mật khẩu 
                        
                        string plaintext = txt_mkmoi.Text.ToString();
                        string Encrypt = StringCipher.Encrypt(plaintext);

                        //Thực hiện sửa mật khẩu
                        dr["MatKhau"] = Encrypt;
                        int kq = db.updateDataBase("select * from NhanVien", dt_login);
                        if (kq > 0)
                        {
                            MessageBox.Show("Cập Nhật Mật Khẩu Thành Công", "Thành Công", MessageBoxButtons.OK);
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Cập Nhật Mật Khẩu Không Thành Công");
                        }
                        return;
                    }
                    MessageBox.Show("Mật Khẩu mới và Mật Khẩu cũ không trùng nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            MessageBox.Show("Mã Nhân Viên Hoặc Mật Khẩu Không Tồn Tại !!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txt_manv_TextChanged(object sender, EventArgs e)
        {
            if (txt_manv.Text != string.Empty && txt_mkcu.Text != string.Empty && txt_mkmoi.Text != string.Empty && txt_retypepass.Text != string.Empty) {
                btn_save.Enabled = true;
            }
        }

        
    }
}
