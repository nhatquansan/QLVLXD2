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
   
    public partial class frmThongTinNhanVien : Form
    {
        private bool isAddingNew = false;
        DBConnect db = new DBConnect();
        DataTable dt_nhanvien= new DataTable();
        DataEncryptor StringCipher = new DataEncryptor();
        public frmThongTinNhanVien()
        {
            InitializeComponent();
            string selectstr = "select * from NhanVien";
            dt_nhanvien = db.getDataTable(selectstr);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt_nhanvien.Columns[0];
            dt_nhanvien.PrimaryKey = key;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        public void Load_dgvNhanVien()
        {
            dataGridView1.DataSource = dt_nhanvien;
            Databingding(dt_nhanvien);
        }
        public void load_cboGioiTinh()
        {
            string selectstr = "select DISTINCT  * from NhanVien";
            DataTable dt_nv = db.getDataTable(selectstr);
            comboBox1.DataSource = dt_nv;
            comboBox1.DisplayMember = "GioiTinh";
            comboBox1.ValueMember = "MaNV";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dt_nhanvien.Rows.Count)
            {
                textBox1.Text = dt_nhanvien.Rows[e.RowIndex]["MaNV"].ToString();
                textBox2.Text = dt_nhanvien.Rows[e.RowIndex]["TenNV"].ToString();
                textBox3.Text = dt_nhanvien.Rows[e.RowIndex]["DiaChi"].ToString();
                textBox4.Text = dt_nhanvien.Rows[e.RowIndex]["SDT"].ToString();
                textBox5.Text = dt_nhanvien.Rows[e.RowIndex]["ChucVu"].ToString();
                textBox6.Text = dt_nhanvien.Rows[e.RowIndex]["Loai"].ToString();
                textBox7.Text = textBox7.Text = "***************";
                textBox8.Text = dt_nhanvien.Rows[e.RowIndex]["TrangThai"].ToString();
                comboBox1.Text = dt_nhanvien.Rows[e.RowIndex]["GioiTinh"].ToString();
                dateTimePicker1.Text = dt_nhanvien.Rows[e.RowIndex]["NgaySinh"].ToString();
            }
        }
        void Databingding(DataTable pDT)
        {
            if (pDT.Rows.Count > 0)
            {
                int currentRowIndex = dataGridView1.CurrentRow.Index;
                textBox1.Text = pDT.Rows[currentRowIndex]["MaNV"].ToString();
                textBox2.Text = pDT.Rows[currentRowIndex]["TenNV"].ToString();
                textBox3.Text = pDT.Rows[currentRowIndex]["DiaChi"].ToString();
                textBox4.Text = pDT.Rows[currentRowIndex]["SDT"].ToString();
                textBox5.Text = pDT.Rows[currentRowIndex]["ChucVu"].ToString();
                textBox6.Text = pDT.Rows[currentRowIndex]["Loai"].ToString();
                textBox7.Text = "***************";
                textBox8.Text = pDT.Rows[currentRowIndex]["TrangThai"].ToString();
                dateTimePicker1.Text = pDT.Rows[currentRowIndex]["NgaySinh"].ToString();
                comboBox1.SelectedValue = pDT.Rows[currentRowIndex]["MaNV"].ToString();

            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                
            }

        }







        private void frmThongTinNhanVien_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            Load_dgvNhanVien();
            load_cboGioiTinh();
            button5.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Load_dgvNhanVien();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Load_dgvNhanVien();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            comboBox1.Enabled = true;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox1.Focus();
            button5.Enabled = true;
            isAddingNew = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Load_dgvNhanVien();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            comboBox1.Enabled = true;

            
            textBox1.Focus();
            button5.Enabled = true;
            isAddingNew = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maNVToDelete = textBox1.Text;
            string tenNV = textBox2.Text;

            string checkInKhoQuery = "SELECT COUNT(*) FROM DonNhapKho WHERE MaNV = '" + maNVToDelete + "'";
            int countInDNkho = Convert.ToInt32(db.getScalar(checkInKhoQuery));

            string checkInKhoQuery1 = "SELECT COUNT(*) FROM DonXuatKho WHERE MaNV = '" + maNVToDelete + "'";
            int countInDXkho1 = Convert.ToInt32(db.getScalar(checkInKhoQuery1));
            if (countInDNkho > 0)
            {
                // Mã hàng hóa đang tồn tại trong don nhap kho
                MessageBox.Show("Nhân Viên này đang tồn tại trong Hóa đơn nhập. Không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (countInDXkho1 > 0)
            {
                // Mã hàng hóa đang tồn tại trong don nhap kho
                MessageBox.Show("Nhân Viên này đang tồn tại trong Hóa đơn xuất. Không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin của hàng hóa " + tenNV + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataRow dr = dt_nhanvien.Rows.Find(maNVToDelete);
                    if (dr != null)
                    {
                        dr.Delete();
                    }

                    string sql = "select * from NhanVien ";
                    int kq = db.updateDataBase(sql, dt_nhanvien);

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
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox3.Text = "";
                }
            }
        }
        private bool IsMaHHDuplicated(string maNV)
        {
            DataRow existingRow = dt_nhanvien.Rows.Find(maNV);
            return existingRow != null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã Nhân Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên Nhân Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đia chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (textBox4.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            if (textBox5.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ của mình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox5.Focus();
                return;
            }
            if (textBox6.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox6.Focus();
                return;
            }
            if (textBox7.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox7.Focus();
                return;
            }
            if (textBox8.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox8.Focus();
                return;
            }

           
            DataRow dr;

            if (isAddingNew)
            {
                if (IsMaHHDuplicated(textBox1.Text))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;
                }
                string plaintext = textBox7.Text.ToString();
                string Encrypt = StringCipher.Encrypt(plaintext);
                dr = dt_nhanvien.NewRow();

                dr["MaNV"] = textBox1.Text;
                dr["TenNV"] = textBox2.Text;
                dr["GioiTinh"] = comboBox1.SelectedValue.ToString();
                dr["NgaySinh"] = dateTimePicker1.Text;
                dr["DiaChi"] = textBox3.Text;
                dr["SDT"] = textBox4.Text;
                dr["ChucVu"] = textBox5.Text;
                dr["Loai"] = textBox6.Text;
                dr["MatKhau"] = Encrypt;
                dr["TrangThai"] = textBox8.Text;
                dt_nhanvien.Rows.Add(dr);
            }
            else // Sửa
            {
                dr = dt_nhanvien.Rows.Find(textBox1.Text);
                if (dr != null)
                {
                    dr["MaNV"] = textBox1.Text;
                    dr["TenNV"] = textBox2.Text;
                    dr["GioiTinh"] = comboBox1.SelectedValue.ToString();
                    dr["NgaySinh"] = dateTimePicker1.Text;
                    dr["DiaChi"] = textBox4.Text;
                    dr["SDT"] = textBox5.Text;
                    dr["ChucVu"] = textBox6.Text;
                    dr["Loai"] = textBox7.Text;
                    dr["MatKhau"] = textBox7.Text;
                    dr["TrangThai"] = textBox8.Text;
                }
            }

            string sql = "select * from NhanVien ";
            int kq = db.updateDataBase(sql, dt_nhanvien);

            if (kq > 0)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                button5.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox4.Enabled = false;
                textBox3.Enabled = false;
                comboBox1.Enabled = false;
            }
            else
            {
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã Nhân Viên không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            isAddingNew = false;
            Load_dgvNhanVien();
        }
    }
}
