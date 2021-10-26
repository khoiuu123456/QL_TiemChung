using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
namespace UngDungQuanLyTiemChung
{
    public partial class frmHoSoNguoiChamSoc : Form
    {
        private DAO_KhachHang khachhang;
        public frmHoSoNguoiChamSoc()
        {
            InitializeComponent();
            khachhang = new DAO_KhachHang();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        /*public void loadNguoiCS()
        {
            DataTable dt = khachhang.loadNguoiChamSoc();
            gridNguoichamsoc.DataSource = dt;
            //DataBinding(dt);
            gridNguoichamsoc.Columns[0].HeaderText = "Mã người chăm sóc";
            gridNguoichamsoc.Columns[1].HeaderText = "Họ tên";
            gridNguoichamsoc.Columns[2].HeaderText = "Ngày sinh";
            gridNguoichamsoc.Columns[3].HeaderText = "Số điện thoại";
            gridNguoichamsoc.Columns[4].HeaderText = "Số chứng minh/CCCD";
            gridNguoichamsoc.Columns[5].HeaderText = "Địa chỉ";
        }*/
        public void loadNguoiCSGridControl()
        {
            gridView1.Columns.Clear();
            string[] fields = { "MANCS", "HOTEN", "NGAYSINH", "SDT", "CMND", "DIACHI" };
            string[] captions = { "Mã người chăm sóc", "Họ tên", "Ngày sinh", "Số điện thoại", "Số chứng minh/CCCD", "Địa chỉ" };
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = captions[i];
                gridView1.Columns.Add(col);
                gridView1.Columns[i].Visible = true;
            }
            DataTable dt = khachhang.loadNguoiChamSoc();
            gridHienThi.DataSource = dt;
        }
        private void FormatGrid_NCS()
        {
            gridView1.Columns.Clear();
            string[] fields = { "MANCS", "HOTEN", "NGAYSINH", "SDT", "CMND", "DIACHI" };
            string[] captions = { "Mã người chăm sóc", "Họ tên", "Ngày sinh", "Số điện thoại", "Số chứng minh/CCCD", "Địa chỉ" };
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = captions[i];
                gridView1.Columns.Add(col);
                gridView1.Columns[i].Visible = true;
            }
            DevExpress.XtraGrid.Views.Grid.GridView gridViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridViewDetail.GridControl = gridHienThi;
            string[] detail_fields = { "MABE", "TENBE","NGAYSINH", "GIOITINH","DIACHI" };
            string[] detail_captions = { "Mã số", "Họ tên","Ngày sinh","Giới tính","Địa chỉ" };
            for (int i = 0; i < detail_fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = detail_fields[i];
                col.Caption = detail_captions[i];
                gridViewDetail.Columns.Add(col);
                gridViewDetail.Columns[i].Visible = true;
            }
            if (gridHienThi.ViewCollection.Count > 1)
                gridHienThi.ViewCollection.RemoveAt(1); //loại bỏ cái cũ
                gridHienThi.ViewCollection.Add(gridViewDetail);
                DevExpress.XtraGrid.GridLevelNode gridLevelNodeDetail = new DevExpress.XtraGrid.GridLevelNode();
                gridLevelNodeDetail.LevelTemplate = gridViewDetail;
                gridLevelNodeDetail.RelationName = "Danh sách bé";
                if (gridHienThi.LevelTree.Nodes.Contains("Danh sách bé"))
                    gridHienThi.LevelTree.Nodes.RemoveAt(0); //loại bỏ cái cũ
                    gridHienThi.LevelTree.Nodes.Add(gridLevelNodeDetail);
        }
        private void FillGrid_NCS()
        {
            gridHienThi.DataSource = khachhang.GetNCS().Tables[0];
            DataBindingNguoiChamSoc();
            gridHienThi.ForceInitialize();
        }
        private void FormatGrid_Be()
        {
            gridView1.Columns.Clear();
            string[] fields = { "MABE", "TENBE", "NGAYSINH", "GIOITINH", "DIACHI", "MANCS" };
            string[] captions = { "Mã số", "Họ tên", "Ngày sinh", "Giới tính", "Địa chỉ", "Mã người chăm sóc" };
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = captions[i];
                gridView1.Columns.Add(col);
                gridView1.Columns[i].Visible = true;
            }
        }
        private void FillGrid_Be()
        {
            gridHienThi.DataSource = khachhang.GetBe();
            DataBindingBe();
            gridHienThi.ForceInitialize();
        }
        public void DataBindingBe()
        {
            txtMabe.DataBindings.Clear();
            txtMabe.DataBindings.Add("Text", gridHienThi.DataSource, "MABE");
            txtTenbe.DataBindings.Clear();
            txtTenbe.DataBindings.Add("Text", gridHienThi.DataSource, "TENBE");
            txtDiaChiBe.DataBindings.Clear();
            txtDiaChiBe.DataBindings.Add("Text", gridHienThi.DataSource, "DIACHI");
            txtMaNCS_Be.DataBindings.Clear();
            txtMaNCS_Be.DataBindings.Add("Text", gridHienThi.DataSource, "MANCS");
            cboGioiTinh.DataBindings.Clear();
            cboGioiTinh.DataBindings.Add("Text", gridHienThi.DataSource, "GIOITINH");
        }
        public void DataBindingNguoiChamSoc()
        {
            txtMaNCS.DataBindings.Clear();
            txtMaNCS.DataBindings.Add("Text", gridHienThi.DataSource, "MANCS");
            txtHoten.DataBindings.Clear();
            txtHoten.DataBindings.Add("Text", gridHienThi.DataSource, "HOTEN");
            txtCMND.DataBindings.Clear();
            txtCMND.DataBindings.Add("Text", gridHienThi.DataSource, "CMND");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", gridHienThi.DataSource, "SDT");
            txtDiachi.DataBindings.Clear();
            txtDiachi.DataBindings.Add("Text", gridHienThi.DataSource, "DIACHI");
        }
        private void frmHoSoNguoiChamSoc_Load(object sender, EventArgs e)
        {

            rdoNCS.Checked = true;
           
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoNCS.Checked == true)
            {
                FormatGrid_NCS();
                FillGrid_NCS();
                groupThongTinNguoiChamSoc.Expanded = true;
                groupThongTinBe.Expanded = false;
            }
            else
            {
                FormatGrid_Be();
                FillGrid_Be();
                groupThongTinBe.Expanded = true;
                groupThongTinNguoiChamSoc.Expanded = false;
            }
        }

        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if(e.Button.Properties.Caption == "Thêm")
            {
               if(rdoNCS.Checked == true)
               { 
                    if (txtHoten.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtCMND.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải nhập số chứng minn thư", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtSDT.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtDiachi.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       return;
                    }
                    string hoTen = txtHoten.Text.Trim();
                    string ngaysinh = dateTimeNgaySinh.Value.ToString("MM/dd/yyyy");
                    string cmnd = txtCMND.Text.Trim();
                    string sdt = txtSDT.Text.Trim();
                    string diachi = txtDiachi.Text.Trim();
                    if (khachhang.themNguoiChamSoc(hoTen,ngaysinh,sdt,cmnd,diachi))
                    {
                        FillGrid_NCS();
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công !");
                    }
               }
                else if(rdoThongtinbe.Checked == true)
               {
                   if (txtTenbe.Text.Length == 0)
                   {
                       MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       return;
                   }
                   if (txtMaNCS_Be.Text.Length == 0)
                   {
                       MessageBox.Show("Bạn phải nhập mã của người chăm sóc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       return;
                   }
                   if (txtDiaChiBe.Text.Length == 0)
                   {
                       MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       return;
                   }
                   string hoTenBe = txtTenbe.Text.Trim();
                   string ngaySinhBe = dateTimeNgaySinhBe.Value.ToString("MM/dd/yyyy");
                   string gioiTinh = cboGioiTinh.Text.Trim();
                   string diaChiBe = txtDiaChiBe.Text.Trim();
                   string maNCS = txtMaNCS_Be.Text.Trim();
                   if(khachhang.sp_KiemTraTonTaiNCS(maNCS)==1)
                   { 
                        if (khachhang.themThongTinBe(hoTenBe,ngaySinhBe,gioiTinh,diaChiBe,maNCS))
                        {
                            FillGrid_Be();
                            MessageBox.Show("Thêm thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thêm không thành công !");
                        }
                   }
                    else
                   {
                       MessageBox.Show("Người chăm sóc mã "+maNCS+" không tồn tại");
                   }
               }
            }
            if(e.Button.Properties.Caption == "Xóa")
            {
                if(rdoNCS.Checked == true)
                {
                    if (txtMaNCS.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải chọn người chăm sóc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string mancs = txtMaNCS.Text.ToString();
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa người chăm sóc mã " + mancs, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int kt = khachhang.sp_KiemTraRangBuocNCS(mancs);
                        if(kt==0)
                        {
                            khachhang.xoaNguoiChamSoc(mancs);
                            MessageBox.Show("Xóa thành công");
                            FillGrid_NCS();
                            txtMaNCS.DataBindings.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa do còn ràng buộc với thông tin của bé");
                        }
                    }
                }
                else if(rdoThongtinbe.Checked == true)
                {
                    if (txtMabe.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải chọn bé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string maBe = txtMabe.Text.Trim();
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa bé mã " + maBe, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if(khachhang.xoaThongTinBe(maBe))
                        {
                            FillGrid_Be();
                            MessageBox.Show("Xóa thành công");
                            txtMabe.DataBindings.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi không thể xóa !");
                        }
                    }
                }
            }
            if(e.Button.Properties.Caption == "Sửa")
            {
                if(rdoNCS.Checked == true)
                {
                    if (txtMaNCS.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải chọn người chăm sóc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if(txtHoten.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtCMND.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập số CMND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtDiachi.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtSDT.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string hoTen = txtHoten.Text.Trim();
                    string ngaysinh = dateTimeNgaySinh.Value.ToString("MM/dd/yyyy");
                    string sdt = txtSDT.Text.Trim();
                    string cmnd = txtCMND.Text.Trim();
                    string diachi = txtDiachi.Text.Trim();
                    string mancs = txtMaNCS.Text.ToString();
                    if (MessageBox.Show("Bạn muốn cập nhật lại người chăm sóc mã " + mancs, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (khachhang.capNhatNguoiChamSoc(hoTen, ngaysinh, sdt, cmnd, diachi, mancs))
                        {
                            MessageBox.Show("Cập nhật thành công");
                            FillGrid_NCS();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật không thành công");
                        }
                    }
                }
                else if(rdoThongtinbe.Checked==true)
                {
                    if (txtMaNCS.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải chọn người chăm sóc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtHoten.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtCMND.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập số CMND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtDiachi.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtSDT.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string hoTenBe = txtTenbe.Text.Trim();
                    string ngaysinhbe = dateTimeNgaySinhBe.Value.ToString("MM/dd/yyyy");
                    string gioiTinh = cboGioiTinh.Text.Trim();
                    string diachi = txtDiaChiBe.Text.Trim();
                    string mancsBe = txtMaNCS_Be.Text.ToString();
                    string mabe = txtMabe.Text.Trim();
                    if (MessageBox.Show("Bạn muốn cập nhật lại bé có mã " + mabe, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (khachhang.sp_KiemTraTonTaiNCS(mancsBe) == 1)
                        {
                            if (khachhang.capNhatThongTinBe(hoTenBe, ngaysinhbe, gioiTinh, diachi, mancsBe, mabe))
                            {
                                FillGrid_Be();
                                MessageBox.Show("Cập nhật thành công");   
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật không thành công");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Người chăm sóc mã " + mancsBe + " không tồn tại");
                        }
                    }
                }
            }
        }
        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtSDT_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }





    }
}
