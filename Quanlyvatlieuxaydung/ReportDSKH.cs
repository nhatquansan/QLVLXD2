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
    public partial class ReportDSKH : Form
    {
        public ReportDSKH()
        {
            InitializeComponent();
        }

        private void ReportDSKH_Load(object sender, EventArgs e)
        {
            DSKH rpt = new DSKH();
            crystalReportViewer1.ReportSource = rpt;
            rpt.SetDatabaseLogon("sa", "123", "MSI\\SQLEXPRESS", "QuanLy_VLXD5");
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();
        }
    }
}
