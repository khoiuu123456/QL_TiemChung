using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DAO_KhangNguyen
    {
        static SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
        public DataTable GetKhangNguyen()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM dbo.KHANGNGUYEN";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch { }
            finally { conn.Close(); }
            return dt;
        }
        public DataTable GetCTKN(string makn)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM dbo.CHITIETKHANGNGUYEN where MAKHANGNGUYEN like'%"+makn+"%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch { }
            finally { conn.Close(); }
            return dt;
        }
   
        public bool themNguoiChamSoc(string hoTen, string ngaySinh, string SDT, string CMND, string diaChi)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_ThemNguoiChamSoc", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@hoTen", SqlDbType.NVarChar);
                par1.Value = hoTen;
                SqlParameter par2 = new SqlParameter("@ngaySinh", SqlDbType.NVarChar);
                par2.Value = ngaySinh;
                SqlParameter par3 = new SqlParameter("@sdt", SqlDbType.NVarChar);
                par3.Value = SDT;
                SqlParameter par4 = new SqlParameter("@cmnd", SqlDbType.NVarChar);
                par4.Value = CMND;
                SqlParameter par5 = new SqlParameter("@diaChi", SqlDbType.NVarChar);
                par5.Value = diaChi;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.Parameters.Add(par5);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { 
                
                return false; 
            }

            finally { SQLDatabase.CloseConnection(conn); }
        }
        public void xoaNguoiChamSoc(string mancs)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "DELETE dbo.NGUOICHAMSOC WHERE MANCS = '"+mancs+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool capNhatNguoiChamSoc(string hoTen, string ngaySinh, string SDT, string CMND, string diaChi,string mancs)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "UPDATE dbo.NGUOICHAMSOC SET HOTEN = N'" + hoTen + "',NGAYSINH = '" + ngaySinh + "',SDT = '" + SDT + "',CMND = '" + CMND + "',DIACHI = N'" + diaChi + "' WHERE MANCS = '" + mancs + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public int sp_KiemTraRangBuocNCS(string mancs)
        {
            try
            {
                int kq = 0;
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_KiemRangBuocNguoiChamSoc", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@mancs", System.Data.SqlDbType.NVarChar);
                par1.Value = mancs;
                SqlParameter par2 = new SqlParameter("@Kq", System.Data.SqlDbType.Int);
                par2.Value = kq;
                par2.Direction = System.Data.ParameterDirection.Output;
                par2.Value = kq;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
                return (int)par2.Value;
            }
            catch
            {}
            finally
            {
                conn.Close();
            }
            return -1;
        }
        public int sp_KiemTraTonTaiNCS(string mancs)
        {
            try
            {
                int kq = 0;
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_KiemRangNguoiChamSocTonTai", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@mancs", System.Data.SqlDbType.NVarChar);
                par1.Value = mancs;
                SqlParameter par2 = new SqlParameter("@Kq", System.Data.SqlDbType.Int);
                par2.Value = kq;
                par2.Direction = System.Data.ParameterDirection.Output;
                par2.Value = kq;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
                return (int)par2.Value;
            }
            catch
            { }
            finally
            {
                conn.Close();
            }
            return -1;
        }
        public bool themThongTinBe(string hoTenBe, string ngaySinh, string gioiTinh, string diaChiBe, string maNCS)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_ThemThongTinBe", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@hotenBe", SqlDbType.NVarChar);
                par1.Value = hoTenBe;
                SqlParameter par2 = new SqlParameter("@ngaySinh", SqlDbType.NVarChar);
                par2.Value = ngaySinh;
                SqlParameter par3 = new SqlParameter("@gioiTinh", SqlDbType.NVarChar);
                par3.Value = gioiTinh;
                SqlParameter par4 = new SqlParameter("@diaChibe", SqlDbType.NVarChar);
                par4.Value = diaChiBe;
                SqlParameter par5 = new SqlParameter("@maNCS", SqlDbType.NVarChar);
                par5.Value = maNCS;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.Parameters.Add(par5);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool xoaThongTinBe(string maBe)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "DELETE dbo.THONGTINBE WHERE MABE = '" + maBe + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch {return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool capNhatThongTinBe(string hoTenBe, string ngaySinh, string gioiTinh, string diaChiBe, string maNCS,string mabe)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "UPDATE dbo.THONGTINBE SET TENBE = N'" + hoTenBe + "',NGAYSINH = '" + ngaySinh + "',GIOITINH = N'" + gioiTinh + "',DIACHI = N'" + diaChiBe + "',MANCS = N'" + maNCS + "' WHERE MABE = '" + mabe + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
    }
}
