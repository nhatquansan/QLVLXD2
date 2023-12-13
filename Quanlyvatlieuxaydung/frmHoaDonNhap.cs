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
    public partial class frmHoaDonNhap : Form
    {
        private bool isAddingNew = false;
        DBConnect db = new DBConnect();
        DataTable dt_hdn = new DataTable();
        public frmHoaDonNhap()
        {
            InitializeComponent();
            string selectstr = "SELECT dnk.SoHoaDonNhap, dnk.NgayNhap, nv.TenNV, nv.MaNV, ncc.TenNCC, ncc.MaNCC " +
                   "FROM DonNhapKho dnk " +
                   "INNER JOIN NhanVien nv ON dnk.MaNV = nv.MaNV " +
                   "INNER JOIN NhaCungCap ncc ON dnk.MaNCC = ncc.MaNCC";


            dt_hdn = db.getDataTable(selectstr);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt_hdn.Columns[0];
            dt_hdn.PrimaryKey = key;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }


        public void Load_dgvHoaDonNhap()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt_hdn;
            Databingding(dt_hdn);
        }
        public void load_cboNCC()
        {
            string selectstr = "select * from NhaCungCap";
            DataTable dt_NCC = db.getDataTable(selectstr);
            comboBox2.DataSource = dt_NCC;
            comboBox2.DisplayMember = "TenNCC";
            comboBox2.ValueMember = "MaNCC";
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
            if (e.RowIndex >= 0 && e.RowIndex < dt_hdn.Rows.Count)
            {
                textBox1.Text = dt_hdn.Rows[e.RowIndex]["SoHoaDonNhap"].ToString();
                dateTimePicker1.Text = dt_hdn.Rows[e.RowIndex]["NgayNhap"].ToString();
                comboBox2.SelectedValue = dt_hdn.Rows[e.RowIndex]["MaNCC"].ToString();
                comboBox1.SelectedValue = dt_hdn.Rows[e.RowIndex]["MaNV"].ToString();
            }
        }

        void Databingding(DataTable pDT)
        {
            if (pDT.Rows.Count > 0)
            {
                int currentRowIndex = dataGridView1.CurrentRow.Index;
                textBox1.Text = pDT.Rows[currentRowIndex]["SoHoaDonNhap"].ToString();
                dateTimePicker1.Text = pDT.Rows[currentRowIndex]["NgayNhap"].ToString();
                comboBox2.SelectedValue = pDT.Rows[currentRowIndex]["MaNCC"].ToString();
                comboBox1.SelectedValue = pDT.Rows[currentRowIndex]["MaNV"].ToString();
            }
            else
            {
                textBox1.Text = "";
                dateTimePicker1.Text = "";
                comboBox2.Text = "";
                comboBox1.Text = "";
            }
        }

        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            Load_dgvHoaDonNhap();
            textBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox1.Enabled = false;
            radioButton1.Checked = true;

            load_cboNCC();
            load_cboNhanVien();
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void button12_Click(object sender, EventArgs e)//Them
        {
            Load_dgvHoaDonNhap();
            textBox1.Enabled = true;
            comboBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox2.Enabled = true;

            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            dateTimePicker1.ResetText();
            textBox1.Focus();

            button8.Enabled = true;
            isAddingNew = true;
        }

        private void button9_Click(object sender, EventArgs e)//Sua
        {
            Load_dgvHoaDonNhap();
            textBox1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            dateTimePicker1.Enabled = true;

            dateTimePicker1.ResetText();
            textBox1.Focus();

            button8.Enabled = true;
            isAddingNew = false;
        }

        private void button11_Click(object sender, EventArgs e)//LamMoi
        {
            Load_dgvHoaDonNhap();

            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;

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

            string soHoaDonNhapToDelete = textBox1.Text;

            // Kiểm tra xem SoHoaDonXuat có tồn tại trong ChiTietHoaDonBanHang hay không
            string checkExistQuery = "SELECT COUNT(*) FROM ChiTietHoaDonNhapKho WHERE SoHoaDonNhap = '" + soHoaDonNhapToDelete + "'";
            int count = Convert.ToInt32(db.getScalar(checkExistQuery));

            if (count > 0)
            {
                MessageBox.Show("Hóa đơn đang tồn tại trong chi tiết hóa đơn nhập, không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn xuất có mã " + soHoaDonNhapToDelete + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DataRow dr = dt_hdn.Rows.Find(soHoaDonNhapToDelete);
                if (dr != null)
                {
                    dr.Delete();
                }

                string sql = "select * from DonNhapKho ";
                int kq = db.updateDataBase(sql, dt_hdn);

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
                dateTimePicker1.ResetText();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string rowFilter = string.Format("{0} like '{1}'", "SoHoaDonNhap", "*" + textBox5.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            else if (radioButton2.Checked)
            {
                string rowFilter = string.Format("{0} like '{1}'", "TenNCC", "*" + textBox5.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
        }


        private bool IsMaHDNDuplicated(string maHDB)
        {
            DataRow existingRow = dt_hdn.Rows.Find(maHDB);
            return existingRow != null;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hóa đơn bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }

            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }

            if (comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox2.Focus();
                return;
            }

            DataRow dr;

            if (isAddingNew)
            {
                if (IsMaHDNDuplicated(textBox1.Text))
                {
                    MessageBox.Show("Mã hóa đơn nhập đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;
                }
                dr = dt_hdn.NewRow();

                dr["SoHoaDonNhap"] = textBox1.Text;
                dr["NgayNhap"] = dateTimePicker1.Text;
                dr["TenNV"] = comboBox1.Text;
                dr["TenNCC"] = comboBox2.Text;
                dr["MaNV"] = comboBox1.SelectedValue.ToString();
                dr["MaNCC"] = comboBox2.SelectedValue.ToString();
                dt_hdn.Rows.Add(dr);
            }
            else // Sửa
            {
                dr = dt_hdn.Rows.Find(textBox1.Text);
                if (dr != null)
                {
                    dr["NgayNhap"] = dateTimePicker1.Text;
                    dr["TenNV"] = comboBox1.Text;
                    dr["TenNCC"] = comboBox2.Text;
                    dr["MaNV"] = comboBox1.SelectedValue.ToString();
                    dr["MaNCC"] = comboBox2.SelectedValue.ToString();

                }
            }

            string sql = "select * from DonNhapKho ";
            int kq = db.updateDataBase(sql, dt_hdn);

            if (kq > 0)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                button8.Enabled = false;
                textBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox1.Enabled = false;

                Load_dgvHoaDonNhap();

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
                string soHoaDonNhap = textBox1.Text;
                string tenNhanVien = comboBox1.Text;
                string tenNhaCungCap = comboBox2.Text;
                DateTime ngayNhap = dateTimePicker1.Value;
                frmChiTietHoaDonNhap ctForm = new frmChiTietHoaDonNhap(soHoaDonNhap, tenNhanVien, tenNhaCungCap, ngayNhap);

                // Hiển thị form CT_HoaDonNhap
                ctForm.Show();
            }
        }
    }
}
