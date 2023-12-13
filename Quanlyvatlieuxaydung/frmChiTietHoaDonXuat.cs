using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quanlyvatlieuxaydung
{
    public partial class frmChiTietHoaDonXuat : Form
    {
        private bool isAddingNew = false;
        private string soHoaDonXuat;
        private string tenNhanVien;
        private string tenKhachHang;
        private DateTime ngayXuat;
        DBConnect db = new DBConnect();
        DataTable dt_ct_hdx = new DataTable();
        public frmChiTietHoaDonXuat(string soHoaDonXuat, string tenNhanVien, string tenKhachHang, DateTime ngayXuat)
        {

            InitializeComponent();

            string selectstr = "SELECT cthddxk.IdXuat ,cthddxk.SoHoaDonXuat, cthddxk.SoLuong,cthddxk.DonGia, hh.TenHangHoa, hh.MaHH " +
             "FROM ChiTietHoaDonBanHang cthddxk " +
             "INNER JOIN HangHoa hh ON cthddxk.MaHH = hh.MaHH WHERE cthddxk.SoHoaDonXuat = '" + soHoaDonXuat + "'";

            dt_ct_hdx = db.getDataTable(selectstr);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt_ct_hdx.Columns["IdXuat"];
            dt_ct_hdx.PrimaryKey = key;

            this.soHoaDonXuat = soHoaDonXuat;
            this.tenNhanVien = tenNhanVien;
            this.tenKhachHang = tenKhachHang;
            this.ngayXuat = ngayXuat;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void frmChiTietHoaDonXuat_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox2.Enabled = false;
            textBox5.Enabled = false;

            textBox1.Text = soHoaDonXuat;
            textBox5.Text = tenNhanVien;
            textBox2.Text = tenKhachHang;
            dateTimePicker1.Value = ngayXuat;

            textBox8.Enabled = false;
            comboBox1.Enabled = false;
            textBox7.Enabled = false;
            textBox4.Enabled = false;
            button2.Enabled = false;
            load_cboHangHoa();
            Load_dgvChiTietHoaDonXuat();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dt_ct_hdx.Rows.Count)
            {
                textBox8.Text = dt_ct_hdx.Rows[e.RowIndex]["IdXuat"].ToString();
                comboBox1.SelectedValue = dt_ct_hdx.Rows[e.RowIndex]["MaHH"].ToString();
                textBox7.Text = dt_ct_hdx.Rows[e.RowIndex]["DonGia"].ToString();
                textBox4.Text = dt_ct_hdx.Rows[e.RowIndex]["SoLuong"].ToString();
            }
        }
        public void load_cboHangHoa()
        {
            string selectstr = "select * from HangHoa";
            DataTable dt_HH = db.getDataTable(selectstr);
            comboBox1.DataSource = dt_HH;
            comboBox1.DisplayMember = "TenHangHoa";
            comboBox1.ValueMember = "MaHH";
        }
        public void Load_dgvChiTietHoaDonXuat()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt_ct_hdx;
            Databingding(dt_ct_hdx);
        }
        void Databingding(DataTable pDT)
        {
            if (pDT.Rows.Count > 0)
            {
                int currentRowIndex = dataGridView1.CurrentRow.Index;
                textBox8.Text = pDT.Rows[currentRowIndex]["IdXuat"].ToString();
                comboBox1.SelectedValue = pDT.Rows[currentRowIndex]["MaHH"].ToString();
                textBox7.Text = pDT.Rows[currentRowIndex]["DonGia"].ToString();
                textBox4.Text = pDT.Rows[currentRowIndex]["SoLuong"].ToString();
            }
            else
            {
                textBox8.Text = "";
                comboBox1.Text = "";
                textBox7.Text = "";
                textBox4.Text = "";
            }
        }

        private void button13_Click(object sender, EventArgs e)//Them
        {
            textBox8.Enabled = true;
            comboBox1.Enabled = true;
            textBox7.Enabled = true;
            textBox4.Enabled = true;


            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = -1;
            textBox8.Text = "";
            textBox7.Text = "";
            textBox4.Text = "";
            comboBox1.Focus();

            button2.Enabled = true;
            isAddingNew = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox4.Enabled = true;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = -1;
            textBox7.Text = "";
            textBox8.Text = "";
            textBox4.Text = "";
            comboBox1.Focus();

            button2.Enabled = true;
            isAddingNew = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Load_dgvChiTietHoaDonXuat();
            comboBox1.SelectedIndex = -1;
            textBox7.Text = "";
            textBox8.Text = "";
            textBox4.Text = "";

            dataGridView1.ClearSelection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string idXuatToDelete = textBox8.Text;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn xuất có mã " + idXuatToDelete + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DataRow dr = dt_ct_hdx.Rows.Find(idXuatToDelete);
                if (dr != null)
                {
                    dr.Delete();
                }

                string sql = "select * from ChiTietHoaDonBanHang ";
                int kq = db.updateDataBase(sql, dt_ct_hdx);

                if (kq > 0)
                {
                    MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa không được !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                isAddingNew = true;
                textBox8.Text = "";
                textBox7.Text = "";
                textBox4.Text = "";
                comboBox1.SelectedIndex = -1;

            }
        }
        private bool IsIDXuatNDuplicated(string idxuat)
        {
            DataRow existingRow = dt_ct_hdx.Rows.Find(idxuat);
            return existingRow != null;
        }

        private void button2_Click(object sender, EventArgs e)//Luu
        {
            if (textBox8.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chi tiết hóa đơn bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox8.Focus();
                return;
            }

            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }

            if (textBox4.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            if (textBox7.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox7.Focus();
                return;
            }

            int soLuongTrongKhoTruoc = LaySoLuongTrongKho(comboBox1.SelectedValue.ToString());

            DataRow dr;

            if (isAddingNew)
            {
                if (IsIDXuatNDuplicated(textBox8.Text))
                {
                    MessageBox.Show("Mã chi tiết hóa đơn xuất đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox8.Text = "";
                    textBox8.Focus();
                    return;
                }
                dr = dt_ct_hdx.NewRow();

                dr["IdXuat"] = textBox8.Text;
                dr["SoHoaDonXuat"] = soHoaDonXuat;
                dr["TenHangHoa"] = comboBox1.Text;
                dr["MaHH"] = comboBox1.SelectedValue.ToString();
                dr["SoLuong"] = textBox4.Text;
                dr["DonGia"] = textBox7.Text;
                dt_ct_hdx.Rows.Add(dr);

                int soLuongMoi = Convert.ToInt32(textBox4.Text);
                CapNhatSoLuongTrongKho(comboBox1.SelectedValue.ToString(), soLuongTrongKhoTruoc - soLuongMoi);
            }
            else // Sửa
            {
                dr = dt_ct_hdx.Rows.Find(textBox8.Text);
                if (dr != null)
                {
                    int soLuongHienTai = Convert.ToInt32(dr["SoLuong"]);

                    int soLuongMoi = Convert.ToInt32(textBox4.Text);
                    int chenhLechSoLuong = soLuongMoi - soLuongHienTai;

                    CapNhatSoLuongTrongKho(comboBox1.SelectedValue.ToString(), soLuongTrongKhoTruoc - chenhLechSoLuong);

                    dr["MaHH"] = comboBox1.SelectedValue.ToString();
                    dr["TenHangHoa"] = comboBox1.Text;
                    dr["SoHoaDonXuat"] = soHoaDonXuat;
                    dr["SoLuong"] = textBox4.Text;
                    dr["DonGia"] = textBox7.Text;
                }
            }

            string sql = "select * from ChiTietHoaDonBanHang ";
            int kq = db.updateDataBase(sql, dt_ct_hdx);

            if (kq > 0)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                comboBox1.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox4.Enabled = false;
                button2.Enabled = false;

                Load_dgvChiTietHoaDonXuat();

                dataGridView1.ClearSelection();

            }
            else
            {
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã hàng hóa không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            isAddingNew = false;
        }

        private int LaySoLuongTrongKho(string maHangHoa)
        {
            int soLuongTrongKho = 0;
            string query = "SELECT SoLuong FROM Kho WHERE MaHH = '" + maHangHoa + "'";

            using (SqlDataReader reader = db.getDataReader(query))
            {
                if (reader.Read())
                {
                    soLuongTrongKho = Convert.ToInt32(reader["SoLuong"]);
                }
            }

            return soLuongTrongKho;
        }
        private void CapNhatSoLuongTrongKho(string maHangHoa, int soLuongMoi)
        {
            string query = "UPDATE Kho SET SoLuong = " + soLuongMoi + " WHERE MaHH = '" + maHangHoa + "'";
            db.getNonQuery(query);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn kí tự nhập vào
                errorProvider1.SetError(textBox4, "Chỉ được nhập số.");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Chặn kí tự nhập vào
                errorProvider1.SetError(textBox7, "Chỉ được nhập số.");
            }
            else
            {
                errorProvider1.SetError(textBox7, "");
            }
        }
    }
}
