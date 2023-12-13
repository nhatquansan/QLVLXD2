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
    public partial class frmThongTinNhaCungCap : Form
    {
        private bool isAddingNew = false;
        DBConnect db = new DBConnect();
        DataTable dt_ncc = new DataTable();
        public frmThongTinNhaCungCap()
        {
            InitializeComponent();
            string selectstr = "select * from NhaCungCap";
            dt_ncc = db.getDataTable(selectstr);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt_ncc.Columns[0];
            dt_ncc.PrimaryKey = key;

            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        public void Load_dgvNhaCungCap()
        {
            dataGridView1.DataSource = dt_ncc;
            Databingding(dt_ncc);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dt_ncc.Rows.Count)
            {
                textBox1.Text = dt_ncc.Rows[e.RowIndex]["MaNCC"].ToString();
                textBox2.Text = dt_ncc.Rows[e.RowIndex]["TenNCC"].ToString();
                textBox4.Text = dt_ncc.Rows[e.RowIndex]["DiaChi"].ToString();
                textBox3.Text = dt_ncc.Rows[e.RowIndex]["SDT"].ToString();
            }
        }

        void Databingding(DataTable pDT)
        {
            if (pDT.Rows.Count > 0)
            {
                int currentRowIndex = dataGridView1.CurrentRow.Index;
                textBox1.Text = pDT.Rows[currentRowIndex]["MaNCC"].ToString();
                textBox2.Text = pDT.Rows[currentRowIndex]["TenNCC"].ToString();
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

        private void frmThongTinNhaCungCap_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            radioButton1.Checked = true;
            button7.Enabled = false;
            Load_dgvNhaCungCap();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Load_dgvNhaCungCap();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox4.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox1.Focus();
            button7.Enabled = true;
            isAddingNew = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Load_dgvNhaCungCap();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox4.Enabled = true;
            textBox3.Enabled = true;
            
            textBox1.Focus();
            isAddingNew = false;
            button7.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Load_dgvNhaCungCap();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox1.Focus();
        }

        private void button9_Click(object sender, EventArgs e) //Xoa
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maNCCToDelete = textBox1.Text;
            string tenNCC = textBox2.Text;

            string checkQuery = "SELECT COUNT(*) FROM DonXuatKho WHERE MaNCC = '" + maNCCToDelete + "'";
            int countInKho = Convert.ToInt32(db.getScalar(checkQuery));

            if (countInKho > 0)
            {
                // Mã hàng hóa đang tồn tại trong Kho
                MessageBox.Show("Nhà cung cấp hiện đang có trong đơn hàng. Không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin nhà cung cấp " + tenNCC + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataRow dr = dt_ncc.Rows.Find(maNCCToDelete);
                    if (dr != null)
                    {
                        dr.Delete();
                    }

                    string sql = "select * from NhaCungCap ";
                    int kq = db.updateDataBase(sql, dt_ncc);

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
        private bool IsMaNCCDuplicated(string maNCC)
        {
            DataRow existingRow = dt_ncc.Rows.Find(maNCC);
            return existingRow != null;
        }
        private void button7_Click(object sender, EventArgs e)//Luu
        {
            if (textBox1.Text.Trim().Length == 0) //Nếu chưa nhập mã KH
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim().Length == 0) //Nếu chưa nhập Tên KH
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (textBox4.Text.Trim().Length == 0) //Nếu chưa nhập Địa chỉ
            {
                MessageBox.Show("Bạn phải nhập địa chỉ nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0) //Nếu chưa nhập SDT
            {
                MessageBox.Show("Bạn phải nhập số điện thoại nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }


            DataRow dr;

            if (isAddingNew)
            {
                if (IsMaNCCDuplicated(textBox1.Text))
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;
                }
                dr = dt_ncc.NewRow();

                dr["MaNCC"] = textBox1.Text;
                dr["TenNCC"] = textBox2.Text;
                dr["DiaChi"] = textBox4.Text;
                dr["SDT"] = textBox3.Text;

                dt_ncc.Rows.Add(dr);
            }
            else // Sửa
            {
                dr = dt_ncc.Rows.Find(textBox1.Text);
                if (dr != null)
                {
                    dr["TenNCC"] = textBox2.Text;
                    dr["DiaChi"] = textBox4.Text;
                    dr["SDT"] = textBox3.Text;
                }
            }

            string sql = "select * from NhaCungCap ";
            int kq = db.updateDataBase(sql, dt_ncc);

            if (kq > 0)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                button7.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox4.Enabled = false;
                textBox3.Enabled = false;
            }
            else
            {
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã nhà cung cấp không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isAddingNew = false;

            Load_dgvNhaCungCap();
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string rowFilter = string.Format("{0} like '{1}'", "MaNCC", "*" + textBox5.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            else if (radioButton2.Checked)
            {
                string rowFilter = string.Format("{0} like '{1}'", "TenNCC", "*" + textBox5.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
        }




    }
}
