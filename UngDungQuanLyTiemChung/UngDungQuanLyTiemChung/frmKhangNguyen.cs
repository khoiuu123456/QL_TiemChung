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
    public partial class frmKhangNguyen : Form
    {
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
            //FillGrid_CTKN();
        }
        private void FormatGrid_KN()
        {
            gridView1.Columns.Clear();
            string[] fields = { "MAKHANGNGUYEN", "LOAIBENH" };
            string[] captions = { "Mã kháng nguyên", "loại bệnh" };
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = captions[i];
                gridView1.Columns.Add(col);
                gridView1.Columns[i].Visible = true;
            }
        }
        private void FormatGrid_CTKN()
        {
            gridView2.Columns.Clear();
            string[] fields = { "MAKHANGNGUYEN", "MAVACCINE" };
            string[] captions = { "Mã kháng nguyên", "Mã vaccine" };
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = captions[i];
                gridView2.Columns.Add(col);
                gridView2.Columns[i].Visible = true;
            }
        }
        private void FillGrid_KN()
        {
            gridHienThiKN.DataSource = khangnguyen.GetKhangNguyen();
            DataBindingKN();
            gridHienThiKN.ForceInitialize();
        }
        private void FillGrid_CTKN()
        {
            //string t = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MAKHANGNGUYEN").ToString();
            gridHienThiCT.DataSource = khangnguyen.GetCTKN(txtMaKN.Text.ToString());
            DataBindingCTKN();
            gridHienThiCT.ForceInitialize();
        }
        public void DataBindingKN()
        {
            txtMaKN.DataBindings.Clear();
            txtMaKN.DataBindings.Add("Text", gridHienThiKN.DataSource, "MAKHANGNGUYEN");
            txtLoaiBenh.DataBindings.Clear();
            txtLoaiBenh.DataBindings.Add("Text", gridHienThiKN.DataSource, "LOAIBENH");
            FillGrid_CTKN();
        }
        public void DataBindingCTKN()
        {
            //txtMaKN.DataBindings.Clear();
            //txtMaKN.DataBindings.Add("Text", gridHienThiCT.DataSource, "MAKHANGNGUYEN");

            comboMaVC.DataBindings.Clear();
            comboMaVC.DataBindings.Add("Text", gridHienThiCT.DataSource, "MAVACCINE");
            
        }

        private void gridHienThiKN_Click(object sender, EventArgs e)
        {
            FillGrid_CTKN();
        }


    }
}
