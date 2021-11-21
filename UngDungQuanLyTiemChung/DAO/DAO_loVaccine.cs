using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DAO_loVaccine
    {
        public SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
        public DataTable taobang(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }
        public bool CheckKey(string sql)
        {
            SqlDataAdapter MyData = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            MyData.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public DataTable returnquery(string query)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            conn.Close();
            return tb;
        }
        public string GetFieldValues(string sql)
        {
            conn.Close();
            conn.Open();
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
        public DataTable loadLoVaccine()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM dbo.LOVACCINE";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch { }
            finally { conn.Close(); }
            return dt;
        }

        public DataTable GetVC()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM dbo.VACCINE";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch { }
            finally { conn.Close(); }
            return dt;
        }
        public DataSet GetLoVC()
        {
            //try 
            //{
            conn.Open();
            DataTable dtLoVC = new DataTable();
            string sqlLoVC = "SELECT * FROM dbo.LOVACCINE";
            SqlCommand cmdLoVC = new SqlCommand(sqlLoVC, conn);
            SqlDataAdapter daLoVC = new SqlDataAdapter(cmdLoVC);
            daLoVC.Fill(dtLoVC);
            DataTable dtVC = new DataTable();
            string sqlVC = "SELECT * FROM dbo.VACCINE";
            SqlCommand cmdVC = new SqlCommand(sqlVC, conn);
            SqlDataAdapter daVC = new SqlDataAdapter(cmdVC);
            daVC.Fill(dtVC);

            DataSet dts = new DataSet();
            dts.Tables.Add(dtLoVC);
            dts.Tables.Add(dtVC);
            dts.Relations.Add(new DataRelation("Danh sách vaccine", dtVC.Columns[0], dtLoVC.Columns[4]));
            //}
            //catch { }
            //finally { conn.Close(); }
            conn.Close();
            return dts;
        }
        public void themLoVaccine(string SOLO, string SOLUONGTON, string SOLIEUTON, string HANSUDUNG, string MAVACCINE, string DVT, string LOAIVACCINE)
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_ThemLoVaccine", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter("@SOLO", SqlDbType.NVarChar);
            par1.Value = SOLO;
            SqlParameter par2 = new SqlParameter("@SOLUONGTON", SqlDbType.NVarChar);
            par2.Value = SOLUONGTON;
            SqlParameter par3 = new SqlParameter("@SOLIEUTON", SqlDbType.NVarChar);
            par3.Value = SOLIEUTON;
            SqlParameter par4 = new SqlParameter("@HANSUDUNG", SqlDbType.NVarChar);
            par4.Value = HANSUDUNG;
            SqlParameter par5 = new SqlParameter("@MAVACCINE", SqlDbType.NVarChar);
            par5.Value = MAVACCINE;
            SqlParameter par6 = new SqlParameter("@DVT", SqlDbType.NVarChar);
            par6.Value = DVT;
            SqlParameter par7 = new SqlParameter("@LOAIVACCINE", SqlDbType.NVarChar);
            par7.Value = LOAIVACCINE;
            cmd.Parameters.Add(par1);
            cmd.Parameters.Add(par2);
            cmd.Parameters.Add(par3);
            cmd.Parameters.Add(par4);
            cmd.Parameters.Add(par5);
            cmd.Parameters.Add(par6);
            cmd.Parameters.Add(par7);
            cmd.ExecuteNonQuery();
            SQLDatabase.CloseConnection(conn);
        }
        public void xoaLoVC(string SOLO)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "DELETE dbo.LOVACCINE WHERE SOLO = '" + SOLO + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public void capNhatLoVC(string SOLUONGTON, string SOLIEUTON, string HANSUDUNG, string MAVACCINE, string DVT, string LOAIVACCINE, string SOLO)
        {
            SQLDatabase.OpenConnection(conn);
            string sql = "UPDATE dbo.LOVACCINE SET SOLUONGTON = " + SOLUONGTON + ",SOLIEUTON = " + SOLIEUTON + ",HANSUDUNG = '" + HANSUDUNG + "',MAVACCINE = '" + MAVACCINE + "',DVT = N'" + DVT + "',LOAIVACCINE=N'" + LOAIVACCINE + "' WHERE SOLO = '" + SOLO + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            SQLDatabase.CloseConnection(conn);
        }

        public bool themThongTinVC(string MAVACCINE,string TENVACCINE, string CHONGCHIDINH, string TACDUNGPHU, string CACHDUNG, string LIEULUONG, string DUNGMOI, string XUATXU, string CHIDINHTIEM)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "INSERT INTO VACCINE VALUES('" + MAVACCINE + "-'+DBO.AUTO_IDVC(),N'"+ TENVACCINE + "',N'" + CHONGCHIDINH + "',N'" + TACDUNGPHU + "',N'" + CACHDUNG + "',N'" + LIEULUONG + "',N'" + DUNGMOI + "',N'" + XUATXU + "',N'" + CHIDINHTIEM + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool xoaThongTinVC(string MAVACCINE)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "DELETE dbo.VACCINE WHERE MAVACCINE = '" + MAVACCINE + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool capNhatThongTinVC(string TENVACCINE, string CHONGCHIDINH, string TACDUNGPHU, string CACHDUNG, string LIEULUONG, string DUNGMOI, string XUATXU, string CHIDINHTIEM, string MAVACCINE)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "UPDATE dbo.VACCINE SET TENVACCINE = N'" + TENVACCINE + "',CHONGCHIDINH = N'" + CHONGCHIDINH + "',TACDUNGPHU = N'" + TACDUNGPHU + "',CACHDUNG = N'" + CACHDUNG + "',LIEULUONG = N'" + LIEULUONG + "',DUNGMOI = N'" + DUNGMOI + "',XUATXU = N'" + XUATXU + "',CHIDINHTIEM = N'" + CHIDINHTIEM + "' WHERE MAVACCINE = '" + MAVACCINE + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
    }
}
