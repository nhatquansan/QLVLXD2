namespace Quanlyvatlieuxaydung
{
    partial class frmBaoCaoXuat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_Date = new System.Windows.Forms.CheckBox();
            this.cbo_NV = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_NV = new System.Windows.Forms.CheckBox();
            this.btn_In = new System.Windows.Forms.Button();
            this.btn_ThucHien = new System.Windows.Forms.Button();
            this.dateTP_ToDate = new System.Windows.Forms.DateTimePicker();
            this.dateTP_FromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_XuatKho = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_XuatKho)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(159, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1732, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(542, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(656, 54);
            this.label3.TabIndex = 0;
            this.label3.Text = "BÁO CÁO HÀNG XUẤT KHO";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cb_Date);
            this.groupBox2.Controls.Add(this.cbo_NV);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cb_NV);
            this.groupBox2.Controls.Add(this.btn_In);
            this.groupBox2.Controls.Add(this.btn_ThucHien);
            this.groupBox2.Controls.Add(this.dateTP_ToDate);
            this.groupBox2.Controls.Add(this.dateTP_FromDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(159, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 554);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức Năng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(77, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "Theo Thời Gian";
            // 
            // cb_Date
            // 
            this.cb_Date.AutoSize = true;
            this.cb_Date.Location = new System.Drawing.Point(42, 64);
            this.cb_Date.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_Date.Name = "cb_Date";
            this.cb_Date.Size = new System.Drawing.Size(18, 17);
            this.cb_Date.TabIndex = 19;
            this.cb_Date.UseVisualStyleBackColor = true;
            // 
            // cbo_NV
            // 
            this.cbo_NV.FormattingEnabled = true;
            this.cbo_NV.Location = new System.Drawing.Point(42, 280);
            this.cbo_NV.Name = "cbo_NV";
            this.cbo_NV.Size = new System.Drawing.Size(237, 24);
            this.cbo_NV.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(77, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Theo Nhân Viên";
            // 
            // cb_NV
            // 
            this.cb_NV.AutoSize = true;
            this.cb_NV.Location = new System.Drawing.Point(42, 257);
            this.cb_NV.Name = "cb_NV";
            this.cb_NV.Size = new System.Drawing.Size(18, 17);
            this.cb_NV.TabIndex = 12;
            this.cb_NV.UseVisualStyleBackColor = true;
            // 
            // btn_In
            // 
            this.btn_In.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_In.Location = new System.Drawing.Point(59, 470);
            this.btn_In.Name = "btn_In";
            this.btn_In.Size = new System.Drawing.Size(188, 66);
            this.btn_In.TabIndex = 6;
            this.btn_In.Text = "In Tổng Báo Cáo";
            this.btn_In.UseVisualStyleBackColor = true;
            this.btn_In.Click += new System.EventHandler(this.btn_In_Click);
            // 
            // btn_ThucHien
            // 
            this.btn_ThucHien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_ThucHien.Location = new System.Drawing.Point(59, 398);
            this.btn_ThucHien.Name = "btn_ThucHien";
            this.btn_ThucHien.Size = new System.Drawing.Size(188, 65);
            this.btn_ThucHien.TabIndex = 5;
            this.btn_ThucHien.Text = "Thực Hiện";
            this.btn_ThucHien.UseVisualStyleBackColor = true;
            this.btn_ThucHien.Click += new System.EventHandler(this.btn_ThucHien_Click);
            // 
            // dateTP_ToDate
            // 
            this.dateTP_ToDate.Location = new System.Drawing.Point(42, 215);
            this.dateTP_ToDate.Name = "dateTP_ToDate";
            this.dateTP_ToDate.Size = new System.Drawing.Size(237, 22);
            this.dateTP_ToDate.TabIndex = 4;
            // 
            // dateTP_FromDate
            // 
            this.dateTP_FromDate.Location = new System.Drawing.Point(42, 144);
            this.dateTP_FromDate.Name = "dateTP_FromDate";
            this.dateTP_FromDate.Size = new System.Drawing.Size(237, 22);
            this.dateTP_FromDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến Ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Từ Ngày";
            // 
            // dgv_XuatKho
            // 
            this.dgv_XuatKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_XuatKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column8,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgv_XuatKho.Location = new System.Drawing.Point(489, 120);
            this.dgv_XuatKho.Name = "dgv_XuatKho";
            this.dgv_XuatKho.RowHeadersWidth = 51;
            this.dgv_XuatKho.RowTemplate.Height = 24;
            this.dgv_XuatKho.Size = new System.Drawing.Size(1412, 528);
            this.dgv_XuatKho.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "SoHoaDonXuat";
            this.Column1.HeaderText = "Số Hóa Đơn Xuất";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "TenNV";
            this.Column8.HeaderText = "Tên Nhân Viên";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenHangHoa";
            this.Column2.HeaderText = "Tên Hàng Hóa";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "XuatXu";
            this.Column3.HeaderText = "Xuất Xứ";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DonVi";
            this.Column4.HeaderText = "Đơn Vị";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "SoLuong";
            this.Column5.HeaderText = "Số Lượng";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "DonGia";
            this.Column6.HeaderText = "Đơn Giá";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "NgayXuat";
            this.Column7.HeaderText = "Ngày Xuất";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // frmBaoCaoXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 683);
            this.Controls.Add(this.dgv_XuatKho);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBaoCaoXuat";
            this.Text = "Báo Cáo Xuất";
            this.Load += new System.EventHandler(this.frmBaoCaoXuat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_XuatKho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbo_NV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cb_NV;
        private System.Windows.Forms.Button btn_In;
        private System.Windows.Forms.Button btn_ThucHien;
        private System.Windows.Forms.DateTimePicker dateTP_ToDate;
        private System.Windows.Forms.DateTimePicker dateTP_FromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_XuatKho;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cb_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}