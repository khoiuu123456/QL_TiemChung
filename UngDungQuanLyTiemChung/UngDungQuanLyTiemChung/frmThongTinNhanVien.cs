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
    public partial class frmThongTinNhanVien : Form
    {
        private DAO_NhanVien nhanvien;
        public frmThongTinNhanVien()
        {
            InitializeComponent();
            nhanvien = new DAO_NhanVien();
        }
        public void loadNV()
        {
            gridNhanVien.DefaultCellStyle.Font = new Font("Times New Roman", 15);
            DataTable dt = nhanvien.loadNhanVien();
            gridNhanVien.DataSource = dt;
            DataBinding(dt);
            gridNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            gridNhanVien.Columns[0].Width = 80;
            gridNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            gridNhanVien.Columns[1].Width = 200;
            gridNhanVien.Columns[2].HeaderText = "Ngày sinh";
            gridNhanVien.Columns[2].Width = 110;
            gridNhanVien.Columns[3].HeaderText = "Giới tính";
            gridNhanVien.Columns[3].Width = 120;
            gridNhanVien.Columns[4].HeaderText = "Số chứng minh";
            gridNhanVien.Columns[4].Width = 160;
            gridNhanVien.Columns[5].HeaderText = "Địa chỉ";
            gridNhanVien.Columns[5].Width = 180;
            gridNhanVien.Columns[6].HeaderText = "Ngày vào làm";
            gridNhanVien.Columns[6].Width = 120;
            gridNhanVien.Columns[7].HeaderText = "Chức vụ";
            gridNhanVien.Columns[7].Width = 180;
            foreach (DataGridViewColumn col in gridNhanVien.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Times New Roman", 20, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }
        public void DataBinding(DataTable dt)
        {
            txtMaNV.DataBindings.Clear();
            Binding b1 = new Binding("Text", dt, "maNhanVien", true, DataSourceUpdateMode.Never);
            txtMaNV.DataBindings.Add(b1);

            txtTenNV.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "tenNhanVien", true, DataSourceUpdateMode.Never);
            txtTenNV.DataBindings.Add(b2);

            txtDiaChi.DataBindings.Clear();
            Binding b3 = new Binding("Text", dt, "diaChi", true, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add(b3);

            txtCMND.DataBindings.Clear();
            Binding b5 = new Binding("Text", dt, "CMND", true, DataSourceUpdateMode.Never);
            txtCMND.DataBindings.Add(b5);  
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void frmThongTinNhanVien_Load(object sender, EventArgs e)
        {
            loadNV();
        }

    }
}
