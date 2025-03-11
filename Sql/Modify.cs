using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tra_Sua.Model;

namespace Tra_Sua
{
    class Modify
    {
        public Modify()
        {
        }
        SqlCommand sqlCommand; //dùng để truy vấn các cau lệnh sql
        SqlDataReader dataReader; // đọc dữ liệu từ sql
        public List<TaiKhoan> TaiKhoans(string query)
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    taiKhoans.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1)));
                }
                sqlConnection.Close();
            }
            return taiKhoans;
        }
        public List<SanPham> SanPhams(string query, params SqlParameter[] parameters)
        {
            List<SanPham> danhSach = new List<SanPham>();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SanPham sp = new SanPham()
                    {
                        MaSanPham = reader["masp"].ToString(),
                        TenSanPham = reader["tensp"].ToString(),
                        Gia = Convert.ToSingle(reader["gia"]),
                        Loai = reader["loai"].ToString().Trim(),
                        SoLuong = 1 // Mặc định số lượng = 1 khi lấy từ database
                    };
                    danhSach.Add(sp);
                }
                reader.Close();
            }
            return danhSach;
        }
        public void ThucThi(string query)
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery(); // thực thi câu truy vấn

                sqlConnection.Close();
            }
        }
    }
}
