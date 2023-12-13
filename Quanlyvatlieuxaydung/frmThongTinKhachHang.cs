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
    public partial class frmThongTinKhachHang : Form
    {
        private bool isAddingNew = false;
        DBConnect db = new DBConnect();
        DataTable dt_khachhang = new DataTable();
        public frmThongTinKhachHang()
        {
            InitializeComponent();
            string selectstr = "select * from KhachHang";
            dt_khachhang = db.getDataTable(selectstr);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt_khachhang.Columns[0];
            dt_khachhang.PrimaryKey = key;
            dataGridView1.CellClick += dataGridView1_CellClick;

        }
        public void Load_dgvKhachHang()
        {
            dataGridView1.DataSource = dt_khachhang;
            Databingding(dt_khachhang);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dt_khachhang.Rows.Count)
            {
                textBox1.Text = dt_khachhang.Rows[e.RowIndex]["MaKH"].ToString();
                textBox2.Text = dt_khachhang.Rows[e.RowIndex]["TenKH"].ToString();
                textBox4.Text = dt_khachhang.Rows[e.RowIndex]["DiaChi"].ToString();
                textBox3.Text = dt_khachhang.Rows[e.RowIndex]["SDT"].ToString();
            }
        }

        void Databingding(DataTable pDT)
        {
            if (pDT.Rows.Count > 0)
            {
                int currentRowIndex = dataGridView1.CurrentRow.Index;
                textBox1.Text = pDT.Rows[currentRowIndex]["MaKH"].ToString();
                textBox2.Text = pDT.Rows[currentRowIndex]["TenKH"].ToString();
                textBox4.Text = pDT.Rows[currentRowIndex]["DiaChi"].ToString();
                textBox3.Text = pDT.Rows[currentRowIndex]["SDT"].ToString();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
            }

        }

        private void frmThongTinKhachHang_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            radioButton1.Checked = true;
            Load_dgvKhachHang();
            button5.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)//Them
        {

            Load_dgvKhachHang();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox4.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox1.Focus();
            button5.Enabled = true;
            isAddingNew = true;
        }

        private void button4_Click(object sender, EventArgs e)//Sua
        {
            Load_dgvKhachHang();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox4.Enabled = true;
            textBox3.Enabled = true;
            
            textBox1.Focus();
            isAddingNew = false;
            button5.Enabled = true;
        }
        private void button11_Click(object sender, EventArgs e)//Lam moi
        {
            Load_dgvKhachHang();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox1.Focus();
        }


        private void button3_Click(object sender, EventArgs e)//Xoa
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maKHToDelete = textBox1.Text;
            string tenKH = textBox2.Text; // Lấy tên khách hàng để hiển thị

            string checkInKhoQuery = "SELECT COUNT(*) FROM DonXuatKho WHERE MaKH = '" + maKHToDelete + "'";
            int count = Convert.ToInt32(db.getScalar(checkInKhoQuery));

            if (count > 0)
            {
                // Mã hàng hóa đang tồn tại trong Kho
                MessageBox.Show("Khách hàng đang có đơn hàng. Không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin của khách hàng " + tenKH + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataRow dr = dt_khachhang.Rows.Find(maKHToDelete);
                    if (dr != null)
                    {
                        dr.Delete();
                    }

                    string sql = "select * from KhachHang ";
                    int kq = db.updateDataBase(sql, dt_khachhang);

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

        private bool IsMaKHDuplicated(string maKH)
        {
            DataRow existingRow = dt_khachhang.Rows.Find(maKH);
            return existingRow != null;
        }



        private void button5_Click(object sender, EventArgs e)//Luu
        {
            if (textBox1.Text.Trim().Length == 0) //Nếu chưa nhập mã KH
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim().Length == 0) //Nếu chưa nhập Tên KH
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (textBox4.Text.Trim().Length == 0) //Nếu chưa nhập Địa chỉ
            {
                MessageBox.Show("Bạn phải nhập địa chỉ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0) //Nếu chưa nhập SDT
            {
                MessageBox.Show("Bạn phải nhập số điện thoại khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }


            DataRow dr;

            if (isAddingNew)
            {
                if (IsMaKHDuplicated(textBox1.Text))
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;
                }
                dr = dt_khachhang.NewRow();

                dr["MaKH"] = textBox1.Text;
                dr["TenKH"] = textBox2.Text;
                dr["DiaChi"] = textBox4.Text;
                dr["SDT"] = textBox3.Text;

                dt_khachhang.Rows.Add(dr);
            }
            else // Sửa
            {
                dr = dt_khachhang.Rows.Find(textBox1.Text);
                if (dr != null)
                {
                    dr["TenKH"] = textBox2.Text;
                    dr["DiaChi"] = textBox4.Text;
                    dr["SDT"] = textBox3.Text;
                }
            }

            string sql = "select * from KhachHang ";
            int kq = db.updateDataBase(sql, dt_khachhang);

            if (kq > 0)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                button5.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox4.Enabled = false;
                textBox3.Enabled = false;
            }
            else
            {
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã khách hàng không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isAddingNew = false;

            Load_dgvKhachHang();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)//Tim Kiem
        {
            if (radioButton1.Checked)
            {
                string rowFilter = string.Format("{0} like '{1}'", "MaKH", "*" + textBox5.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            else if (radioButton2.Checked)
            {
                string rowFilter = string.Format("{0} like '{1}'", "TenKH", "*" + textBox5.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear(); // Xóa thông báo lỗi trước đó

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(textBox3, "Chỉ được nhập số ở phần này");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

    }
}
