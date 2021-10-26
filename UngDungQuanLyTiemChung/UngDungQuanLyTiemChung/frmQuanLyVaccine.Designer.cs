namespace UngDungQuanLyTiemChung
{
    partial class frmQuanLyVaccine
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridHienThi = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.dateTimeNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtCMND = new DevExpress.XtraEditors.TextEdit();
            this.txtMaNCS = new DevExpress.XtraEditors.TextEdit();
            this.txtDiachi = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit5 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupThongTinNguoiChamSoc = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHienThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCMND.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNCS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiachi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupThongTinNguoiChamSoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Location = new System.Drawing.Point(0, -1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1566, 835);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Quản lý lô vaccine";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.layoutControl1);
            this.groupControl2.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Thêm", global::UngDungQuanLyTiemChung.Properties.Resources.round_add_button),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Xóa", global::UngDungQuanLyTiemChung.Properties.Resources.delete),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Sửa", global::UngDungQuanLyTiemChung.Properties.Resources.clipboard),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Cập nhật", global::UngDungQuanLyTiemChung.Properties.Resources.exchange)});
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 25);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1562, 808);
            this.groupControl2.TabIndex = 1;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridHienThi);
            this.layoutControl1.Controls.Add(this.dateTimeNgaySinh);
            this.layoutControl1.Controls.Add(this.txtCMND);
            this.layoutControl1.Controls.Add(this.txtMaNCS);
            this.layoutControl1.Controls.Add(this.txtDiachi);
            this.layoutControl1.Controls.Add(this.textEdit2);
            this.layoutControl1.Controls.Add(this.textEdit4);
            this.layoutControl1.Controls.Add(this.textEdit5);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 49);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1558, 757);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridHienThi
            // 
            this.gridHienThi.Location = new System.Drawing.Point(152, 259);
            this.gridHienThi.MainView = this.gridView1;
            this.gridHienThi.Name = "gridHienThi";
            this.gridHienThi.Size = new System.Drawing.Size(1390, 482);
            this.gridHienThi.TabIndex = 10;
            this.gridHienThi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.layoutView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridHienThi;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // layoutView1
            // 
            this.layoutView1.GridControl = this.gridHienThi;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsFind.AlwaysVisible = true;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Name = "layoutViewTemplateCard";
            // 
            // dateTimeNgaySinh
            // 
            this.dateTimeNgaySinh.Cursor = System.Windows.Forms.Cursors.No;
            this.dateTimeNgaySinh.CustomFormat = "";
            this.dateTimeNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeNgaySinh.Location = new System.Drawing.Point(919, 92);
            this.dateTimeNgaySinh.Name = "dateTimeNgaySinh";
            this.dateTimeNgaySinh.Size = new System.Drawing.Size(593, 23);
            this.dateTimeNgaySinh.TabIndex = 9;
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(182, 120);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(226, 22);
            this.txtCMND.StyleController = this.layoutControl1;
            this.txtCMND.TabIndex = 8;
            // 
            // txtMaNCS
            // 
            this.txtMaNCS.Enabled = false;
            this.txtMaNCS.Location = new System.Drawing.Point(182, 92);
            this.txtMaNCS.Name = "txtMaNCS";
            this.txtMaNCS.Size = new System.Drawing.Size(595, 22);
            this.txtMaNCS.StyleController = this.layoutControl1;
            this.txtMaNCS.TabIndex = 5;
            // 
            // txtDiachi
            // 
            this.txtDiachi.Location = new System.Drawing.Point(182, 201);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Size = new System.Drawing.Size(594, 22);
            this.txtDiachi.StyleController = this.layoutControl1;
            this.txtDiachi.TabIndex = 4;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(550, 120);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(227, 22);
            this.textEdit2.StyleController = this.layoutControl1;
            this.textEdit2.TabIndex = 7;
            // 
            // textEdit4
            // 
            this.textEdit4.Location = new System.Drawing.Point(918, 201);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new System.Drawing.Size(594, 22);
            this.textEdit4.StyleController = this.layoutControl1;
            this.textEdit4.TabIndex = 4;
            // 
            // textEdit5
            // 
            this.textEdit5.Location = new System.Drawing.Point(919, 120);
            this.textEdit5.Name = "textEdit5";
            this.textEdit5.Size = new System.Drawing.Size(593, 22);
            this.textEdit5.StyleController = this.layoutControl1;
            this.textEdit5.TabIndex = 7;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.groupThongTinNguoiChamSoc});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1558, 757);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.gridHienThi;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 243);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(1532, 488);
            this.layoutControlItem7.Text = "DANH SÁCH HIỂN THỊ";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(133, 17);
            // 
            // groupThongTinNguoiChamSoc
            // 
            this.groupThongTinNguoiChamSoc.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3,
            this.layoutControlGroup2});
            this.groupThongTinNguoiChamSoc.Location = new System.Drawing.Point(0, 0);
            this.groupThongTinNguoiChamSoc.Name = "groupThongTinNguoiChamSoc";
            this.groupThongTinNguoiChamSoc.Size = new System.Drawing.Size(1532, 243);
            this.groupThongTinNguoiChamSoc.Text = "Thông tin lô vaccine";
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem10});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1502, 109);
            this.layoutControlGroup3.Text = "Lô vaccine";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtMaNCS;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(737, 28);
            this.layoutControlItem2.Text = "Số lô";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(133, 17);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtCMND;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(368, 28);
            this.layoutControlItem5.Text = "Số lượng tồn";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(133, 17);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textEdit2;
            this.layoutControlItem4.CustomizationFormText = "Số điện thoại";
            this.layoutControlItem4.Location = new System.Drawing.Point(368, 28);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(369, 28);
            this.layoutControlItem4.Text = "Số liều tồn";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(133, 17);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.dateTimeNgaySinh;
            this.layoutControlItem6.Location = new System.Drawing.Point(737, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(735, 28);
            this.layoutControlItem6.Text = "Hạn sử dụng";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(133, 17);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.textEdit5;
            this.layoutControlItem10.CustomizationFormText = "Số điện thoại";
            this.layoutControlItem10.Location = new System.Drawing.Point(737, 28);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(735, 28);
            this.layoutControlItem10.Text = "Tình trạng";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(133, 17);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem9});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 109);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1502, 81);
            this.layoutControlGroup2.Text = "Vaccine";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtDiachi;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(736, 28);
            this.layoutControlItem1.Text = "Mã vaccine";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(133, 16);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.textEdit4;
            this.layoutControlItem9.CustomizationFormText = "Địa chỉ";
            this.layoutControlItem9.Location = new System.Drawing.Point(736, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(736, 28);
            this.layoutControlItem9.Text = "Loại vaccine";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(133, 17);
            // 
            // frmQuanLyVaccine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1565, 833);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmQuanLyVaccine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý vaccine";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHienThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCMND.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNCS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiachi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupThongTinNguoiChamSoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridHienThi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private System.Windows.Forms.DateTimePicker dateTimeNgaySinh;
        private DevExpress.XtraEditors.TextEdit txtCMND;
        private DevExpress.XtraEditors.TextEdit txtMaNCS;
        private DevExpress.XtraEditors.TextEdit txtDiachi;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlGroup groupThongTinNguoiChamSoc;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.TextEdit textEdit5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
    }
}