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
    public partial class frmThongTinHangHoa : Form
    {
        private bool isAddingNew = false;
        DBConnect db = new DBConnect();
        DataTable dt_hanghoa = new DataTable();
        public frmThongTinHangHoa()
        {
            InitializeComponent();
            string selectstr = "select * from HangHoa";
            dt_hanghoa = db.getDataTable(selectstr);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt_hanghoa.Columns[0];
            dt_hanghoa.PrimaryKey = key;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        public void Load_dgvHangHoa()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt_hanghoa;
            Databingding(dt_hanghoa);
        }
        public void load_cboLoaiHang()
        {
            string selectstr = "select * from LoaiHangHoa";
            DataTable dt_LoaiHang = db.getDataTable(selectstr);
            comboBox1.DataSource = dt_LoaiHang;
            comboBox1.DisplayMember = "TenLoai";
            comboBox1.ValueMember = "MaLoai";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dt_hanghoa.Rows.Count)
            {
                textBox1.Text = dt_hanghoa.Rows[e.RowIndex]["MaHH"].ToString();
                textBox2.Text = dt_hanghoa.Rows[e.RowIndex]["TenHangHoa"].ToString();
                textBox4.Text = dt_hanghoa.Rows[e.RowIndex]["DonVi"].ToString();
                textBox3.Text = dt_hanghoa.Rows[e.RowIndex]["XuatXu"].ToString();
                comboBox1.SelectedValue = dt_hanghoa.Rows[e.RowIndex]["MaLoai"].ToString();
            }
        }
        void Databingding(DataTable pDT)
        {
            if (pDT.Rows.Count > 0)
            {
                int currentRowIndex = dataGridView1.CurrentRow.Index;
                textBox1.Text = pDT.Rows[currentRowIndex]["MaHH"].ToString();
                textBox2.Text = pDT.Rows[currentRowIndex]["TenHangHoa"].ToString();
                textBox4.Text = pDT.Rows[currentRowIndex]["DonVi"].ToString();
                textBox3.Text = pDT.Rows[currentRowIndex]["XuatXu"].ToString();
                comboBox1.SelectedValue = pDT.Rows[currentRowIndex]["MaLoai"].ToString();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
            }
        }

        private void frmThongTinHangHoa_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            comboBox1.Enabled = false;
            radioButton1.Checked = true;
            Load_dgvHangHoa();
            load_cboLoaiHang();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void button1_Click(object sender, EventArgs e)//Them
        {
            Load_dgvHangHoa();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox4.Enabled = true;
            textBox3.Enabled = true;
            comboBox1.Enabled = true;
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
            Load_dgvHangHoa();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox4.Enabled = true;
            textBox3.Enabled = true;
            comboBox1.Enabled = true;
            
            textBox1.Focus();
            isAddingNew = false;
            button5.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Load_dgvHangHoa();
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

            string maHHToDelete = textBox1.Text;
            string tenHH = textBox2.Text;

            string checkInKhoQuery = "SELECT COUNT(*) FROM Kho WHERE MaHH = '" + maHHToDelete + "'";
            int countInKho = Convert.ToInt32(db.getScalar(checkInKhoQuery));

            if (countInKho > 0)
            {
                // Mã hàng hóa đang tồn tại trong Kho
                MessageBox.Show("Hàng hóa này đang tồn tại trong kho. Không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin của hàng hóa " + tenHH + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataRow dr = dt_hanghoa.Rows.Find(maHHToDelete);
                    if (dr != null)
                    {
                        dr.Delete();
                    }

                    string sql = "select * from HangHoa ";
                    int kq = db.updateDataBase(sql, dt_hanghoa);

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

        private bool IsMaHHDuplicated(string maHH)
        {
            DataRow existingRow = dt_hanghoa.Rows.Find(maHH);
            return existingRow != null;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (textBox4.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn vị tính của hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập xuất xứ của hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }


            DataRow dr;

            if (isAddingNew)
            {
                if (IsMaHHDuplicated(textBox1.Text))
                {
                    MessageBox.Show("Mã hàng hóa đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;
                }
                dr = dt_hanghoa.NewRow();

                dr["MaHH"] = textBox1.Text;
                dr["TenHangHoa"] = textBox2.Text;
                dr["XuatXu"] = textBox4.Text;
                dr["DonVi"] = textBox3.Text;
                dr["MaLoai"] = comboBox1.SelectedValue.ToString();
                dt_hanghoa.Rows.Add(dr);
            }
            else // Sửa
            {
                dr = dt_hanghoa.Rows.Find(textBox1.Text);
                if (dr != null)
                {
                    dr["TenHangHoa"] = textBox2.Text;
                    dr["XuatXu"] = textBox4.Text;
                    dr["DonVi"] = textBox3.Text;
                    dr["MaLoai"] = comboBox1.SelectedValue.ToString();
                }
            }

            string sql = "select * from HangHoa ";
            int kq = db.updateDataBase(sql, dt_hanghoa);

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
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã hàng hóa không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            isAddingNew = false;
            Load_dgvHangHoa();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string rowFilter = string.Format("{0} like '{1}'", "MaHH", "*" + textBox5.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            else if (radioButton2.Checked)
            {
                string rowFilter = string.Format("{0} like '{1}'", "TenHangHoa", "*" + textBox5.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
        }
    }


}
