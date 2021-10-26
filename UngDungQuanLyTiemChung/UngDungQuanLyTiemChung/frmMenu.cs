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
    }
}