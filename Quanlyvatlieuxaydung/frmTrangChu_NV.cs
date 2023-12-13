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
    public partial class frmTrangChu_NV : Form
    {
        public frmTrangChu_NV()
        {
            InitializeComponent();
        }

        private void frmTrangChu_NV_Load(object sender, EventArgs e)
        {
            btn_doimatkhau.Enabled = false;
            btn_nhanvien.Enabled = false;
            btn_thongtintaikhoan.Enabled = false;
        }

        private void btn_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTrangChu_NV_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ketqua;
            ketqua = MessageBox.Show("Bạn có đồng ý thoát ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ketqua == DialogResult.No)
            {
                e.Cancel = true;
            }
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

        private void btn_lhang_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmDSLoaiHang formlh = new frmDSLoaiHang() { TopLevel = false, TopMost = true };
            formlh.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formlh);
            formlh.Show();
        }

        private void btn_dshh_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmDSLoaiHang formlh = new frmDSLoaiHang() { TopLevel = false, TopMost = true };
            formlh.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formlh);
            formlh.Show();
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

        private void btn_myteam_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmMyTeam formmyteam = new frmMyTeam() { TopLevel = false, TopMost = true };
            formmyteam.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formmyteam);
            formmyteam.Show();
        }

        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
           
        }
    }
}
