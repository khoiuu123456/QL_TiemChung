using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DAO_NhapVaccine
    {
        static SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
        public DataTable GetCTNHAPVC(string mapn)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT SOLO,DVT,SOLUONG,LUONGNGUOITIEM,CHITHINHIETDO,CHITHIDONGBANG,DUNGTICH FROM dbo.CHITIETPHIEUNHAP where MAPHIEUNHAP like'%" + mapn + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch { }
            finally { conn.Close(); }
            return dt;
        }

        public void themPhieuNhap(string MANV, string MANCC, string NGAYNHAP, string GHICHU)
        {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_ThemPhieuNhap", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@MANV", SqlDbType.NVarChar);
                par1.Value = MANV;
                SqlParameter par2 = new SqlParameter("@MANCC", SqlDbType.NVarChar);
                par2.Value = MANCC;
                SqlParameter par3 = new SqlParameter("@NGAYNHAP", SqlDbType.NVarChar);
                par3.Value = NGAYNHAP;
                SqlParameter par4 = new SqlParameter("@GHICHU", SqlDbType.NVarChar);
                par4.Value = GHICHU;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                SQLDatabase.CloseConnection(conn);
        }
        public void themCTNHAP(string MAPHIEUNHAP, string SOLO, string DVT, string SOLUONG, string LUONGNGUOITIEM, string CHITHINHIETDO, string CHITHIDONGBANG, string DUNGTICH)
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_ThemCTNhap", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter("@MAPHIEUNHAP", SqlDbType.NVarChar);
            par1.Value = MAPHIEUNHAP;
            SqlParameter par2 = new SqlParameter("@SOLO", SqlDbType.NVarChar);
            par2.Value = SOLO;
            SqlParameter par3 = new SqlParameter("@DVT", SqlDbType.NVarChar);
            par3.Value = DVT;
            SqlParameter par4 = new SqlParameter("@SOLUONG", SqlDbType.NVarChar);
            par4.Value = SOLUONG;
            SqlParameter par5 = new SqlParameter("@LUONGNGUOITIEM", SqlDbType.NVarChar);
            par5.Value = LUONGNGUOITIEM;
            SqlParameter par6 = new SqlParameter("@CHITHINHIETDO", SqlDbType.NVarChar);
            par6.Value = CHITHINHIETDO;
            SqlParameter par7 = new SqlParameter("@CHITHIDONGBANG", SqlDbType.NVarChar);
            par7.Value = CHITHIDONGBANG;
            SqlParameter par8 = new SqlParameter("@DUNGTICH", SqlDbType.NVarChar);
            par8.Value = DUNGTICH;
            cmd.Parameters.Add(par1);
            cmd.Parameters.Add(par2);
            cmd.Parameters.Add(par3);
            cmd.Parameters.Add(par4);
            cmd.Parameters.Add(par5);
            cmd.Parameters.Add(par6);
            cmd.Parameters.Add(par7);
            cmd.Parameters.Add(par8);
            cmd.ExecuteNonQuery();
            SQLDatabase.CloseConnection(conn);
        }
        public bool capNhatHSDLoVC(string hsd, string solo)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "UPDATE dbo.LOVACCINE SET HANSUDUNG = '" + hsd + "' WHERE SOLO = '" + solo + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public void XoaPhieuNhap(string mapn)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "DELETE dbo.PHIEUNHAP WHERE MAPHIEUNHAP = '" + mapn + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public void XoaCTNhap(string mapn)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "DELETE dbo.CHITIETPHIEUNHAP WHERE MAPHIEUNHAP = '" + mapn + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { SQLDatabase.CloseConnection(conn); }
        }
    }
}
