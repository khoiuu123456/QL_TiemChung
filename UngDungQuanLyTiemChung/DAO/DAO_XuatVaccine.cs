using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DAO_XuatVaccine
    {
        static SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
        public DataTable GetCTXUATVC(string mapx)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT SOLO,SOLUONGXUAT,SOLIEUXUAT FROM dbo.CHITIETPHIEUXUAT where MAPHIEUXUAT like'%" + mapx + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch { }
            finally { conn.Close(); }
            return dt;
        }

        public void themPhieuXuat(string NGAYXUAT, string GHICHU, string MANV, string MAKHT)
        {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_ThemPhieuXuat", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@NGAYXUAT", SqlDbType.NVarChar);
                par1.Value = NGAYXUAT;
                SqlParameter par2 = new SqlParameter("@GHICHU", SqlDbType.NVarChar);
                par2.Value = GHICHU;
                SqlParameter par3 = new SqlParameter("@MANV", SqlDbType.NVarChar);
                par3.Value = MANV;
                SqlParameter par4 = new SqlParameter("@MAKHT", SqlDbType.NVarChar);
                par4.Value = MAKHT;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                SQLDatabase.CloseConnection(conn);
        }
        public void themCTXUAT(string MAPHIEUXUAT, string SOLO, string SOLUONGXUAT, string SOLIEUXUAT)
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_ThemCTXuat", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter("@MAPHIEUXUAT", SqlDbType.NVarChar);
            par1.Value = MAPHIEUXUAT;
            SqlParameter par2 = new SqlParameter("@SOLO", SqlDbType.NVarChar);
            par2.Value = SOLO;
            SqlParameter par3 = new SqlParameter("@SOLUONGXUAT", SqlDbType.NVarChar);
            par3.Value = SOLUONGXUAT;
            SqlParameter par4 = new SqlParameter("@SOLIEUXUAT", SqlDbType.NVarChar);
            par4.Value = SOLIEUXUAT;
            cmd.Parameters.Add(par1);
            cmd.Parameters.Add(par2);
            cmd.Parameters.Add(par3);
            cmd.Parameters.Add(par4);
            cmd.ExecuteNonQuery();
            SQLDatabase.CloseConnection(conn);
        }
        public void XoaPhieuXuat(string mapx)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "DELETE dbo.PHIEUXUAT WHERE MAPHIEUXUAT = '" + mapx + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public void XoaCTXuat(string mapx)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "DELETE dbo.CHITIETPHIEUXUAT WHERE MAPHIEUXUAT = '" + mapx + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { SQLDatabase.CloseConnection(conn); }
        }
    }
}
