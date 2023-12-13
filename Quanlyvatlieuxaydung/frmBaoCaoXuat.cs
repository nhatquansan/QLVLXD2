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
    public partial class frmBaoCaoXuat : Form
    {

        DBConnect db = new DBConnect();
        DataTable dt_XuatKho = new DataTable();
        string sql = "select Distinct DonXuatKho.SoHoaDonXuat, NhanVien.TenNV, HangHoa.TenHangHoa, HangHoa.XuatXu, HangHoa.DonVi, ChiTietHoaDonBanHang.SoLuong, ChiTietHoaDonBanHang.DonGia, DonXuatKho.NgayXuat from DonXuatKho, NhanVien, HangHoa, ChiTietHoaDonBanHang where DonXuatKho.SoHoaDonXuat = ChiTietHoaDonBanHang.SoHoaDonXuat and DonXuatKho.MaNV = NhanVien.MaNV and ChiTietHoaDonBanHang.MaHH = HangHoa.MaHH";


        public frmBaoCaoXuat()
        {
            InitializeComponent();
        }

        public void load_cbo_NhanVien()
        {
            string selectstr = "select * from nhanvien";
            DataTable dt_nv = db.getDataTable(selectstr);
            cbo_NV.DataSource = dt_nv;
            cbo_NV.DisplayMember = "tennv";
            cbo_NV.ValueMember = "tennv";
        }

        public void load_dgv_XuatKho()
        {
            DataTable dt_kho = new DataTable();
            dt_kho = db.getDataTable(sql);
            dgv_XuatKho.DataSource = dt_kho;
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            load_dgv_XuatKho();
        }

        private void frmBaoCaoXuat_Load(object sender, EventArgs e)
        {
            load_cbo_NhanVien();
        }

        private void btn_ThucHien_Click(object sender, EventArgs e)
        {
            if (cb_NV.Checked)
            {
                string rowFilter = string.Format("{0} like '{1}'", "TenNV", "*" + cbo_NV.SelectedValue + "*");
                (dgv_XuatKho.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            else if (cb_Date.Checked)
            {
                DateTime fromDate = DateTime.Parse(dateTP_FromDate.Text);
                DateTime toDate = DateTime.Parse(dateTP_ToDate.Text);
                DataTable dt_date = new DataTable();
                dt_date.Clear();

                string selectstr = "select Distinct DonXuatKho.SoHoaDonXuat, NhanVien.TenNV, HangHoa.TenHangHoa, HangHoa.XuatXu, HangHoa.DonVi, ChiTietHoaDonBanHang.SoLuong, ChiTietHoaDonBanHang.DonGia, DonXuatKho.NgayXuat from DonXuatKho, NhanVien, HangHoa, ChiTietHoaDonBanHang where DonXuatKho.SoHoaDonXuat = ChiTietHoaDonBanHang.SoHoaDonXuat and DonXuatKho.MaNV = NhanVien.MaNV and ChiTietHoaDonBanHang.MaHH = HangHoa.MaHH AND DonXuatKho.NgayXuat BETWEEN '" + fromDate.ToString("yyyy-MM-dd") + "' AND '" + toDate.ToString("yyyy-MM-dd") + "' ORDER BY NgayXuat DESC";


                dt_date = db.getDataTable(selectstr);
                dgv_XuatKho.DataSource = dt_date;
            }

        }


    }
}
