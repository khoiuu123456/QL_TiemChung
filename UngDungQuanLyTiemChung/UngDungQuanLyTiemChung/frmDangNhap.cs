using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAO;
using DTO;
namespace UngDungQuanLyTiemChung
{
    public partial class frmDangNhap : Form
    {

        public frmDangNhap()
        {
            InitializeComponent();
            txtDangNhap.ForeColor = Color.LightGray;
            txtDangNhap.Text = "Vui lòng nhập tên đăng nhập !";
            this.txtDangNhap.Leave += new System.EventHandler(this.txtDangNhap_Leave);
            this.txtDangNhap.Enter += new System.EventHandler(this.txtDangNhap_Enter);

            txtMatKhau.ForeColor = Color.LightGray;
            txtMatKhau.Text = "Vui lòng nhập mật khẩu !";
            this.txtMatKhau.Leave += new System.EventHandler(this.txtMatKhau_Leave);
            this.txtMatKhau.Enter += new System.EventHandler(this.txtMatKhau_Enter);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (chkLuuMK.Checked == false)
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmCauHinh frmcauhinh = new frmCauHinh();
            this.Hide();
            frmcauhinh.ShowDialog();
            this.Show();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            //Kết nối database
            SQLDatabase.ConnectionString = Properties.Settings.Default.ConectionString;
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                SQLDatabase.OpenConnection(conn);
            }
            catch { MessageBox.Show("Không thể kết nối đến máy chủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            finally { SQLDatabase.CloseConnection(conn); }
            //Kiểm tra thông tin đăng nhập
            if (txtDangNhap.Text == String.Empty)
            {
                return;
            }
            if (txtMatKhau.Text == String.Empty)
            {
                return;
            }
            try
            {
                string userName = "";
                string passWord = "";
                userName = txtDangNhap.Text;
                passWord = txtMatKhau.Text;
                DAO_TaiKhoan taiKhoan = new DAO_TaiKhoan();
                int kqDN = taiKhoan.sp_KiemTraDangNhap(userName, passWord);
                if (kqDN == 1)
                {
                    DTO_TaiKhoan _TaiKhoan = taiKhoan.layTaiKhoan(userName);
                    frmMain frmmain = new frmMain();
                    frmMenu frmmenu = new frmMenu();
                    if (chkLuuMK.Checked == true)
                    {
                        Properties.Settings.Default.Username = userName;
                        Properties.Settings.Default.Password = passWord;
                        Properties.Settings.Default.Save();
                    }
                    if (chkLuuMK.Checked == false)
                    {
                        Properties.Settings.Default.Username = "";
                        Properties.Settings.Default.Password = "";
                        Properties.Settings.Default.Save();
                    }
                    this.Hide();
                    frmmenu.Show();

                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai!", "Thông báo");
                    txtDangNhap.Focus();
                }

            }
            catch
            {
                MessageBox.Show("Đăng nhập không thành công!", "Thông báo");
            }
            /*frmMain frm = new frmMain();
            this.Hide();
            frm.ShowDialog();*/
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            var hidden = new Bitmap(UngDungQuanLyTiemChung.Properties.Resources.hidden);
            var eye = new Bitmap(UngDungQuanLyTiemChung.Properties.Resources.eye);
            if (chkShow.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
                chkShow.Image = hidden;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
                chkShow.Image = eye;
            }
        }

        private void txtDangNhap_Leave(object sender, EventArgs e)
        {
            if (txtDangNhap.Text == "")
            {
                txtDangNhap.Text = "Vui lòng nhập tên đăng nhập !";
                txtDangNhap.ForeColor = Color.Gray;
            }
        }
        private void txtDangNhap_Enter(object sender, EventArgs e)
        {
            if (txtDangNhap.Text == "Vui lòng nhập tên đăng nhập !")
            {
                txtDangNhap.Text = "";
                txtDangNhap.ForeColor = Color.Black;
            }
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                txtMatKhau.Text = "Vui lòng nhập mật khẩu !";
                txtMatKhau.ForeColor = Color.Gray;
                txtMatKhau.UseSystemPasswordChar = false;
            }
        }
        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Vui lòng nhập mật khẩu !")
            {
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = Color.Black;
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Username.Length > 0 && Properties.Settings.Default.Password.Length > 0)
            {
                txtDangNhap.Text = Properties.Settings.Default.Username;
                txtMatKhau.Text = Properties.Settings.Default.Password;
                txtMatKhau.ForeColor = Color.Black;
                txtDangNhap.ForeColor = Color.Black;
                txtMatKhau.UseSystemPasswordChar = true;
            }
            else
            {
                txtMatKhau.ForeColor = Color.Black;
                txtDangNhap.ForeColor = Color.Black;
                chkLuuMK.Checked = false;
            }
        }
        private void frmDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangnhap.PerformClick();
            }
        }
        private void txtDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangnhap.PerformClick();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangnhap.PerformClick();
            }
        }
    }
}
