using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DAO_NhaCungCap
    {
        static SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
        public DataTable GetNCC()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM dbo.NHACUNGCAP ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch { }
            finally { conn.Close(); }
            return dt;
        }

        public void themNCC(string TENNCC)
        {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_ThemNCC", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@TENNCC", SqlDbType.NVarChar);
                par1.Value = TENNCC;
                cmd.Parameters.Add(par1);
                cmd.ExecuteNonQuery();
                SQLDatabase.CloseConnection(conn);
        }

        public void xoaNCC(string mancc)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "DELETE dbo.NHACUNGCAP WHERE MANCC = '" + mancc + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool capNhatNCC(string TENNCC, string mancc)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "UPDATE dbo.NHACUNGCAP SET TENNCC = N'" + TENNCC + "' WHERE MANCC = '" + mancc + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }

        
    }
}
