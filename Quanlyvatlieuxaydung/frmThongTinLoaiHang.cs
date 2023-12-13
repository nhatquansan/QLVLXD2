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
    public partial class frmThongTinLoaiHang : Form
    {
        private bool isAddingNew = false;
        DBConnect db = new DBConnect();
        DataTable dt_loaihang = new DataTable();
        public frmThongTinLoaiHang()
        {
            InitializeComponent();
            string selectstr = "select * from LoaiHangHoa";
            dt_loaihang = db.getDataTable(selectstr);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt_loaihang.Columns[0];
            dt_loaihang.PrimaryKey = key;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        public void Load_dgvLoaiHang()
        {
            dataGridView1.DataSource = dt_loaihang;
            Databingding(dt_loaihang);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dt_loaihang.Rows.Count)
            {
                textBox1.Text = dt_loaihang.Rows[e.RowIndex]["MaLoai"].ToString();
                textBox2.Text = dt_loaihang.Rows[e.RowIndex]["TenLoai"].ToString();
                textBox4.Text = dt_loaihang.Rows[e.RowIndex]["ThongTin"].ToString();
                textBox3.Text = dt_loaihang.Rows[e.RowIndex]["TrangThai"].ToString();
            }
        }

        void Databingding(DataTable pDT)
        {
            if (pDT.Rows.Count > 0)
            {
                int currentRowIndex = dataGridView1.CurrentRow.Index;
                textBox1.Text = pDT.Rows[currentRowIndex]["MaLoai"].ToString();
                textBox2.Text = pDT.Rows[currentRowIndex]["TenLoai"].ToString();
                textBox4.Text = pDT.Rows[currentRowIndex]["ThongTin"].ToString();
                textBox3.Text = pDT.Rows[currentRowIndex]["TrangThai"].ToString();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
            }

        }
        private void frmThongTinLoaiHang_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            radioButton1.Checked = true;
            Load_dgvLoaiHang();
            button7.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)//Them
        {
            Load_dgvLoaiHang();
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
            Load_dgvLoaiHang();
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
            Load_dgvLoaiHang();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox1.Focus();
        }

        private void button9_Click(object sender, EventArgs e)//XOa
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maLoaiToDelete = textBox1.Text;
            string tenLoai = textBox2.Text;

            string checkQuery = "SELECT COUNT(*) FROM HangHoa WHERE MaLoai = '" + maLoaiToDelete + "'";
            int count = Convert.ToInt32(db.getScalar(checkQuery));

            if (count > 0)
            {
                // Mã hàng hóa đang tồn tại trong Kho
                MessageBox.Show("Đang có hàng hóa thuộc loại hàng này. Không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin của loại hàng là " + tenLoai + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataRow dr = dt_loaihang.Rows.Find(maLoaiToDelete);
                    if (dr != null)
                    {
                        dr.Delete();
                    }

                    string sql = "select * from LoaiHangHoa ";
                    int kq = db.updateDataBase(sql, dt_loaihang);

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

        private bool IsMaLoaiDuplicated(string maLoai)
        {
            DataRow existingRow = dt_loaihang.Rows.Find(maLoai);
            return existingRow != null;
        }


        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0) //Nếu chưa nhập mã KH
            {
                MessageBox.Show("Bạn phải nhập mã loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim().Length == 0) //Nếu chưa nhập Tên KH
            {
                MessageBox.Show("Bạn phải nhập tên loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (textBox4.Text.Trim().Length == 0) //Nếu chưa nhập Địa chỉ
            {
                MessageBox.Show("Bạn phải nhập mô tả cho loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0) //Nếu chưa nhập SDT
            {
                MessageBox.Show("Bạn phải nhập trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }


            DataRow dr;

            if (isAddingNew)
            {
                if (IsMaLoaiDuplicated(textBox1.Text))
                {
                    MessageBox.Show("Mã loại hàng đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;
                }
                dr = dt_loaihang.NewRow();

                dr["MaLoai"] = textBox1.Text;
                dr["TenLoai"] = textBox2.Text;
                dr["ThongTin"] = textBox4.Text;
                dr["TrangThai"] = textBox3.Text;

                dt_loaihang.Rows.Add(dr);
            }
            else // Sửa
            {
                dr = dt_loaihang.Rows.Find(textBox1.Text);
                if (dr != null)
                {
                    dr["TenLoai"] = textBox2.Text;
                    dr["ThongTin"] = textBox4.Text;
                    dr["TrangThai"] = textBox3.Text;
                }
            }

            string sql = "select * from LoaiHangHoa ";
            int kq = db.updateDataBase(sql, dt_loaihang);

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
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã loại không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isAddingNew = false;

            Load_dgvLoaiHang();

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear(); // Xóa thông báo lỗi trước đó

            if (!char.IsControl(e.KeyChar) && (e.KeyChar != '0' && e.KeyChar != '1'))
            {
                e.Handled = true;
                errorProvider1.SetError(textBox3, "Trạng thái chỉ được nhập 0 hoặc 1 ");
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
                string rowFilter = string.Format("{0} like '{1}'", "MaLoai", "*" + textBox5.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            else if (radioButton2.Checked)
            {
                string rowFilter = string.Format("{0} like '{1}'", "TenLoai", "*" + textBox5.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
        }




    }
}
