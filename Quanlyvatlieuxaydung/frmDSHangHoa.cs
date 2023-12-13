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
    public partial class frmDSHangHoa : Form
    {

        DBConnect db = new DBConnect();
        DataTable dt_DSHH = new DataTable();
        public frmDSHangHoa()
        {
            InitializeComponent();
        }

        public void load_dgv_DSHH()
        {
            string selectstr = "SELECT TenHangHoa, DonVi, XuatXu, TenLoai, ThongTin FROM HangHoa JOIN LoaiHangHoa ON LoaiHangHoa.MaLoai = HangHoa.MaLoai;";
            DataTable dt_dshh = new DataTable();
            dt_dshh = db.getDataTable(selectstr);
            dgv_DSHH.DataSource = dt_dshh;
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị báo cáo
                ReportDSHH fm = new ReportDSHH();
                fm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDSHangHoa_Load(object sender, EventArgs e)
        {
            load_dgv_DSHH();
        }
    }
}
