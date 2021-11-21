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
using Microsoft.VisualBasic;

namespace UngDungQuanLyTiemChung
{
    public partial class frmQuanLyVaccine : Form
    {
        DAO_loVaccine cn = new DAO_loVaccine();
        private DAO_loVaccine lovaccine;
        public static int trangthai = 0;
        public frmQuanLyVaccine()
        {
            InitializeComponent();
            lovaccine = new DAO_loVaccine();
            rdoVaccine.Checked = true;
        }

        private void frmQuanLyVaccine_Load(object sender, EventArgs e)
        {
            string sql = "SELECT MAVACCINE FROM VACCINE";
            DataTable dt = cn.taobang(sql);
            comboMaVC.DataSource = dt;
            comboMaVC.ValueMember = "MAVACCINE";
        }

        private void FormatGrid_LoVC()
        {
            gridView1.Columns.Clear();
            string[] fields = { "SOLO", "SOLUONGTON", "SOLIEUTON", "HANSUDUNG", "DVT", "MAVACCINE", "LOAIVACCINE" };
            string[] captions = { "Số lô", "Số lượng tồn", "Số liều tồn", "Hạn sử dụng", "Đơn vị", "Mã vaccine", "Loại vaccine" };
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = captions[i];
                gridView1.Columns.Add(col);
                gridView1.Columns[i].Visible = true;
            }
        }
        private void FormatGrid_VC()
        {
            gridView1.Columns.Clear();
            string[] fields = { "MAVACCINE", "TENVACCINE", "CHONGCHIDINH", "TACDUNGPHU", "CACHDUNG", "LIEULUONG", "DUNGMOI", "XUATXU", "CHIDINHTIEM" };
            string[] captions = { "Mã vaccine", "Tên vaccine", "Chống chỉ định", "Tác dụng phụ", "Cách dùng", "Liều lượng", "Dung môi", "Xuất xứ", "Chỉ định tiêm" };
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = captions[i];
                gridView1.Columns.Add(col);
                gridView1.Columns[i].Visible = true;
            }
        }
        private void FillGrid_LoVC()
        {
            gridHienThi.DataSource = lovaccine.GetLoVC().Tables[0];
            DataBindingLoVaccine();
            gridHienThi.ForceInitialize();
        }
        private void FillGrid_VC()
        {
            gridHienThi.DataSource = lovaccine.GetVC();
            DataBindingVaccine();
            gridHienThi.ForceInitialize();
        }
        public void DataBindingLoVaccine()
        {
            txtSoLo.DataBindings.Clear();
            txtSoLo.DataBindings.Add("Text", gridHienThi.DataSource, "SOLO");
            txtSoLuongTon.DataBindings.Clear();
            txtSoLuongTon.DataBindings.Add("Text", gridHienThi.DataSource, "SOLUONGTON");
            txtSoLieuTon.DataBindings.Clear();
            txtSoLieuTon.DataBindings.Add("Text", gridHienThi.DataSource, "SOLIEUTON");
            dateTimeHSD.DataBindings.Clear();
            dateTimeHSD.DataBindings.Add("Text", gridHienThi.DataSource, "HANSUDUNG");
            txtDonVi.DataBindings.Clear();
            txtDonVi.DataBindings.Add("Text", gridHienThi.DataSource, "DVT");
            comboMaVC.DataBindings.Clear();
            comboMaVC.DataBindings.Add("Text", gridHienThi.DataSource, "MAVACCINE");
            txtLoaiVC.DataBindings.Clear();
            txtLoaiVC.DataBindings.Add("Text", gridHienThi.DataSource, "LOAIVACCINE");
        }
        public void DataBindingVaccine()
        {
            txtMaVaccine.DataBindings.Clear();
            txtMaVaccine.DataBindings.Add("Text", gridHienThi.DataSource, "MAVACCINE");
            txtTenVC.DataBindings.Clear();
            txtTenVC.DataBindings.Add("Text", gridHienThi.DataSource, "TENVACCINE");
            txtChongChiDinh.DataBindings.Clear();
            txtChongChiDinh.DataBindings.Add("Text", gridHienThi.DataSource, "CHONGCHIDINH");
            txtTacDungPhu.DataBindings.Clear();
            txtTacDungPhu.DataBindings.Add("Text", gridHienThi.DataSource, "TACDUNGPHU");
            txtCachDung.DataBindings.Clear();
            txtCachDung.DataBindings.Add("Text", gridHienThi.DataSource, "CACHDUNG");
            txtLieuLuong.DataBindings.Clear();
            txtLieuLuong.DataBindings.Add("Text", gridHienThi.DataSource, "LIEULUONG");
            txtDungMoi.DataBindings.Clear();
            txtDungMoi.DataBindings.Add("Text", gridHienThi.DataSource, "DUNGMOI");
            txtXuatXu.DataBindings.Clear();
            txtXuatXu.DataBindings.Add("Text", gridHienThi.DataSource, "XUATXU");
            txtChiDinhTiem.DataBindings.Clear();
            txtChiDinhTiem.DataBindings.Add("Text", gridHienThi.DataSource, "CHIDINHTIEM");
        }

        private void txtSoLieuTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoLuongTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTinhTrang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rdoVaccine_CheckedChanged(object sender, EventArgs e)
        {
            if (trangthai == 0)
            {
                if (rdoLoVC.Checked == true)
                {
                    FormatGrid_LoVC();
                    FillGrid_LoVC();
                    groupThongTinLoVC.Expanded = true;
                    groupThongTinVC.Expanded = false;
                }
                else
                {
                    txtMaVaccine.ReadOnly = true;
                    FormatGrid_VC();
                    FillGrid_VC();
                    groupThongTinVC.Expanded = true;
                    groupThongTinLoVC.Expanded = false;
                }
            }
            else
            {
                rdoVaccine.Enabled = false;
                rdoLoVC.Checked = true;
                FormatGrid_LoVC();
                FillGrid_LoVC();
                groupThongTinLoVC.Expanded = true;
                groupThongTinVC.Expanded = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (rdoLoVC.Checked == true)
            {
                FillGrid_LoVC();
            }
            else
            {
                FillGrid_VC();
            }

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (rdoLoVC.Checked == true)
            {
                if (txtSoLuongTon.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số lượng tồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtSoLieuTon.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số liều tồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtDonVi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtLoaiVC.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập loại vaccine", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string SOLO = txtSoLo.Text.Trim();
                string SOLUONGTON = txtSoLuongTon.Text.Trim();
                string SOLIEUTON = txtSoLieuTon.Text.Trim();
                string HANSUDUNG = dateTimeHSD.Value.ToString("MM/dd/yyyy");
                string MAVACCINE = comboMaVC.Text.Trim();
                string DVT = txtDonVi.Text.Trim();
                string LOAIVACCINE = txtLoaiVC.Text.Trim();
                try
                {
                    lovaccine.themLoVaccine(SOLO, SOLUONGTON, SOLIEUTON, HANSUDUNG, MAVACCINE, DVT, LOAIVACCINE);
                    FillGrid_LoVC();
                    MessageBox.Show("Thêm thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm không thành công !");
                    MessageBox.Show(ex.Message);
                }
            }
            else if (rdoVaccine.Checked == true)
            {
                if (txtTenVC.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên vaccine", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtChongChiDinh.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập chống chỉ định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtTacDungPhu.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tác dụng phụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCachDung.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập cách dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtLieuLuong.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập liều lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtDungMoi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập dung môi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtXuatXu.Text.Length == 0 || txtXuatXu.Text == "Khác...")
                {
                    MessageBox.Show("Bạn phải nhập xuất xứ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtChiDinhTiem.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập chỉ định tiêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string TENVACCINE = txtTenVC.Text.Trim();
                string MAVACCINE = TENVACCINE.Substring(0,3);
                string CHONGCHIDINH = txtChongChiDinh.Text.Trim();
                string TACDUNGPHU = txtTacDungPhu.Text.Trim();
                string CACHDUNG = txtCachDung.Text.Trim();
                string LIEULUONG = txtLieuLuong.Text.Trim()+" ml";
                string DUNGMOI = txtDungMoi.Text.Trim();
                string XUATXU = txtXuatXu.Text.Trim();
                string CHIDINHTIEM = txtChiDinhTiem.Text.Trim();
                try
                {
                    lovaccine.themThongTinVC(MAVACCINE,TENVACCINE, CHONGCHIDINH, TACDUNGPHU, CACHDUNG, LIEULUONG, DUNGMOI, XUATXU, CHIDINHTIEM);
                    FillGrid_VC();
                    MessageBox.Show("Thêm thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm không thành công !");
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (rdoLoVC.Checked == true)
            {
                if (txtSoLo.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn số lô", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtSoLuongTon.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số lượng tồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtSoLieuTon.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số liều tồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtDonVi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtLoaiVC.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập loại vaccine", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string SOLUONGTON = txtSoLuongTon.Text.Trim();
                string SOLIEUTON = txtSoLieuTon.Text.Trim();
                string HANSUDUNG = dateTimeHSD.Value.ToString("MM/dd/yyyy");
                string MAVACCINE = comboMaVC.Text.Trim();
                string DVT = txtDonVi.Text.Trim();
                string LOAIVACCINE = txtLoaiVC.Text.Trim();
                string solo = txtSoLo.Text.Trim();
                if (MessageBox.Show("Bạn muốn cập nhật lại lô vaccine mã " + solo, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        lovaccine.capNhatLoVC(SOLUONGTON, SOLIEUTON, HANSUDUNG, MAVACCINE, DVT, LOAIVACCINE, solo);
                        MessageBox.Show("Cập nhật thành công");
                        FillGrid_LoVC();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cập nhật không thành công !");
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (rdoVaccine.Checked == true)
            {
                if (txtMaVaccine.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn vaccine", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtTenVC.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên vaccine", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtChongChiDinh.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập chống chỉ định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtTacDungPhu.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tác dụng phụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCachDung.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập cách dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtLieuLuong.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập liều lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtDungMoi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập dung môi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtXuatXu.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập xuất xứ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtChiDinhTiem.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập chỉ định tiêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string TENVACCINE = txtTenVC.Text.Trim();
                string CHONGCHIDINH = txtChongChiDinh.Text.Trim();
                string TACDUNGPHU = txtTacDungPhu.Text.Trim();
                string CACHDUNG = txtCachDung.Text.Trim();
                string LIEULUONG = txtLieuLuong.Text.Trim();
                string DUNGMOI = txtDungMoi.Text.Trim();
                string XUATXU = txtXuatXu.Text.Trim();
                string CHIDINHTIEM = txtChiDinhTiem.Text.Trim();
                string mavc = txtMaVaccine.Text.Trim();
                if (MessageBox.Show("Bạn muốn cập nhật lại vaccine có mã " + mavc, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        lovaccine.capNhatThongTinVC(TENVACCINE, CHONGCHIDINH, TACDUNGPHU, CACHDUNG, LIEULUONG, DUNGMOI, XUATXU, CHIDINHTIEM, mavc);
                        FillGrid_VC();
                        MessageBox.Show("Cập nhật thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cập nhật không thành công");
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (rdoLoVC.Checked == true)
            {
                if (txtSoLo.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn số lô", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string solo = txtSoLo.Text.ToString();
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa số lô mã " + solo, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        lovaccine.xoaLoVC(solo);
                        MessageBox.Show("Xóa thành công");
                        FillGrid_LoVC();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (rdoVaccine.Checked == true)
            {
                if (txtMaVaccine.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn Vaccine", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string vc = txtMaVaccine.Text.Trim();
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa Vaccine mã " + vc, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (lovaccine.xoaThongTinVC(vc))
                    {
                        FillGrid_VC();
                        MessageBox.Show("Xóa thành công");
                        txtMaVaccine.DataBindings.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi không thể xóa !");
                    }
                }
            }
        }

        private void txtXuatXu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtXuatXu.SelectedIndex == 5)
            {
                string content = Interaction.InputBox("Bạn hãy nhập xuất xứ ?", "Xuất xứ", "", 500, 300);
                if (content != "")
                {
                    txtXuatXu.Items.Add(content);
                }
            }

        }

        private void txtLieuLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void btnCreateCode_Click(object sender, EventArgs e)
        {
            frmCreateBarcode f = new frmCreateBarcode();
            f.Show();
        }
    }
}
