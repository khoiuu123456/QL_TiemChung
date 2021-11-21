using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace UngDungQuanLyTiemChung
{
    public partial class frmMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }*/
            Application.Exit();
        }
        private void btnDangnhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDangNhap dangnhap = new frmDangNhap();
            this.Hide();
            dangnhap.Show();

        }

        private void btnDangxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDangNhap dangnhap = new frmDangNhap();
            this.Hide();
            dangnhap.Show();
        }

        private void btnHosoNCS_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmHoSoNguoiChamSoc hoso = new frmHoSoNguoiChamSoc();
            hoso.MdiParent = this;
            hoso.Show();
        }

        private void btnThongTinNV_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQuanLyVaccine.trangthai = 0;
            frmQuanLyVaccine vc = new frmQuanLyVaccine();
            vc.MdiParent = this;
            vc.Show();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmKhangNguyen kn = new frmKhangNguyen();
            kn.MdiParent = this;
            kn.Show();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNhapVaccine nhapvc = new frmNhapVaccine();
            nhapvc.MdiParent = this;
            nhapvc.Show();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmXuatVaccine xuatvc = new frmXuatVaccine();
            xuatvc.MdiParent = this;
            xuatvc.Show();
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBieuDo f = new frmBieuDo();
            f.MdiParent = this;
            f.Show();
        }
    }
}