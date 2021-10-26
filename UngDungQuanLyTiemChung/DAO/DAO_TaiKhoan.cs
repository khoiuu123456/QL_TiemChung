using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class DAO_TaiKhoan
    {
        static SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
        public DTO_TaiKhoan layTaiKhoan(string TenTaiKhoan)
        {
            DTO_TaiKhoan taikhoan = null;
            try
            {
                DataTable dt = new DataTable();
                conn.Open();
                string sql = "SELECT * FROM dbo.TAIKHOAN WHERE TENTAIKHOAN = '" + TenTaiKhoan + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    taikhoan = new DTO_TaiKhoan(row);
                }
                return taikhoan;
            }
            catch { }
            finally { conn.Close(); }
            return taikhoan;
        }
        public int kiemTraTenDN(string TenTaiKhoan)
        {
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM dbo.TAIKHOAN WHERE TENTAIKHOAN ='" + TenTaiKhoan + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int kq = (int)cmd.ExecuteScalar();
                return kq;
            }
            catch { return -1; }
            finally { conn.Close(); }
        }
        public int sp_KiemTraDangNhap(string tenDangnhap, string matKhau)
        {
            try
            {
                int kq = 0;
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_KiemTraDangNhap", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@tenTaiKhoan", System.Data.SqlDbType.NVarChar);
                par1.Value = tenDangnhap;
                SqlParameter par2 = new SqlParameter("@matKhau", System.Data.SqlDbType.NVarChar);
                par2.Value = matKhau;
                SqlParameter par3 = new SqlParameter("@Kq", System.Data.SqlDbType.Int);
                par3.Value = kq;
                par3.Direction = System.Data.ParameterDirection.Output;
                par3.Value = kq;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.ExecuteNonQuery();
                return (int)par3.Value;
            }
            catch
            {}
            finally
            {
                conn.Close();
            }
            return -1;
        }
        public DataTable loadTaiKhoan()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT TENTAIKHOAN,MATKHAU,TINHTRANG,TENNV FROM dbo.TAIKHOAN,dbo.NHANVIEN WHERE dbo.TAIKHOAN.MANV = dbo.NHANVIEN.MANV AND TINHTRANG = 1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch { }
            finally { conn.Close(); }
            return dt;
        }
        public DataTable loadTaiKhoan(int maNV)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT TENTAIKHOAN,MATKHAU,TINHTRANG,TENNV FROM dbo.TAIKHOAN,dbo.NHANVIEN WHERE dbo.TAIKHOAN.MANV = dbo.NHANVIEN.MANV AND TINHTRANG = 1 AND dbo.TAIKHOAN.MANV = " + maNV + "";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch { }
            finally { conn.Close(); }
            return dt;
        }
    }
}
