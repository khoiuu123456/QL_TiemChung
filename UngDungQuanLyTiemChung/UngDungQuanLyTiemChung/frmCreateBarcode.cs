using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UngDungQuanLyTiemChung
{
    public partial class frmCreateBarcode : Form
    {
        DAO_loVaccine cn = new DAO_loVaccine();
        public frmCreateBarcode()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (rdBarcode.Checked == true)
            {
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory
                                                            .Code128WithChecksum;
                pictureBox.Image = barcode.Draw(cboID.Text, 50);
            }
            else
            {
                Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                pictureBox.Image = qrcode.Draw(cboID.Text, 50);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPath.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập đường dẫn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtName.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập Name!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cboDinhDang.Text == ".gif")
                {
                    pictureBox.Image.Save(@"" + txtPath.Text + "\\" + txtName.Text + ".gif", ImageFormat.Gif);
                    MessageBox.Show("Lưu thành công");
                }
                else
                {
                    pictureBox.Image.Save(@"" + txtPath.Text + "\\" + txtName.Text + ".jpg", ImageFormat.Jpeg);
                    MessageBox.Show("Lưu thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đường dẫn lỗi");
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmCreateBarcode_Load(object sender, EventArgs e)
        {
            string sql2 = "SELECT SOLO FROM LOVACCINE";
            DataTable dt2 = cn.taobang(sql2);
            cboID.DataSource = dt2;
            cboID.ValueMember = "SOLO";
            cboID.SelectedIndex = 0;
            cboDinhDang.SelectedIndex = 0;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            txtName.Text = "";
            txtPath.Text = "";
            cboID.SelectedIndex = 0;
            frmCreateBarcode_Load(sender,e);
        }
    }
}
