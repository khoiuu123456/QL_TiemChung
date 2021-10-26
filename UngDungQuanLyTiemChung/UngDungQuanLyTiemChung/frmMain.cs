using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UngDungQuanLyTiemChung
{
    public partial class frmMain : Form
    {
        private Form activeForm;
        public frmMain()
        {
            InitializeComponent();
        }
        private void HienSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (panelMenu.Visible == true)
            {
                panelMenu.Visible = false;
            }
            else
            {
                panelMenu.Visible = true;
            }
        }
        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            HienSubMenu(panelKhachHang);
        }
        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            HienSubMenu(panelNhanVien);
        }
        private void OpenChildForm(Form childForm, Object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            activeForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelForm.Controls.Add(childForm);
            this.panelForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbTieude.Text = childForm.Text;
        }

        private void btnNguoiChamSoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHoSoNguoiChamSoc(), sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            lbTieude.Text = "Trạm Y tế xã";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            frmDangNhap frmdn = new frmDangNhap();
            this.Close();
            frmdn.Show();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                lbTieude.Location = new Point((panelTieuDe.Width - lbTieude.Width) / 2 - 5, lbTieude.Top);
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                lbTieude.Location = new Point((panelTieuDe.Width - lbTieude.Width) / 2 - 5, lbTieude.Top);
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnMinimus_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnThongTinNV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongTinNhanVien(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyTaiKhoan(), sender);
        }
    }
}
