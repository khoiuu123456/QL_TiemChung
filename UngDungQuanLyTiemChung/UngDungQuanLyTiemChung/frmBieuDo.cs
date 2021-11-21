using DAO;
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
    public partial class frmBieuDo : Form
    {
        DataTable bd;
        DAO_loVaccine cn = new DAO_loVaccine();

        public frmBieuDo()
        {
            InitializeComponent();
        }

        private void frmBieuDo_Load(object sender, EventArgs e)
        {
            fillChart();
            napvaolistview();
            anh();
        }
        private void fillChart()
        {
            string sql;
            sql = "select MONTH(NGAYXUAT),sum(SOLIEUXUAT) from PHIEUXUAT,CHITIETPHIEUXUAT where PHIEUXUAT.MAPHIEUXUAT = CHITIETPHIEUXUAT.MAPHIEUXUAT group by MONTH(NGAYXUAT)";
            bd = cn.returnquery(sql);
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "tháng";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "SoLieuxuat";
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            for (int i = 0; i < bd.Rows.Count; i++)
            {
                chart1.Series["abc"].Points.AddXY(bd.Rows[i][0], bd.Rows[i][1]);
                //chuyển biểu đồ tròn
                //chart1.Series[0].ChartType = SeriesChartType.Pie;
            }
        }
        private void napvaolistview()
        {
            listView1.Items.Clear();
            string sql;
            sql = "select MONTH(NGAYXUAT),COUNT(PHIEUXUAT.MAPHIEUXUAT),COUNT(SOLO),sum(SOLUONGXUAT),sum(SOLIEUXUAT) from PHIEUXUAT,CHITIETPHIEUXUAT where PHIEUXUAT.MAPHIEUXUAT = CHITIETPHIEUXUAT.MAPHIEUXUAT group by MONTH(NGAYXUAT)";
            DataTable nodecha = new DataTable();
            nodecha = cn.returnquery(sql);

            foreach (DataRow dwr in nodecha.Rows)
            {
                ListViewItem lvw = new ListViewItem();
                lvw.Text = dwr[0].ToString();
                lvw.SubItems.Add(dwr[1].ToString());
                lvw.SubItems.Add(dwr[2].ToString());
                lvw.SubItems.Add(dwr[3].ToString());
                lvw.SubItems.Add(dwr[4].ToString());
                listView1.Items.Add(lvw);
            }
            cn.GetFieldValues(sql);
        }
        private void anh()
        {
            //string sql = "SELECT Anh,SUM(dh.Soluong) FROM (HANGHOA as nv INNER JOIN CTHD as dh ON nv.Mahang = dh.Mahang) INNER JOIN HOADON as ct ON ct.MaHD=dh.MaHD GROUP BY Anh having SUM(dh.Soluong) >= all (SELECT SUM(h.Soluong) FROM (HANGHOA as v INNER JOIN CTHD as h ON v.Mahang = h.Mahang) INNER JOIN HOADON as t ON t.MaHD=h.MaHD GROUP BY Anh)";
            //txtAnh.Text = cn.GetFieldValues(sql);
            //picAnh.Image = Image.FromFile(".\\..\\..\\Image\\" + txtAnh.Text);
            string sql2 = "SELECT top 1 nv.SOLO FROM (LOVACCINE as nv INNER JOIN CHITIETPHIEUXUAT as dh ON nv.SOLO = dh.SOLO) INNER JOIN PHIEUXUAT as ct ON ct.MAPHIEUXUAT=dh.MAPHIEUXUAT GROUP BY nv.SOLO order by SUM(dh.SOLIEUXUAT) desc";
            string solo = cn.GetFieldValues(sql2);
            string sql3 = "select TENVACCINE from VACCINE, LOVACCINE where VACCINE.MAVACCINE = LOVACCINE.MAVACCINE and SOLO='"+solo+"'";
            lblTenVC.Text = cn.GetFieldValues(sql3);
            string sql4 = "SELECT top 1 SUM(dh.SOLIEUXUAT) FROM (LOVACCINE as nv INNER JOIN CHITIETPHIEUXUAT as dh ON nv.SOLO = dh.SOLO) INNER JOIN PHIEUXUAT as ct ON ct.MAPHIEUXUAT=dh.MAPHIEUXUAT GROUP BY nv.SOLO order by SUM(dh.SOLIEUXUAT) desc";
            lblSoLieu.Text = cn.GetFieldValues(sql4);
        }

    }
}
