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
    public partial class frmBaoCaoKho : Form
    {

        DBConnect db = new DBConnect();
        DataTable dt_Kho = new DataTable();
        public frmBaoCaoKho()
        {
            
            InitializeComponent();
        }

        public void load_dgv_Kho()
        {
            string selectstr = "SELECT MaKho, TenHangHoa, SoLuong, DonVi, XuatXu FROM Kho JOIN HangHoa ON Kho.MaHH = HangHoa.MaHH";
            DataTable dt_ctpn = new DataTable();
            dt_ctpn = db.getDataTable(selectstr);
            dgv_BaoCaoKho.DataSource = dt_ctpn;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_dgv_Kho();
        }

        private void frmBaoCaoKho_Load(object sender, EventArgs e)
        {
            load_dgv_Kho();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị báo cáo
                ReportKho fm = new ReportKho();
                fm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
