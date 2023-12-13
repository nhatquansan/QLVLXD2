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
    public partial class frmDSKhachHang : Form
    {

        DBConnect db = new DBConnect();
        DataTable dt_KH = new DataTable();
        public frmDSKhachHang()
        {
            InitializeComponent();
        }

        public void load_dgv_DSHH()
        {
            string selectstr = "SELECT * from KhachHang";
            DataTable dt_kh = new DataTable();
            dt_kh = db.getDataTable(selectstr);
            dgv_KhachHang.DataSource = dt_kh;
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            try
            {


                // Hiển thị báo cáo
                ReportDSKH fm = new ReportDSKH();
                fm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDSKhachHang_Load(object sender, EventArgs e)
        {
            load_dgv_DSHH();
        }
    }
}
