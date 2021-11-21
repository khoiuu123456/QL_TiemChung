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
    public partial class frmNhaCungCap : Form
    {
        private DAO_NhaCungCap nhacc;
        public frmNhaCungCap()
        {
            InitializeComponent();
            nhacc = new DAO_NhaCungCap();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            txtMaNCC.ReadOnly = true;
            FormatGrid_NCC();
            FillGrid_NCC();
        }
        private void FormatGrid_NCC()
        {
            gridView1.Columns.Clear();
            string[] fields = { "MANCC", "TENNCC" };
            string[] captions = { "Mã nhà cung cấp", "Tên nhà cung cấp" };
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = captions[i];
                gridView1.Columns.Add(col);
                gridView1.Columns[i].Visible = true;
            }
        }
        private void FillGrid_NCC()
        {
            gridHienThi.DataSource = nhacc.GetNCC();
            gridHienThi.ForceInitialize();
            DataBindingCTKN();
        }
        public void DataBindingCTKN()
        {
            txtMaNCC.DataBindings.Clear();
            txtMaNCC.DataBindings.Add("Text", gridHienThi.DataSource, "MANCC");
            txtTenNCC.DataBindings.Clear();
            txtTenNCC.DataBindings.Add("Text", gridHienThi.DataSource, "TENNCC");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenNCC.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string TENNCC = txtTenNCC.Text.Trim();
            try
            {
                nhacc.themNCC(TENNCC);
                MessageBox.Show("Thêm thành công");
                frmNhaCungCap_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm không thành công !");
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ncc = txtMaNCC.Text.ToString();
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp mã " + ncc, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    nhacc.xoaNCC(ncc);
                    MessageBox.Show("Xóa thành công");
                    frmNhaCungCap_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            frmNhaCungCap_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ncc = txtMaNCC.Text.ToString();
            if (txtTenNCC.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string TENNCC = txtTenNCC.Text.Trim();
            if (MessageBox.Show("Bạn muốn cập nhật lại nhà cung cấp mã " + ncc, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (nhacc.capNhatNCC(TENNCC, ncc))
                {
                    MessageBox.Show("Cập nhật thành công");
                    frmNhaCungCap_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công");
                }
            }
        }
    }
}
