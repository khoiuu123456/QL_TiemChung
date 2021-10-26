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
    public class DAO_NhanVien
    {
        static SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
        public DataTable loadNhanVien()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT MANV,TENNV,NGAYSINH,GIOITINH,CMND,SDT,DIACHI,NGAYVAOLAM,TENCHUCVU FROM dbo.NHANVIEN,dbo.CHUCVU WHERE dbo.NHANVIEN.MACHUCVU = dbo.CHUCVU.MACHUCVU";
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
