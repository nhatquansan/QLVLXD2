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
    public partial class frmKho : Form
    {
        DBConnect db = new DBConnect();
        public frmKho()
        {
            InitializeComponent();
        }
        public void load_cboLoaiHang()
        {
            string selectstr = "select * from LoaiHangHoa";
            DataTable dt_LoaiHang = db.getDataTable(selectstr);
            comboBox1.DataSource = dt_LoaiHang;
            comboBox1.DisplayMember = "TenLoai";
            comboBox1.ValueMember = "MaLoai";
        }
        public void load_dgvThongTinKho()
        {
            DataTable dt_HangHoa = new DataTable();
            dataGridView1.AutoGenerateColumns = false;
            string selectstr1 = "select * from HangHoa, Kho  where Kho.MaHH = HangHoa.MaHH and HangHoa.MaLoai ='" + comboBox1.SelectedValue.ToString() + "'";
            dt_HangHoa = db.getDataTable(selectstr1);
            dataGridView1.DataSource = dt_HangHoa;

        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            load_cboLoaiHang();
            load_dgvThongTinKho();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_dgvThongTinKho();
        }
    }
}
