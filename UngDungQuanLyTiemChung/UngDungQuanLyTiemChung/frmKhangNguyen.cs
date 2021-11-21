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
//lib FireSharp to Firebase


namespace UngDungQuanLyTiemChung
{
    public partial class frmKhangNguyen : Form
    {
        DAO_loVaccine cn = new DAO_loVaccine();
        private DAO_KhangNguyen khangnguyen;
        public frmKhangNguyen()
        {
            InitializeComponent();
            khangnguyen = new DAO_KhangNguyen();

        }

        private void frmKhangNguyen_Load(object sender, EventArgs e)
        {
            FormatGrid_KN();
            FillGrid_KN();
            FormatGrid_CTKN();
            FillGrid_CTKN();
            string sql = "SELECT MAVACCINE FROM VACCINE";
            DataTable dt = cn.taobang(sql);
            CboMaVC.DataSource = dt;
            CboMaVC.ValueMember = "MAVACCINE";
        }
        private void FormatGrid_KN()
        {
            gridView2.Columns.Clear();
            string[] fields = { "MAKHANGNGUYEN", "LOAIBENH" };
            string[] captions = { "Mã kháng nguyên", "Loại bệnh" };
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = captions[i];
                gridView2.Columns.Add(col);
                gridView2.Columns[i].Visible = true;
            }
            DevExpress.XtraGrid.Views.Grid.GridView gridViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridViewDetail.GridControl = gridHienThiKN;
            string[] detail_fields = { "MAVACCINE" };
            string[] detail_captions = { "Mã vaccine" };
            for (int i = 0; i < detail_fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = detail_fields[i];
                col.Caption = detail_captions[i];
                gridViewDetail.Columns.Add(col);
                gridViewDetail.Columns[i].Visible = true;
            }
            if (gridHienThiKN.ViewCollection.Count > 1)
                gridHienThiKN.ViewCollection.RemoveAt(1); //loại bỏ cái cũ
            gridHienThiKN.ViewCollection.Add(gridViewDetail);
            DevExpress.XtraGrid.GridLevelNode gridLevelNodeDetail = new DevExpress.XtraGrid.GridLevelNode();
            gridLevelNodeDetail.LevelTemplate = gridViewDetail;
            gridLevelNodeDetail.RelationName = "Danh sách vaccine";
            if (gridHienThiKN.LevelTree.Nodes.Contains("Danh sách vaccine"))
                gridHienThiKN.LevelTree.Nodes.RemoveAt(0); //loại bỏ cái cũ
            gridHienThiKN.LevelTree.Nodes.Add(gridLevelNodeDetail);
        }
        private void FillGrid_KN()
        {
            gridHienThiKN.DataSource = khangnguyen.GetKN().Tables[0];
            gridHienThiKN.ForceInitialize();
        }
        private void FormatGrid_CTKN()
        {
            gridView1.Columns.Clear();
            string[] fields = { "MAKHANGNGUYEN", "MAVACCINE" };
            string[] captions = { "Mã kháng nguyên", "Mã vaccine" };
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = captions[i];
                gridView1.Columns.Add(col);
                gridView1.Columns[i].Visible = true;
            }
        }
        private void FillGrid_CTKN()
        {
            gridHienThiCT.DataSource = khangnguyen.GetCTKN(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MAKHANGNGUYEN").ToString().Trim());
            gridHienThiCT.ForceInitialize();
            DataBindingCTKN();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtLoaiBenh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập loại bệnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string LOAIBENH = txtLoaiBenh.Text.Trim();
            try
            {
                khangnguyen.themKhangNguyen(LOAIBENH);
                MessageBox.Show("Thêm thành công");
                frmKhangNguyen_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm không thành công !");
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            frmKhangNguyen_Load(sender, e);
            txtMaKN.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MAKHANGNGUYEN").ToString().Trim();
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            FillGrid_CTKN();
            try
            {
                txtMaKN.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MAKHANGNGUYEN").ToString().Trim();
                txtLoaiBenh.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "LOAIBENH").ToString().Trim();
                try
                {
                    CboMaVC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MAVACCINE").ToString().Trim();
                }
                catch
                {
                    MessageBox.Show("Không có vaccine!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void DataBindingCTKN()
        {
            CboMaVC.DataBindings.Clear();
            CboMaVC.DataBindings.Add("Text", gridHienThiCT.DataSource, "MAVACCINE");
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtMaKN.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MAKHANGNGUYEN").ToString().Trim();
                DataBindingCTKN();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKN.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã kháng nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string kn = txtMaKN.Text.ToString();
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa kháng nguyên mã " + kn, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    khangnguyen.XoaCTKN(kn);
                    khangnguyen.xoaKhangNguyen(kn);
                    MessageBox.Show("Xóa thành công");
                    frmKhangNguyen_Load(sender, e);
                    txtMaKN.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MAKHANGNGUYEN").ToString().Trim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKN.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã kháng nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string kn = txtMaKN.Text.ToString();
            if (txtLoaiBenh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập loại bệnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string LOAIBENH = txtLoaiBenh.Text.Trim();
            if (MessageBox.Show("Bạn muốn cập nhật lại Kháng nguyên mã " + kn, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (khangnguyen.capNhatKhangNguyen(LOAIBENH, kn))
                {
                    MessageBox.Show("Cập nhật thành công");
                    frmKhangNguyen_Load(sender, e);
                    txtMaKN.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MAKHANGNGUYEN").ToString().Trim();
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công");
                }
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (txtMaKN.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã kháng nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string sql = "SELECT * FROM CHITIETKHANGNGUYEN WHERE MAKHANGNGUYEN= '" + txtMaKN.Text + "' AND MAVACCINE='"+CboMaVC.Text+"'";
            //Số phiếu chưa có, tiến hành lập phiếu mới
            if (cn.CheckKey(sql) == true)
            {
                MessageBox.Show("Vaccine đã tồn tại! vui lòng chọn vaccine khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                khangnguyen.themCTKN(txtMaKN.Text.ToString(), CboMaVC.Text.ToString());
                MessageBox.Show("Thêm thành công");
                frmKhangNguyen_Load(sender, e);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm không thành công !");
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (txtMaKN.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã kháng nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string vc = CboMaVC.Text.ToString();
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa vaccine mã " + vc, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    khangnguyen.HuyCTKN(txtMaKN.Text,vc);
                    MessageBox.Show("Xóa thành công");
                    frmKhangNguyen_Load(sender, e);
                    txtMaKN.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MAKHANGNGUYEN").ToString().Trim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


    }
}
