using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DTO
{
    public class DTO_TaiKhoan
    {
        string tenTaiKhoan;

        public string TenTaiKhoan
        {
            get { return tenTaiKhoan; }
            set { tenTaiKhoan = value; }
        }
        int maNhanVien;

        public int MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }
        string matKhau;

        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }
        int tinhTrang;

        public int TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }

        public DTO_TaiKhoan(DataRow row)
        {
                this.maNhanVien = (int)row["MANV"];
                this.tinhTrang = (int)row["TINHTRANG"];
                this.tenTaiKhoan = row["TENTAIKHOAN"].ToString();
                this.matKhau = row["MATKHAU"].ToString();
        }
        public DTO_TaiKhoan()
        {
        }
    }
}
