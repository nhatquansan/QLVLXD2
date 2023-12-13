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
    public partial class frmBaoCaoNhap : Form
    {

        DBConnect db = new DBConnect();
        DataTable dt_NhapKho = new DataTable();
        string sql = "select  DonNhapKho.SoHoaDonNhap, NhaCungCap.TenNCC, NhanVien.TenNV, HangHoa.TenHangHoa, HangHoa.XuatXu, HangHoa.DonVi, ChiTietHoaDonNhapKho.SoLuong, ChiTietHoaDonNhapKho.DonGia, NgayNhap  from NhaCungCap, NhanVien, HangHoa, DonNhapKho, ChiTietHoaDonNhapKho where DonNhapKho.SoHoaDonNhap = ChiTietHoaDonNhapKho.SoHoaDonNhap and	DonNhapKho.MaNCC = NhaCungCap.MaNCC and ChiTietHoaDonNhapKho.MaHH = HangHoa.MaHH and DonNhapKho.MaNV = NhanVien.MaNV";


        public frmBaoCaoNhap()
        {
            InitializeComponent();
        }

        public void load_cbo_NCC()
        {
            string selectstr = "select * from nhacungcap";
            DataTable dt_ncc = db.getDataTable(selectstr);
            cbo_NhaCC.DataSource = dt_ncc;
            cbo_NhaCC.DisplayMember = "tenncc";
            cbo_NhaCC.ValueMember = "tenncc";
        }

        public void load_cbo_NhanVien()
        {
            string selectstr = "select * from nhanvien";
            DataTable dt_nv = db.getDataTable(selectstr);
            cbo_NV.DataSource = dt_nv;
            cbo_NV.DisplayMember = "tennv";
            cbo_NV.ValueMember = "tennv";
        }

        public void load_dgv_NhapKho()
        {
            DataTable dt_kho = new DataTable();
            dt_kho = db.getDataTable(sql);
            dgv_NhapKho.DataSource = dt_kho;
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            load_dgv_NhapKho();
        }

        private void frmBaoCaoNhap_Load(object sender, EventArgs e)
        {
            load_cbo_NhanVien();
            load_cbo_NCC();
        }

        private void btn_ThucHien_Click(object sender, EventArgs e)
        {
            if (cb_NCC.Checked)
            {
                string rowFilter = string.Format("{0} like '{1}'", "TenNCC", "*" + cbo_NhaCC.SelectedValue + "*");
                (dgv_NhapKho.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            else if (cb_NV.Checked)
            {
                string rowFilter = string.Format("{0} like '{1}'", "TenNV", "*" + cbo_NV.SelectedValue + "*");
                (dgv_NhapKho.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            else if (cb_Date.Checked)
            {
                DateTime fromDate = DateTime.Parse(datePK_FromDate.Text);
                DateTime toDate = DateTime.Parse(datePK_ToDate.Text);
                DataTable dt_date = new DataTable();
                dt_date.Clear();

                string selectstr = "SELECT DonNhapKho.SoHoaDonNhap, NhaCungCap.TenNCC, NhanVien.TenNV, HangHoa.TenHangHoa, HangHoa.XuatXu, HangHoa.DonVi, ChiTietHoaDonNhapKho.SoLuong, ChiTietHoaDonNhapKho.DonGia, NgayNhap FROM NhaCungCap, NhanVien, HangHoa, DonNhapKho, ChiTietHoaDonNhapKho WHERE DonNhapKho.SoHoaDonNhap = ChiTietHoaDonNhapKho.SoHoaDonNhap AND DonNhapKho.MaNCC = NhaCungCap.MaNCC AND ChiTietHoaDonNhapKho.MaHH = HangHoa.MaHH AND DonNhapKho.MaNV = NhanVien.MaNV AND DonNhapKho.NgayNhap BETWEEN '" + fromDate.ToString("yyyy-MM-dd") + "' AND '" + toDate.ToString("yyyy-MM-dd") + "' ORDER BY NgayNhap DESC";


                dt_date = db.getDataTable(selectstr);
                dgv_NhapKho.DataSource = dt_date;
            }


        }
    }
}
