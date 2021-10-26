namespace UngDungQuanLyTiemChung
{
    partial class frmQuanLyTaiKhoan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridTaiKhoan = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridNhanVien = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCapnhattinhtrang = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkRemk = new System.Windows.Forms.CheckBox();
            this.chkMk = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRematkhau = new System.Windows.Forms.TextBox();
            this.txtTendn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTaiKhoan)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNhanVien)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridTaiKhoan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 677);
            this.panel1.TabIndex = 0;
            // 
            // gridTaiKhoan
            // 
            this.gridTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTaiKhoan.Location = new System.Drawing.Point(0, 0);
            this.gridTaiKhoan.Name = "gridTaiKhoan";
            this.gridTaiKhoan.Size = new System.Drawing.Size(348, 677);
            this.gridTaiKhoan.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridNhanVien);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(348, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(812, 677);
            this.panel2.TabIndex = 1;
            // 
            // gridNhanVien
            // 
            this.gridNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNhanVien.Location = new System.Drawing.Point(0, 328);
            this.gridNhanVien.Name = "gridNhanVien";
            this.gridNhanVien.Size = new System.Drawing.Size(812, 349);
            this.gridNhanVien.TabIndex = 1;
            this.gridNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridNhanVien_CellClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(812, 328);
            this.panel3.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.comboBox1);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.btnCapnhattinhtrang);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(478, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(334, 328);
            this.panel5.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 186);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(245, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tình trạng";
            // 
            // btnCapnhattinhtrang
            // 
            this.btnCapnhattinhtrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapnhattinhtrang.Image = global::UngDungQuanLyTiemChung.Properties.Resources.exchange;
            this.btnCapnhattinhtrang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapnhattinhtrang.Location = new System.Drawing.Point(3, 240);
            this.btnCapnhattinhtrang.Name = "btnCapnhattinhtrang";
            this.btnCapnhattinhtrang.Size = new System.Drawing.Size(248, 72);
            this.btnCapnhattinhtrang.TabIndex = 11;
            this.btnCapnhattinhtrang.Text = "Cập nhật tình trạng tài khoản";
            this.btnCapnhattinhtrang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapnhattinhtrang.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkRemk);
            this.panel4.Controls.Add(this.chkMk);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.txtRematkhau);
            this.panel4.Controls.Add(this.txtTendn);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnTimkiem);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txtMatkhau);
            this.panel4.Controls.Add(this.btnThem);
            this.panel4.Controls.Add(this.textBox3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(478, 328);
            this.panel4.TabIndex = 1;
            // 
            // chkRemk
            // 
            this.chkRemk.AutoSize = true;
            this.chkRemk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRemk.Image = global::UngDungQuanLyTiemChung.Properties.Resources.eye;
            this.chkRemk.Location = new System.Drawing.Point(390, 184);
            this.chkRemk.Name = "chkRemk";
            this.chkRemk.Size = new System.Drawing.Size(47, 24);
            this.chkRemk.TabIndex = 17;
            this.chkRemk.Text = "       ";
            this.chkRemk.UseVisualStyleBackColor = true;
            this.chkRemk.CheckedChanged += new System.EventHandler(this.chkRemk_CheckedChanged);
            // 
            // chkMk
            // 
            this.chkMk.AutoSize = true;
            this.chkMk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMk.Image = global::UngDungQuanLyTiemChung.Properties.Resources.eye;
            this.chkMk.Location = new System.Drawing.Point(390, 105);
            this.chkMk.Name = "chkMk";
            this.chkMk.Size = new System.Drawing.Size(47, 24);
            this.chkMk.TabIndex = 16;
            this.chkMk.Text = "       ";
            this.chkMk.UseVisualStyleBackColor = true;
            this.chkMk.CheckedChanged += new System.EventHandler(this.chkMk_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::UngDungQuanLyTiemChung.Properties.Resources.black_settings_button;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(233, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 44);
            this.button1.TabIndex = 13;
            this.button1.Text = "Đổi mật khẩu";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtRematkhau
            // 
            this.txtRematkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRematkhau.Location = new System.Drawing.Point(24, 184);
            this.txtRematkhau.Name = "txtRematkhau";
            this.txtRematkhau.Size = new System.Drawing.Size(360, 22);
            this.txtRematkhau.TabIndex = 12;
            this.txtRematkhau.UseSystemPasswordChar = true;
            // 
            // txtTendn
            // 
            this.txtTendn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTendn.Location = new System.Drawing.Point(25, 26);
            this.txtTendn.Name = "txtTendn";
            this.txtTendn.Size = new System.Drawing.Size(359, 22);
            this.txtTendn.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nhập lại mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.BackColor = System.Drawing.Color.Transparent;
            this.btnTimkiem.FlatAppearance.BorderSize = 0;
            this.btnTimkiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimkiem.Image = global::UngDungQuanLyTiemChung.Properties.Resources.search;
            this.btnTimkiem.Location = new System.Drawing.Point(390, 280);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(60, 42);
            this.btnTimkiem.TabIndex = 10;
            this.btnTimkiem.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tìm kiếm nhân viên";
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatkhau.Location = new System.Drawing.Point(25, 105);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.Size = new System.Drawing.Size(359, 22);
            this.txtMatkhau.TabIndex = 3;
            this.txtMatkhau.UseSystemPasswordChar = true;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = global::UngDungQuanLyTiemChung.Properties.Resources.round_add_button;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(24, 212);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(151, 44);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Tạo tài khoản";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(24, 292);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(360, 20);
            this.textBox3.TabIndex = 6;
            // 
            // frmQuanLyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 677);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmQuanLyTaiKhoan";
            this.Text = "Quản lý tài khoản";
            this.Load += new System.EventHandler(this.frmQuanLyTaiKhoan_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTaiKhoan)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNhanVien)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridTaiKhoan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtMatkhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTendn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtRematkhau;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkMk;
        private System.Windows.Forms.CheckBox chkRemk;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCapnhattinhtrang;
        private System.Windows.Forms.DataGridView gridNhanVien;
    }
}