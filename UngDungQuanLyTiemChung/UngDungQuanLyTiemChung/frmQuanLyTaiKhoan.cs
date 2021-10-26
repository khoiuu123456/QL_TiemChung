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
    public partial class frmQuanLyTaiKhoan : Form
    {
        private DAO_NhanVien nhanvien;
        private DAO_TaiKhoan taikhoan;
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
            nhanvien = new DAO_NhanVien();
            taikhoan = new DAO_TaiKhoan();
        }

        private void chkMk_CheckedChanged(object sender, EventArgs e)
        {
            var hidden = new Bitmap(UngDungQuanLyTiemChung.Properties.Resources.hidden);
            var eye = new Bitmap(UngDungQuanLyTiemChung.Properties.Resources.eye);
            if (chkMk.Checked)
            {
                txtMatkhau.UseSystemPasswordChar = false;
                chkMk.Image = hidden;
            }
            else
            {
                txtMatkhau.UseSystemPasswordChar = true;
                chkMk.Image = eye;
            }
        }
        private void chkRemk_CheckedChanged(object sender, EventArgs e)
        {
            var hidden = new Bitmap(UngDungQuanLyTiemChung.Properties.Resources.hidden);
            var eye = new Bitmap(UngDungQuanLyTiemChung.Properties.Resources.eye);
            if (chkRemk.Checked)
            {
                txtRematkhau.UseSystemPasswordChar = false;
                chkRemk.Image = hidden;
            }
            else
            {
                txtRematkhau.UseSystemPasswordChar = true;
                chkRemk.Image = eye;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
        public void loadNV()
        {
            DataTable dt = nhanvien.loadNhanVien();
            gridNhanVien.DataSource = dt;
            gridNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            gridNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            gridNhanVien.Columns[2].HeaderText = "Ngày sinh";
            gridNhanVien.Columns[3].HeaderText = "Giới tính";
            gridNhanVien.Columns[4].HeaderText = "Số chứng minh";
            gridNhanVien.Columns[5].HeaderText = "Địa chỉ";
            gridNhanVien.Columns[6].HeaderText = "Ngày vào làm";
            gridNhanVien.Columns[7].HeaderText = "Chức vụ";
        }
        public void loadTK()
        {
            DataTable dt = taikhoan.loadTaiKhoan();
            gridTaiKhoan.DataSource = dt;
            gridTaiKhoan.Columns[0].HeaderText = "Tên đăng nhập";
            gridTaiKhoan.Columns[1].HeaderText = "Mật khẩu";
            gridTaiKhoan.Columns[2].HeaderText = "Tình trạng";
            gridTaiKhoan.Columns[3].HeaderText = "Tên nhân viên";
        }
        public void loadTK(int maNV)
        {
            DataTable dt = taikhoan.loadTaiKhoan(maNV);
            gridTaiKhoan.DataSource = dt;
            gridTaiKhoan.Columns[0].HeaderText = "Tên đăng nhập";
            gridTaiKhoan.Columns[1].HeaderText = "Mật khẩu";
            gridTaiKhoan.Columns[2].HeaderText = "Tình trạng";
            gridTaiKhoan.Columns[3].HeaderText = "Tên nhân viên";
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            loadNV();
            loadTK();
        }

        private void gridNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = gridNhanVien.Rows[rowIndex];
            int maNV = int.Parse(row.Cells[0].Value.ToString());
            loadTK(maNV);
        }
    }
}
