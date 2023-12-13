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
    public partial class frmTrangchu_AD : Form
    {
        public frmTrangchu_AD()
        {
            InitializeComponent();
        }

      

        private void frmTrangchu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ketqua;
            ketqua = MessageBox.Show("Bạn có đồng ý thoát ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ketqua == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btn_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btn_thongtintaikhoan_Click(object sender, EventArgs e)
        {
            
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmThongTinTaiKhoan formtttk = new frmThongTinTaiKhoan() { TopLevel = false, TopMost = true };
            formtttk.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formtttk);
            formtttk.Show();
            
        }

        private void btn_nhanvien_Click(object sender, EventArgs e)
        {
            // Clear
            
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmThongTinNhanVien formttnv = new frmThongTinNhanVien() { TopLevel = false, TopMost = true };
            formttnv.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formttnv);
            formttnv.Show();
        }

        private void btn_doimk_Click(object sender, EventArgs e)
        {
            panel1.BackgroundImage = null;
            frmDoiMatKhau formdmk = new frmDoiMatKhau();
            formdmk.Show();
        }

        private void btn_khachhang_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmThongTinKhachHang formttkh = new frmThongTinKhachHang() { TopLevel = false, TopMost = true };
            formttkh.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formttkh);
            formttkh.Show();
        }

        private void btn_nhacungcap_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmThongTinNhaCungCap formncc = new frmThongTinNhaCungCap() { TopLevel = false, TopMost = true };
            formncc.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formncc);
            formncc.Show();
        }

        private void btn_loaihang_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmThongTinLoaiHang formlh = new frmThongTinLoaiHang() { TopLevel = false, TopMost = true };
            formlh.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formlh);
            formlh.Show();
        }

        private void btn_hanghoa_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmThongTinHangHoa formhh = new frmThongTinHangHoa() { TopLevel = false, TopMost = true };
            formhh.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formhh);
            formhh.Show();
        }

        private void btn_nhaphang_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmHoaDonNhap formnh = new frmHoaDonNhap() { TopLevel = false, TopMost = true };
            formnh.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formnh);
            formnh.Show();
        }

        private void btn_xuathang_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmHoaDonXuat formxh = new frmHoaDonXuat() { TopLevel = false, TopMost = true };
            formxh.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formxh);
            formxh.Show();
        }

        private void btn_kho_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmKho formkho = new frmKho() { TopLevel = false, TopMost = true };
            formkho.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formkho);
            formkho.Show();
        }

        private void btn_myteam_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmMyTeam formmyteam = new frmMyTeam() { TopLevel = false, TopMost = true };
            formmyteam.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formmyteam);
            formmyteam.Show();
        }

        private void btn_baocaokho_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmBaoCaoKho formkho = new frmBaoCaoKho() { TopLevel = false, TopMost = true };
            formkho.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formkho);
            formkho.Show();
        }

        private void btn_nhap_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmBaoCaoNhap formnhapkho = new frmBaoCaoNhap() { TopLevel = false, TopMost = true };
            formnhapkho.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formnhapkho);
            formnhapkho.Show();
        }

        private void btn_xuat_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmBaoCaoXuat formxuatkho = new frmBaoCaoXuat() { TopLevel = false, TopMost = true };
            formxuatkho.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formxuatkho);
            formxuatkho.Show();
        }

        private void btn_dsloaihang_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmDSLoaiHang formlh = new frmDSLoaiHang() { TopLevel = false, TopMost = true };
            formlh.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formlh);
            formlh.Show();
        }

        private void btn_dskhachhang_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmDSHangHoa formhh = new frmDSHangHoa() { TopLevel = false, TopMost = true };
            formhh.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formhh);
            formhh.Show();
        }

        private void bnt_khachhang_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmDSKhachHang formdskh = new frmDSKhachHang() { TopLevel = false, TopMost = true };
            formdskh.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formdskh);
            formdskh.Show();
        }

        private void btn_ncc_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmDSNhaCungCap formdsncc = new frmDSNhaCungCap() { TopLevel = false, TopMost = true };
            formdsncc.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formdsncc);
            formdsncc.Show();
        }


        private void btn_logout_Click_1(object sender, EventArgs e)
        {
            DialogResult ketqua;
            ketqua = MessageBox.Show("Bạn có đồng ý đăng xuất ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            {
                if (ketqua == DialogResult.No)
                {
                    
                }
                else
                {
                    this.Hide();
                    frm_DangNhap frmlogin = new frm_DangNhap();
                    frmlogin.Show();
                }
            }
        }



        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
         
        }
    }

       


    
}
