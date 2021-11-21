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
using System.Data.SqlClient;

namespace UngDungQuanLyTiemChung
{
    public partial class frmNhapVaccine : Form
    {
        DAO_loVaccine cn = new DAO_loVaccine();
        private DAO_NhapVaccine nhapvc;
        public frmNhapVaccine()
        {
            InitializeComponent();
            nhapvc = new DAO_NhapVaccine();
        }

        private void frmNhapVaccine_Load(object sender, EventArgs e)
        {
            //load combobox mã phiếu nhập
            string sql = "SELECT MAPHIEUNHAP FROM PHIEUNHAP";
            DataTable dt = cn.taobang(sql);
            CboNhapVC.DataSource = dt;
            CboNhapVC.ValueMember = "MAPHIEUNHAP";
            CboNhapVC.SelectedIndex = 0;
            //load combobox mã ncc
            string sql1 = "SELECT MANCC FROM NHACUNGCAP";
            DataTable dt1 = cn.taobang(sql1);
            cboMaNCC.DataSource = dt1;
            cboMaNCC.ValueMember = "MANCC";
            //load combobox số lô
            string sql2 = "SELECT SOLO FROM LOVACCINE WHERE SOLO NOT IN (SELECT SOLO FROM CHITIETPHIEUNHAP)";
            DataTable dt2 = cn.taobang(sql2);
            cboSoLo.DataSource = dt2;
            cboSoLo.ValueMember = "SOLO";
            cboSoLo.SelectedIndex = -1;
            //load data
            FormatGrid_CTNHAPVC();
            FillGrid_CTNHAPVC();
            //load người lập phiếu
            string str;
            str = "SELECT TENNV FROM NHANVIEN WHERE MANV = N'" + txtMaNV.Text + "'";
            txtTenNV.Text = cn.GetFieldValues(str);
            //enable
            btnHuy.Enabled = false;
            txtMaNV.ReadOnly = true;
            txtTenNV.ReadOnly = true;
        }
        private void FormatGrid_CTNHAPVC()
        {
            gridView1.Columns.Clear();
            string[] fields = { "SOLO", "DVT", "SOLUONG", "LUONGNGUOITIEM", "CHITHINHIETDO", "CHITHIDONGBANG", "DUNGTICH" };
            string[] captions = { "Số lô", "Đơn vị tính", "Số lượng", "Lượng người tiêm", "Chỉ thị nhiệt độ", "Chỉ thị đóng băng", "Dung tích" };
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = captions[i];
                gridView1.Columns.Add(col);
                gridView1.Columns[i].Visible = true;
            }
        }
        private void FillGrid_CTNHAPVC()
        {
            gridHienThiNHAP.DataSource = nhapvc.GetCTNHAPVC(CboNhapVC.Text.ToString());
            gridHienThiNHAP.ForceInitialize();
        }
        private void LoadInfoPhieuNhap()
        {
            string str;
            str = "SELECT NGAYNHAP FROM PHIEUNHAP WHERE MAPHIEUNHAP = N'" + CboNhapVC.Text + "'";
            dateNgayNhap.Text = cn.GetFieldValues(str);
            str = "SELECT MANV FROM PHIEUNHAP WHERE MAPHIEUNHAP = N'" + CboNhapVC.Text + "'";
            txtMaNV.Text = cn.GetFieldValues(str);
            str = "Select GHICHU from PHIEUNHAP where MAPHIEUNHAP= N'" + CboNhapVC.Text + "'";
            txtGhiChu.Text = cn.GetFieldValues(str);
            str = "SELECT MANCC FROM PHIEUNHAP WHERE MAPHIEUNHAP = N'" + CboNhapVC.Text + "'";
            cboMaNCC.Text = cn.GetFieldValues(str);
            str = "SELECT TENNCC FROM NHACUNGCAP WHERE MANCC = N'" + cboMaNCC.Text + "'";
            txtTenNCC.Text = cn.GetFieldValues(str);
        }
        private void ResetInfoPhieuNhap()
        {
            //txtMaNV.Text = "";
            txtGhiChu.Text = "";
            cboMaNCC.SelectedIndex = -1;
            txtTenNCC.Text = "";
            gridHienThiNHAP.DataSource = null;
            gridView1.Columns.Clear();
            DateTime now = DateTime.Now;
            dateNgayNhap.Text = now.ToString();
        }
        private void ResetInfoCTPN()
        {
            cboSoLo.Text = "";
            txtDVT.Text = "";
            txtSoLuong.Text = "";
            txtLuongNguoiTiem.Text = "";
            txtChiThiND.Text = "";
            txtChiThiDB.Text = "";
            txtDungTich.Text = "";
        }
        private void CboNhapVC_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid_CTNHAPVC();
            LoadInfoPhieuNhap();
            ResetInfoCTPN();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            string CauLenh = "declare @sophieu char(5) exec @sophieu= DBO.AUTO_IDPN select @sophieu";
            SqlCommand cmd = new SqlCommand(CauLenh, cn.conn);
            object value = cmd.ExecuteScalar();
            CboNhapVC.Text = value.ToString();
            CboNhapVC.Enabled = false;
            ResetInfoPhieuNhap();
            ResetInfoCTPN();
            //load combobox số lô CHƯA ĐƯỢC NHẬP
            string sql = "SELECT SOLO FROM LOVACCINE WHERE SOLO NOT IN (SELECT SOLO FROM CHITIETPHIEUNHAP)";
            DataTable dt = cn.taobang(sql);
            cboSoLo.DataSource = dt;
            cboSoLo.ValueMember = "SOLO";
            cboSoLo.SelectedIndex = -1;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmNhapVaccine_Load(sender,e);
            btnThem.Enabled = true;
            CboNhapVC.Enabled = true;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                cboSoLo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SOLO").ToString().Trim();
                txtDVT.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DVT").ToString().Trim();
                txtSoLuong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SOLUONG").ToString().Trim();
                txtLuongNguoiTiem.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LUONGNGUOITIEM").ToString().Trim();
                txtChiThiND.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CHITHINHIETDO").ToString().Trim();
                txtChiThiDB.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CHITHIDONGBANG").ToString().Trim();
                txtDungTich.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DUNGTICH").ToString().Trim();
                string str;
                str = "SELECT HANSUDUNG FROM LOVACCINE WHERE SOLO = N'" + cboSoLo.Text + "'";
                dateHSD.Text = cn.GetFieldValues(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cboMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            str = "SELECT TENNCC FROM NHACUNGCAP WHERE MANCC = N'" + cboMaNCC.Text + "'";
            txtTenNCC.Text = cn.GetFieldValues(str);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            frmNhapVaccine_Load(sender, e);
            btnThem.Enabled = true;
            CboNhapVC.Enabled = true;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (cboMaNCC.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (txtGhiChu.Text.Length == 0)
            {
                MessageBox.Show("Bạn thiếu ghi chú!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboSoLo.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn số lô!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDVT.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn vị tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSoLuong.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtLuongNguoiTiem.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lượng người tiêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtChiThiND.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chỉ thị nhiệt độ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtChiThiDB.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chỉ thị đóng băng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboMaNCC.SelectedIndex != -1)
            {
                string str;
                str = "SELECT TOP 1 NGAYBATDAU FROM KEHOACHTIEM where NGAYBATDAU > GETDATE() ORDER BY NGAYBATDAU ASC";
                string KHTGANNHAT = cn.GetFieldValues(str);
                DateTime HSDNHAP = DateTime.Parse(dateHSD.Text);
                DateTime NGAYKHTGANNHAT = DateTime.Parse(KHTGANNHAT);
                if (HSDNHAP.Date < NGAYKHTGANNHAT.Date || HSDNHAP.Day - NGAYKHTGANNHAT.Day < 7)
                {
                    MessageBox.Show("Hạn sử dụng phải lớn hơn 7 ngày kể từ kế hoạch tiêm gần nhất!, kế hoạch tiêm gần nhất là: "+KHTGANNHAT, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (btnThem.Enabled == false)
            {
                // Thêm phiếu nhập
                string MANV = txtMaNV.Text.Trim();
                string MANCC = cboMaNCC.Text.Trim();
                string NGAYNHAP = dateNgayNhap.Value.ToString("MM/dd/yyyy");
                string GHICHU = txtGhiChu.Text.Trim();
                // Thêm CTPN
                string MAPHIEUNHAP = CboNhapVC.Text.Trim();
                string SOLO = cboSoLo.Text.Trim();
                string DVT = txtDVT.Text.Trim();
                string SOLUONG = txtSoLuong.Text.Trim();
                string LUONGNGUOITIEM = txtLuongNguoiTiem.Text.Trim();
                string CHITHINHIETDO = txtChiThiND.Text.Trim();
                string CHITHIDONGBANG = txtChiThiDB.Text.Trim();
                string DUNGTICH = txtDungTich.Text.Trim() + " ml";
                string HANSUDUNG = dateHSD.Value.ToString("MM/dd/yyyy");
                try
                {
                    nhapvc.themPhieuNhap(MANV, MANCC, NGAYNHAP, GHICHU);
                    nhapvc.themCTNHAP(MAPHIEUNHAP, SOLO, DVT, SOLUONG, LUONGNGUOITIEM, CHITHINHIETDO, CHITHIDONGBANG, DUNGTICH);
                    nhapvc.capNhatHSDLoVC(HANSUDUNG, SOLO);
                    MessageBox.Show("Lập phiếu thành công!");
                    frmNhapVaccine_Load(sender, e);
                    btnThem.Enabled = true;
                    CboNhapVC.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lập không thành công !");
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                // Thêm CTPN
                string MAPHIEUNHAP = CboNhapVC.Text.Trim();
                string SOLO = cboSoLo.Text.Trim();
                string DVT = txtDVT.Text.Trim();
                string SOLUONG = txtSoLuong.Text.Trim();
                string LUONGNGUOITIEM = txtLuongNguoiTiem.Text.Trim();
                string CHITHINHIETDO = txtChiThiND.Text.Trim();
                string CHITHIDONGBANG = txtChiThiDB.Text.Trim();
                string DUNGTICH = txtDungTich.Text.Trim() + " ml";
                string HANSUDUNG = dateHSD.Value.ToString("MM/dd/yyyy");
                try
                {
                    string sql = "SELECT * FROM CHITIETPHIEUNHAP WHERE MAPHIEUNHAP= '" + CboNhapVC.Text + "' AND SOLO='" + cboSoLo.Text + "'";
                    //kiểm tra lovaccine đã tồn tại chưa?
                    if (cn.CheckKey(sql) == true)
                    {
                        MessageBox.Show("Lô vaccine đã tồn tại! vui lòng chọn lô vaccine khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        nhapvc.themCTNHAP(MAPHIEUNHAP, SOLO, DVT, SOLUONG, LUONGNGUOITIEM, CHITHINHIETDO, CHITHIDONGBANG, DUNGTICH);
                        nhapvc.capNhatHSDLoVC(HANSUDUNG, SOLO);
                        MessageBox.Show("Thêm lô vaccine thành công!");
                        frmNhapVaccine_Load(sender, e);
                        btnThem.Enabled = true;
                        CboNhapVC.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm không thành công !");
                    MessageBox.Show(SOLO);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLuongNguoiTiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string pn = CboNhapVC.Text.ToString();
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập mã " + pn, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    nhapvc.XoaCTNhap(pn);
                    nhapvc.XoaPhieuNhap(pn);
                    MessageBox.Show("Xóa thành công");
                    frmNhapVaccine_Load(sender, e);
                    btnThem.Enabled = true;
                    CboNhapVC.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnQLNCC_Click(object sender, EventArgs e)
        {
            frmNhaCungCap frm = new frmNhaCungCap();
            frm.ShowDialog();
        }

        private void txtDungTich_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmQuanLyVaccine.trangthai = 1;
            frmQuanLyVaccine f = new frmQuanLyVaccine();
            f.Show();
        }
        
    }
}
