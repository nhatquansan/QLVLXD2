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
    public partial class ReportDSHH : Form
    {
        public ReportDSHH()
        {
            InitializeComponent();
        }

        private void ReportDSHH_Load(object sender, EventArgs e)
        {
            DSHH rpt = new DSHH();
            crystalReportViewer2.ReportSource = rpt;
            rpt.SetDatabaseLogon("sa", "123", "MSI\\SQLEXPRESS", "QuanLy_VLXD5");
            crystalReportViewer2.DisplayStatusBar = false;
            crystalReportViewer2.DisplayToolbar = true;
            crystalReportViewer2.Refresh();
        }
    }
}
