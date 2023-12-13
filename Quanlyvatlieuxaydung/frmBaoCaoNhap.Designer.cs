namespace Quanlyvatlieuxaydung
{
    partial class frmBaoCaoNhap
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
            this.dgv_NhapKho = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_Date = new System.Windows.Forms.CheckBox();
            this.cbo_NV = new System.Windows.Forms.ComboBox();
            this.cbo_NhaCC = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_NV = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_NCC = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.datePK_ToDate = new System.Windows.Forms.DateTimePicker();
            this.datePK_FromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhapKho)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_NhapKho
            // 
            this.dgv_NhapKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NhapKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column8,
            this.Column9,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgv_NhapKho.Location = new System.Drawing.Point(553, 112);
            this.dgv_NhapKho.Name = "dgv_NhapKho";
            this.dgv_NhapKho.RowHeadersWidth = 51;
            this.dgv_NhapKho.RowTemplate.Height = 24;
            this.dgv_NhapKho.Size = new System.Drawing.Size(1332, 528);
            this.dgv_NhapKho.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "SoHoaDonNhap";
            this.Column1.HeaderText = "Số Hóa Đơn Nhập";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "TenNCC";
            this.Column8.HeaderText = "Tên Nhà Cung Cấp";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 125;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "TenNV";
            this.Column9.HeaderText = "Tên Nhân Viên";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Width = 125;
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
            this.Column7.DataPropertyName = "NgayNhap";
            this.Column7.HeaderText = "Ngày Nhập Hàng";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cb_Date);
            this.groupBox2.Controls.Add(this.cbo_NV);
            this.groupBox2.Controls.Add(this.cbo_NhaCC);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cb_NV);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cb_NCC);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.datePK_ToDate);
            this.groupBox2.Controls.Add(this.datePK_FromDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(246, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 532);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức Năng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(66, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 18);
            this.label6.TabIndex = 18;
            this.label6.Text = "Theo Thời Gian";
            // 
            // cb_Date
            // 
            this.cb_Date.AutoSize = true;
            this.cb_Date.Location = new System.Drawing.Point(42, 45);
            this.cb_Date.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_Date.Name = "cb_Date";
            this.cb_Date.Size = new System.Drawing.Size(18, 17);
            this.cb_Date.TabIndex = 17;
            this.cb_Date.UseVisualStyleBackColor = true;
            // 
            // cbo_NV
            // 
            this.cbo_NV.FormattingEnabled = true;
            this.cbo_NV.Location = new System.Drawing.Point(42, 311);
            this.cbo_NV.Name = "cbo_NV";
            this.cbo_NV.Size = new System.Drawing.Size(237, 24);
            this.cbo_NV.TabIndex = 15;
            // 
            // cbo_NhaCC
            // 
            this.cbo_NhaCC.FormattingEnabled = true;
            this.cbo_NhaCC.Location = new System.Drawing.Point(42, 234);
            this.cbo_NhaCC.Name = "cbo_NhaCC";
            this.cbo_NhaCC.Size = new System.Drawing.Size(237, 24);
            this.cbo_NhaCC.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(78, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Theo Nhân Viên";
            // 
            // cb_NV
            // 
            this.cb_NV.AutoSize = true;
            this.cb_NV.Location = new System.Drawing.Point(42, 279);
            this.cb_NV.Name = "cb_NV";
            this.cb_NV.Size = new System.Drawing.Size(18, 17);
            this.cb_NV.TabIndex = 12;
            this.cb_NV.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(78, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Theo Nhà Cung Cấp";
            // 
            // cb_NCC
            // 
            this.cb_NCC.AutoSize = true;
            this.cb_NCC.Location = new System.Drawing.Point(42, 201);
            this.cb_NCC.Name = "cb_NCC";
            this.cb_NCC.Size = new System.Drawing.Size(18, 17);
            this.cb_NCC.TabIndex = 4;
            this.cb_NCC.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button2.Location = new System.Drawing.Point(66, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 52);
            this.button2.TabIndex = 6;
            this.button2.Text = "In Tổng Báo Cáo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_In_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.Location = new System.Drawing.Point(66, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 51);
            this.button1.TabIndex = 5;
            this.button1.Text = "Thực Hiện";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_ThucHien_Click);
            // 
            // datePK_ToDate
            // 
            this.datePK_ToDate.Location = new System.Drawing.Point(42, 159);
            this.datePK_ToDate.Name = "datePK_ToDate";
            this.datePK_ToDate.Size = new System.Drawing.Size(237, 22);
            this.datePK_ToDate.TabIndex = 4;
            // 
            // datePK_FromDate
            // 
            this.datePK_FromDate.Location = new System.Drawing.Point(42, 106);
            this.datePK_FromDate.Name = "datePK_FromDate";
            this.datePK_FromDate.Size = new System.Drawing.Size(237, 22);
            this.datePK_FromDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến Ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Từ Ngày";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(246, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1639, 91);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(536, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(661, 54);
            this.label3.TabIndex = 0;
            this.label3.Text = "BÁO CÁO HÀNG NHẬP KHO";
            // 
            // frmBaoCaoNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 683);
            this.Controls.Add(this.dgv_NhapKho);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBaoCaoNhap";
            this.Text = "Báo Cáo Nhập";
            this.Load += new System.EventHandler(this.frmBaoCaoNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhapKho)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_NhapKho;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker datePK_ToDate;
        private System.Windows.Forms.DateTimePicker datePK_FromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_NCC;
        private System.Windows.Forms.ComboBox cbo_NV;
        private System.Windows.Forms.ComboBox cbo_NhaCC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cb_NV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cb_Date;
    }
}