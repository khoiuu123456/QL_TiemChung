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
    public partial class frmXuatVaccine : Form
    {
        public static string ScanSolo="";
        DAO_loVaccine cn = new DAO_loVaccine();
        private DAO_XuatVaccine xuatvc;
        public frmXuatVaccine()
        {
            InitializeComponent();
            xuatvc = new DAO_XuatVaccine();
        }

        private void frmXuatVaccine_Load(object sender, EventArgs e)
        {
            //load combobox mã phiếu xuất
            string sql = "SELECT MAPHIEUXUAT FROM PHIEUXUAT";
            DataTable dt = cn.taobang(sql);
            CboXuatVC.DataSource = dt;
            CboXuatVC.ValueMember = "MAPHIEUXUAT";
            CboXuatVC.SelectedIndex = 0;
            //load combobox mã KHT
            string sql1 = "SELECT MAKHT FROM KEHOACHTIEM";
            DataTable dt1 = cn.taobang(sql1);
            cboMaKHT.DataSource = dt1;
            cboMaKHT.ValueMember = "MAKHT";
            //load combobox số lô
            string sql2 = "SELECT SOLO FROM LOVACCINE WHERE HANSUDUNG > GETDATE() ORDER BY HANSUDUNG ASC";
            DataTable dt2 = cn.taobang(sql2);
            cboSoLo.DataSource = dt2;
            cboSoLo.ValueMember = "SOLO";
            cboSoLo.SelectedIndex = -1;
            cboSoLo.SelectedText = ScanSolo;
            //load data
            FormatGrid_CTXuatVC();
            FillGrid_CTXuatVC();
            //load người lập phiếu
            string str;
            str = "SELECT TENNV FROM NHANVIEN WHERE MANV = N'" + txtMaNV.Text + "'";
            txtTenNV.Text = cn.GetFieldValues(str);
            //enable
            btnHuy.Enabled = false;
            txtMaNV.ReadOnly = true;
            txtTenNV.ReadOnly = true;
        }
        private void FormatGrid_CTXuatVC()
        {
            gridView1.Columns.Clear();
            string[] fields = { "SOLO", "SOLUONGXUAT", "SOLIEUXUAT"};
            string[] captions = { "Số lô", "Số lượng xuất", "Số liều xuất"};
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = captions[i];
                gridView1.Columns.Add(col);
                gridView1.Columns[i].Visible = true;
            }
        }
        private void FillGrid_CTXuatVC()
        {
            gridHienThiXUAT.DataSource = xuatvc.GetCTXUATVC(CboXuatVC.Text.ToString());
            gridHienThiXUAT.ForceInitialize();
        }
        private void LoadInfoPhieuXuat()
        {
            string str;
            str = "SELECT NGAYXUAT FROM PHIEUXUAT WHERE MAPHIEUXUAT = N'" + CboXuatVC.Text + "'";
            dateNgayXuat.Text = cn.GetFieldValues(str);
            str = "SELECT GHICHU FROM PHIEUXUAT WHERE MAPHIEUXUAT = N'" + CboXuatVC.Text + "'";
            txtGhiChu.Text = cn.GetFieldValues(str);
            str = "Select MANV from PHIEUXUAT where MAPHIEUXUAT= N'" + CboXuatVC.Text + "'";
            txtMaNV.Text = cn.GetFieldValues(str);
            str = "SELECT MAKHT FROM PHIEUXUAT WHERE MAPHIEUXUAT = N'" + CboXuatVC.Text + "'";
            cboMaKHT.Text = cn.GetFieldValues(str);
            str = "SELECT NGAYBATDAU FROM KEHOACHTIEM WHERE MAKHT = N'" + cboMaKHT.Text + "'";
            dateNgayBD.Text = cn.GetFieldValues(str);
            str = "SELECT SONGAY FROM KEHOACHTIEM WHERE MAKHT = N'" + cboMaKHT.Text + "'";
            txtSoNgay.Text = cn.GetFieldValues(str);
        }
        private void ResetInfoPhieuXuat()
        {
            txtGhiChu.Text = "";
            txtSoNgay.Text = "";
            DateTime now = DateTime.Now;
            dateNgayXuat.Text = now.ToString();
            gridHienThiXUAT.DataSource = null;
            gridView1.Columns.Clear();
            
        }
        private void ResetInfoCTPX()
        {
            cboSoLo.Text = "";
            txtSoLuongXuat.Text = "";
            txtSoLieuXuat.Text = "";
        }

        private void cboMaKHT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            str = "SELECT NGAYBATDAU FROM KEHOACHTIEM WHERE MAKHT = N'" + cboMaKHT.Text + "'";
            dateNgayBD.Text = cn.GetFieldValues(str);
            str = "SELECT SONGAY FROM KEHOACHTIEM WHERE MAKHT = N'" + cboMaKHT.Text + "'";
            txtSoNgay.Text = cn.GetFieldValues(str);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cboMaKHT.Text = "";
            txtGhiChu.Text = "";
            btnThem.Enabled = false;
            CboXuatVC.Enabled = false;
            btnHuy.Enabled = true;
            string CauLenh = "declare @sophieu char(5) exec @sophieu= DBO.AUTO_IDPX select @sophieu";
            SqlCommand cmd = new SqlCommand(CauLenh, cn.conn);
            object value = cmd.ExecuteScalar();
            CboXuatVC.Text = value.ToString();
            //RESETINFO
            ResetInfoPhieuXuat();
            ResetInfoCTPX();
            //load combobox số lô 
            string sql = "SELECT SOLO FROM LOVACCINE";
            DataTable dt = cn.taobang(sql);
            cboSoLo.DataSource = dt;
            cboSoLo.ValueMember = "SOLO";
            cboSoLo.SelectedIndex = -1;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmXuatVaccine_Load(sender, e);
            btnThem.Enabled = true;
            CboXuatVC.Enabled = true;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                cboSoLo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SOLO").ToString().Trim();
                txtSoLuongXuat.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SOLUONGXUAT").ToString().Trim();
                txtSoLieuXuat.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SOLIEUXUAT").ToString().Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == true)
            {
                frmXuatVaccine_Load(sender, e);
                btnThem.Enabled = true;
                CboXuatVC.Enabled = true;
            }
            else
            {
                cboSoLo.SelectedText = ScanSolo;
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (cboMaKHT.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn kế hoạch tiêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (txtSoLuongXuat.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSoLieuXuat.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số liều xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboSoLo.Text.Length != 0)
            {
                string str;
                str = "SELECT SOLUONGTON FROM LOVACCINE WHERE SOLO = N'" + cboSoLo.Text + "'";
                string SoLuongTon = cn.GetFieldValues(str);
                str = "SELECT SOLIEUTON FROM LOVACCINE WHERE SOLO = N'" + cboSoLo.Text + "'";
                string SoLieuTon = cn.GetFieldValues(str);
                if (Convert.ToInt32(txtSoLuongXuat.Text) > Convert.ToInt32(SoLuongTon))
                {
                    MessageBox.Show("Số lượng vaccine còn lại trong lô không đủ để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt32(txtSoLieuXuat.Text) > Convert.ToInt32(SoLieuTon))
                {
                    MessageBox.Show("Số liều vaccine còn lại trong lô không đủ để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            if (btnThem.Enabled == false)
            {
                // Thêm phiếu xuất
                string MANV = txtMaNV.Text.Trim();
                string MAKHT = cboMaKHT.Text.Trim();
                string NGAYXUAT = dateNgayXuat.Value.ToString("MM/dd/yyyy");
                string GHICHU = txtGhiChu.Text.Trim();
                // Thêm CTPX
                string MAPHIEUXUAT = CboXuatVC.Text.Trim();
                string SOLO = cboSoLo.Text.Trim();
                string SOLUONGXUAT = txtSoLuongXuat.Text.Trim();
                string SOLIEUXUAT = txtSoLieuXuat.Text.Trim();
                try
                {
                    xuatvc.themPhieuXuat(NGAYXUAT,GHICHU,MANV,MAKHT);
                    xuatvc.themCTXUAT(MAPHIEUXUAT, SOLO, SOLUONGXUAT, SOLIEUXUAT);
                    MessageBox.Show("Lập phiếu thành công!");
                    frmXuatVaccine_Load(sender, e);
                    btnThem.Enabled = true;
                    CboXuatVC.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lập không thành công !");
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                // Thêm CTPX
                string MAPHIEUXUAT = CboXuatVC.Text.Trim();
                string SOLO = cboSoLo.Text.Trim();
                string SOLUONGXUAT = txtSoLuongXuat.Text.Trim();
                string SOLIEUXUAT = txtSoLieuXuat.Text.Trim();
                try
                {
                    string sql = "SELECT * FROM CHITIETPHIEUXUAT WHERE MAPHIEUXUAT= '" + CboXuatVC.Text + "' AND SOLO='" + cboSoLo.Text + "'";
                    //kiểm tra lovaccine đã tồn tại chưa?
                    if (cn.CheckKey(sql) == true)
                    {
                        MessageBox.Show("Lô vaccine đã tồn tại! vui lòng chọn lô vaccine khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        xuatvc.themCTXUAT(MAPHIEUXUAT, SOLO, SOLUONGXUAT, SOLIEUXUAT);
                        MessageBox.Show("Thêm lô vaccine thành công!");
                        frmXuatVaccine_Load(sender, e);
                        btnThem.Enabled = true;
                        CboXuatVC.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm không thành công !");
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtSoLuongXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoLieuXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string px = CboXuatVC.Text.ToString();
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu xuất mã " + px, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    xuatvc.XoaCTXuat(px);
                    xuatvc.XoaPhieuXuat(px);
                    MessageBox.Show("Xóa thành công");
                    frmXuatVaccine_Load(sender, e);
                    btnThem.Enabled = true;
                    CboXuatVC.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CboXuatVC_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid_CTXuatVC();
            LoadInfoPhieuXuat();
            ResetInfoCTPX();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmScanner frm = new frmScanner();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmQuanLyVaccine.trangthai = 1;
            frmQuanLyVaccine f = new frmQuanLyVaccine();
            f.Show();
        }
    }
}
