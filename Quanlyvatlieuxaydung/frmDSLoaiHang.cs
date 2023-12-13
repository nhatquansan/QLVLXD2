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
    public partial class frmDSLoaiHang : Form
    {

        DBConnect db = new DBConnect();
        DataTable dt_Loai = new DataTable();
        public frmDSLoaiHang()
        {
            InitializeComponent();
        }

        public void load_dgv_DSHH()
        {
            string selectstr = "SELECT * from LoaiHangHoa";
            DataTable dt_loai = new DataTable();
            dt_loai = db.getDataTable(selectstr);
           
            dgv_LoaiHang.DataSource = dt_loai;
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị báo cáo
                ReportDSLH fm = new ReportDSLH();
                fm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDSLoaiHang_Load(object sender, EventArgs e)
        {
            load_dgv_DSHH();
        }
    }
}
