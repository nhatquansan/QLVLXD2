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
    public partial class frmChiTietHoaDonNhap : Form
    {
        private bool isAddingNew = false;
        private string soHoaDonNhap;
        private string tenNhanVien;
        private string tenNhaCungCap;
        private DateTime ngayNhap;
        DBConnect db = new DBConnect();
        DataTable dt_ct_hdn = new DataTable();
        public frmChiTietHoaDonNhap(string soHoaDonNhap, string tenNhanVien, string tenNhaCungCap, DateTime ngayNhap)
        {
            InitializeComponent();
            string selectstr = "SELECT cthddnk.IdNhap ,cthddnk.SoHoaDonNhap, cthddnk.SoLuong,cthddnk.DonGia, hh.TenHangHoa, hh.MaHH " +
             "FROM ChiTietHoaDonNhapKho cthddnk " +
             "INNER JOIN HangHoa hh ON cthddnk.MaHH = hh.MaHH WHERE cthddnk.SoHoaDonNhap = '" + soHoaDonNhap + "'";

            dt_ct_hdn = db.getDataTable(selectstr);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt_ct_hdn.Columns["IdNhap"];
            dt_ct_hdn.PrimaryKey = key;

            this.soHoaDonNhap = soHoaDonNhap;
            this.tenNhanVien = tenNhanVien;
            this.tenNhaCungCap = tenNhaCungCap;
            this.ngayNhap = ngayNhap;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void frmChiTietHoaDonNhap_Load(object sender, EventArgs e)
        {

            textBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox2.Enabled = false;
            textBox5.Enabled = false;

            textBox1.Text = soHoaDonNhap;
            textBox5.Text = tenNhanVien;
            textBox2.Text = tenNhaCungCap;
            dateTimePicker1.Value = ngayNhap;

            comboBox1.Enabled = false;
            textBox7.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button2.Enabled = false;
            load_cboHangHoa();
            Load_dgvChiTietHoaDonNhap();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dt_ct_hdn.Rows.Count)
            {
                textBox4.Text = dt_ct_hdn.Rows[e.RowIndex]["IdNhap"].ToString();
                comboBox1.SelectedValue = dt_ct_hdn.Rows[e.RowIndex]["MaHH"].ToString();
                textBox7.Text = dt_ct_hdn.Rows[e.RowIndex]["DonGia"].ToString();
                textBox3.Text = dt_ct_hdn.Rows[e.RowIndex]["SoLuong"].ToString();
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

        public void Load_dgvChiTietHoaDonNhap()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt_ct_hdn;
            Databingding(dt_ct_hdn);
        }

        void Databingding(DataTable pDT)
        {
            if (pDT.Rows.Count > 0)
            {
                int currentRowIndex = dataGridView1.CurrentRow.Index;
                textBox4.Text = pDT.Rows[currentRowIndex]["IdNhap"].ToString();
                comboBox1.SelectedValue = pDT.Rows[currentRowIndex]["MaHH"].ToString();
                textBox7.Text = pDT.Rows[currentRowIndex]["DonGia"].ToString();
                textBox3.Text = pDT.Rows[currentRowIndex]["SoLuong"].ToString();
            }
            else
            {
                textBox4.Text = "";
                comboBox1.Text = "";
                textBox7.Text = "";
                textBox3.Text = "";
            }
        }

        private void button13_Click(object sender, EventArgs e)//Them
        {
            comboBox1.Enabled = true;
            textBox7.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;


            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = -1;
            textBox7.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Focus();

            button2.Enabled = true;
            isAddingNew = true;
        }

        private void button3_Click(object sender, EventArgs e)//Sua
        {
            comboBox1.Enabled = true;
            textBox7.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = -1;
            textBox7.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Focus();

            button2.Enabled = true;
            isAddingNew = false;

        }

        private void button5_Click(object sender, EventArgs e)//LamMoi
        {
            Load_dgvChiTietHoaDonNhap();
            comboBox1.SelectedIndex = -1;
            textBox7.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            dataGridView1.ClearSelection();
        }

        private void button4_Click(object sender, EventArgs e)//Xoa
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string idNhapToDelete = textBox4.Text;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn nhập có mã " + idNhapToDelete + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DataRow dr = dt_ct_hdn.Rows.Find(idNhapToDelete);
                if (dr != null)
                {
                    dr.Delete();
                }

                string sql = "select * from ChiTietHoaDonNhapKho ";
                int kq = db.updateDataBase(sql, dt_ct_hdn);

                if (kq > 0)
                {
                    MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa không được !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                isAddingNew = true;
                textBox4.Text = "";
                textBox3.Text = "";
                textBox7.Text = "";
                comboBox1.SelectedIndex = -1;

            }
        }


        private bool IsIDNhapNDuplicated(string idnhap)
        {
            DataRow existingRow = dt_ct_hdn.Rows.Find(idnhap);
            return existingRow != null;
        }
        private void button2_Click(object sender, EventArgs e)//Luu
        {
            if (textBox4.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chi tiết hóa đơn bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }

            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }

            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
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
                if (IsIDNhapNDuplicated(textBox4.Text))
                {
                    MessageBox.Show("Mã chi tiết hóa đơn nhập đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox4.Text = "";
                    textBox4.Focus();
                    return;
                }
                dr = dt_ct_hdn.NewRow();

                dr["IdNhap"] = textBox4.Text;
                dr["SoHoaDonNhap"] = soHoaDonNhap;
                dr["TenHangHoa"] = comboBox1.Text;
                dr["MaHH"] = comboBox1.SelectedValue.ToString();
                dr["SoLuong"] = textBox3.Text;
                dr["DonGia"] = textBox7.Text;
                dt_ct_hdn.Rows.Add(dr);

                int soLuongMoi = Convert.ToInt32(textBox3.Text);
                CapNhatSoLuongTrongKho(comboBox1.SelectedValue.ToString(), soLuongTrongKhoTruoc + soLuongMoi);
            }
            else // Sửa
            {
                dr = dt_ct_hdn.Rows.Find(textBox4.Text);
                if (dr != null)
                {
                    int soLuongHienTai = Convert.ToInt32(dr["SoLuong"]);

                    int soLuongMoi = Convert.ToInt32(textBox3.Text);
                    int chenhLechSoLuong = soLuongMoi - soLuongHienTai;

                    CapNhatSoLuongTrongKho(comboBox1.SelectedValue.ToString(), soLuongTrongKhoTruoc + chenhLechSoLuong);

                    dr["MaHH"] = comboBox1.SelectedValue.ToString();
                    dr["TenHangHoa"] = comboBox1.Text;
                    dr["SoHoaDonNhap"] = soHoaDonNhap;
                    dr["SoLuong"] = textBox3.Text;
                    dr["DonGia"] = textBox7.Text;
                }
            }

            string sql = "select * from ChiTietHoaDonNhapKho ";
            int kq = db.updateDataBase(sql, dt_ct_hdn);

            if (kq > 0)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                comboBox1.Enabled = false;
                textBox7.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                button2.Enabled = false;

                Load_dgvChiTietHoaDonNhap();

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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn kí tự nhập vào
                errorProvider1.SetError(textBox3, "Chỉ được nhập số.");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
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
