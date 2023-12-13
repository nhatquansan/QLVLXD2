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
    public partial class frmDSNhaCungCap : Form
    {

        DBConnect db = new DBConnect();
        DataTable dt_NCC = new DataTable();
        public frmDSNhaCungCap()
        {
            InitializeComponent();
        }

        public void load_dgv_NCC()
        {
            string selectstr = "SELECT * from NhaCungCap";
            DataTable dt_dsncc = new DataTable();
            dt_dsncc = db.getDataTable(selectstr);
            dgv_NCC.DataSource = dt_dsncc;
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            try
            {

                ReportDSNCC fm = new ReportDSNCC();
               
                fm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDSNhaCungCap_Load(object sender, EventArgs e)
        {
            load_dgv_NCC();
        }
    }
}
