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
        public DataTable GetCTKN(string makn)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM dbo.CHITIETKHANGNGUYEN where MAKHANGNGUYEN like'%" + makn + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch { }
            finally { conn.Close(); }
            return dt;
        }

        public DataSet GetKN()
        {
            conn.Open();
            DataTable dtKN = new DataTable();
            string sqlKN = "SELECT * FROM dbo.KHANGNGUYEN";
            SqlCommand cmdKN = new SqlCommand(sqlKN, conn);
            SqlDataAdapter daKN = new SqlDataAdapter(cmdKN);
            daKN.Fill(dtKN);
            DataTable dtCT = new DataTable();
            string sqlCT = "SELECT * FROM dbo.CHITIETKHANGNGUYEN";
            SqlCommand cmdCT = new SqlCommand(sqlCT, conn);
            SqlDataAdapter daCT = new SqlDataAdapter(cmdCT);
            daCT.Fill(dtCT);

            DataSet dts = new DataSet();
            dts.Tables.Add(dtKN);
            dts.Tables.Add(dtCT);
            dts.Relations.Add(new DataRelation("Danh sách vaccine", dtKN.Columns[0], dtCT.Columns[0]));
            conn.Close();
            return dts;
            
        }
        public void themKhangNguyen(string loaibenh)
        {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_ThemKhangNguyen", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@LOAIBENH", SqlDbType.NVarChar);
                par1.Value = loaibenh;
                cmd.Parameters.Add(par1);
                cmd.ExecuteNonQuery();
                SQLDatabase.CloseConnection(conn);
        }

        public void themCTKN(string makn, string mavc)
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_ThemCTKN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter("@MAKHANGNGUYEN", SqlDbType.NVarChar);
            par1.Value = makn;
            SqlParameter par2 = new SqlParameter("@MAVACCINE", SqlDbType.NVarChar);
            par2.Value = mavc;
            cmd.Parameters.Add(par1);
            cmd.Parameters.Add(par2);
            cmd.ExecuteNonQuery();
            SQLDatabase.CloseConnection(conn);
        }
        public void xoaKhangNguyen(string makn)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "DELETE dbo.KHANGNGUYEN WHERE MAKHANGNGUYEN = '" + makn + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public void HuyCTKN(string makn, string mavc)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "DELETE dbo.CHITIETKHANGNGUYEN WHERE MAKHANGNGUYEN = '" + makn + "' and mavaccine='" + mavc + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public void XoaCTKN(string makn)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "DELETE dbo.CHITIETKHANGNGUYEN WHERE MAKHANGNGUYEN = '" + makn + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool capNhatKhangNguyen(string loaibenh, string makn)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "UPDATE dbo.KHANGNGUYEN SET LOAIBENH = N'" + loaibenh + "' WHERE MAKHANGNGUYEN = '" + makn + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }

        
    }
}
