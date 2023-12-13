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
    public partial class frmHoaDonXuat : Form
    {
        private bool isAddingNew = false;
        DBConnect db = new DBConnect();
        DataTable dt_hdx = new DataTable();
        public frmHoaDonXuat()
        {
            InitializeComponent();
            string selectstr = "SELECT dxk.SoHoaDonXuat, dxk.NgayXuat, nv.TenNV, nv.MaNV, kh.TenKH, kh.MaKH, ncc.TenNCC, ncc.MaNCC " +
                   "FROM DonXuatKho dxk " +
                   "INNER JOIN NhanVien nv ON dxk.MaNV = nv.MaNV " +
                   "INNER JOIN KhachHang kh ON dxk.MaKH = kh.MaKH " +
                   "INNER JOIN NhaCungCap ncc ON dxk.MaNCC = ncc.MaNCC";


            dt_hdx = db.getDataTable(selectstr);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt_hdx.Columns[0];
            dt_hdx.PrimaryKey = key;
            dataGridView1.CellClick += dataGridView1_CellClick;

        }

        public void Load_dgvHoaDonXuat()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt_hdx;
            Databingding(dt_hdx);

        }
        public void load_cboKhachHang()
        {
            string selectstr = "select * from KhachHang";
            DataTable dt_KhachHang = db.getDataTable(selectstr);
            comboBox2.DataSource = dt_KhachHang;
            comboBox2.DisplayMember = "TenKH";
            comboBox2.ValueMember = "MaKH";
        }
        public void load_cboNCC()
        {
            string selectstr = "select * from NhaCungCap";
            DataTable dt_NCC = db.getDataTable(selectstr);
            comboBox3.DataSource = dt_NCC;
            comboBox3.DisplayMember = "TenNCC";
            comboBox3.ValueMember = "MaNCC";
        }
        public void load_cboNhanVien()
        {
            string selectstr = "select * from NhanVien";
            DataTable dt_NhanVien = db.getDataTable(selectstr);
            comboBox1.DataSource = dt_NhanVien;
            comboBox1.DisplayMember = "TenNV";
            comboBox1.ValueMember = "MaNV";
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dt_hdx.Rows.Count)
            {
                textBox1.Text = dt_hdx.Rows[e.RowIndex]["SoHoaDonXuat"].ToString();
                dateTimePicker1.Text = dt_hdx.Rows[e.RowIndex]["NgayXuat"].ToString();
                comboBox2.SelectedValue = dt_hdx.Rows[e.RowIndex]["MaKH"].ToString();
                comboBox1.SelectedValue = dt_hdx.Rows[e.RowIndex]["MaNV"].ToString();
                comboBox3.SelectedValue = dt_hdx.Rows[e.RowIndex]["MaNCC"].ToString();

            }
        }

        void Databingding(DataTable pDT)
        {
            if (pDT.Rows.Count > 0)
            {
                int currentRowIndex = dataGridView1.CurrentRow.Index;
                textBox1.Text = pDT.Rows[currentRowIndex]["SoHoaDonXuat"].ToString();
                dateTimePicker1.Text = pDT.Rows[currentRowIndex]["NgayXuat"].ToString();
                comboBox2.SelectedValue = pDT.Rows[currentRowIndex]["MaKH"].ToString();
                comboBox1.SelectedValue = pDT.Rows[currentRowIndex]["MaNV"].ToString();
                comboBox3.SelectedValue = pDT.Rows[currentRowIndex]["MaNCC"].ToString();

            }
            else
            {
                textBox1.Text = "";
                dateTimePicker1.Text = "";
                comboBox2.Text = "";
                comboBox1.Text = "";
                comboBox3.Text = "";
            }
        }

        private void frmHoaDonXuat_Load(object sender, EventArgs e)
        {
            Load_dgvHoaDonXuat();
            textBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox1.Enabled = false;
            comboBox3.Enabled = false;
            radioButton1.Checked = true;

            load_cboNCC();
            load_cboKhachHang();
            load_cboNhanVien();
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void button12_Click(object sender, EventArgs e)//Them
        {
            Load_dgvHoaDonXuat();
            textBox1.Enabled = true;
            comboBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;

            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            dateTimePicker1.ResetText();
            textBox1.Focus();

            button8.Enabled = true;
            isAddingNew = true;
        }

        private void button9_Click(object sender, EventArgs e)//Sua
        {
            Load_dgvHoaDonXuat();
            textBox1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            dateTimePicker1.Enabled = true;

            
            textBox1.Focus();

            button8.Enabled = true;
            isAddingNew = false;
        }

        private void button11_Click(object sender, EventArgs e)//Lam moi
        {
            dataGridView1.Refresh();
            Load_dgvHoaDonXuat();
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            dateTimePicker1.ResetText();
            textBox1.Focus();
        }

        private void button10_Click(object sender, EventArgs e)//Xoa
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string soHoaDonXuatToDelete = textBox1.Text;

            // Kiểm tra xem SoHoaDonXuat có tồn tại trong ChiTietHoaDonBanHang hay không
            string checkExistQuery = "SELECT COUNT(*) FROM ChiTietHoaDonBanHang WHERE SoHoaDonXuat = '" + soHoaDonXuatToDelete + "'";
            int count = Convert.ToInt32(db.getScalar(checkExistQuery));

            if (count > 0)
            {
                MessageBox.Show("Hóa đơn đang tồn tại trong chi tiết hóa đơn bán, không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn xuất có mã " + soHoaDonXuatToDelete + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DataRow dr = dt_hdx.Rows.Find(soHoaDonXuatToDelete);
                if (dr != null)
                {
                    dr.Delete();
                }

                string sql = "select * from DonXuatKho ";
                int kq = db.updateDataBase(sql, dt_hdx);

                if (kq > 0)
                {
                    MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa không được !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                isAddingNew = true;
                textBox1.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                dateTimePicker1.ResetText();
            }
        }



        private void textBox5_TextChanged(object sender, EventArgs e)//Tim Kiem
        {
            if (radioButton1.Checked)
            {
                string rowFilter = string.Format("{0} like '{1}'", "SoHoaDonXuat", "*" + textBox5.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            else if (radioButton2.Checked)
            {
                string rowFilter = string.Format("{0} like '{1}'", "TenKH", "*" + textBox5.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
        }


        private bool IsMaHDBDuplicated(string maHDB)
        {
            DataRow existingRow = dt_hdx.Rows.Find(maHDB);
            return existingRow != null;
        }

        private void button8_Click(object sender, EventArgs e)//Luu
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hóa đơn bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox2.Focus();
                return;
            }

            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }

            if (comboBox3.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox3.Focus();
                return;
            }

            DataRow dr;

            if (isAddingNew)
            {
                if (IsMaHDBDuplicated(textBox1.Text))
                {
                    MessageBox.Show("Mã hóa đơn bán đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;
                }
                dr = dt_hdx.NewRow();

                dr["SoHoaDonXuat"] = textBox1.Text;
                dr["NgayXuat"] = dateTimePicker1.Text;
                dr["TenNV"] = comboBox1.Text;
                dr["TenKH"] = comboBox2.Text;
                dr["TenNCC"] = comboBox3.Text;
                dr["MaKH"] = comboBox2.SelectedValue.ToString();
                dr["MaNV"] = comboBox1.SelectedValue.ToString();
                dr["MaNCC"] = comboBox3.SelectedValue.ToString();
                dt_hdx.Rows.Add(dr);
            }
            else // Sửa
            {
                dr = dt_hdx.Rows.Find(textBox1.Text);
                if (dr != null)
                {
                    dr["NgayXuat"] = dateTimePicker1.Text;
                    dr["TenNV"] = comboBox1.Text;
                    dr["TenKH"] = comboBox2.Text;
                    dr["TenNCC"] = comboBox3.Text;
                    dr["MaKH"] = comboBox2.SelectedValue.ToString();
                    dr["MaNV"] = comboBox1.SelectedValue.ToString();
                    dr["MaNCC"] = comboBox3.SelectedValue.ToString();

                }
            }

            string sql = "select * from DonXuatKho ";
            int kq = db.updateDataBase(sql, dt_hdx);

            if (kq > 0)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                button8.Enabled = false;
                textBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox1.Enabled = false;

                Load_dgvHoaDonXuat();

            }
            else
            {
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã hàng hóa không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            isAddingNew = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string soHoaDonXuat = textBox1.Text;
                string tenNhanVien = comboBox1.Text;
                string tenKhachHang = comboBox2.Text;
                DateTime ngayXuat = dateTimePicker1.Value;
                frmChiTietHoaDonXuat ctForm = new frmChiTietHoaDonXuat(soHoaDonXuat, tenNhanVien, tenKhachHang, ngayXuat);

                // Hiển thị form CT_HoaDonNhap
                ctForm.Show();
            }
        }
    }
}
