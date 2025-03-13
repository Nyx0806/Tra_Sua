using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Tra_Sua
{

    public partial class ChayBan : UserControl
    {
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();

        public ChayBan()
        {
            InitializeComponent();
            LoadDataFromDatabase();
            this.DataContext = this;
        }
        private void LoadDataFromDatabase()
        {
            string connectionString = "Data Source=ThanhBin;User ID=sa;Password=1234;Encrypt=False;";
            Employees.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT maNV, hoten, chucvu, luong, Email, sdt, TrangThai,gioitinh, ngaysinh FROM NhanVien WHERE chucvu = N'Chay Bàn'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employees.Add(new Employee
                        {
                            EmployeeId = reader["maNV"].ToString(),
                            Name = reader["hoten"].ToString(),
                            Position = reader["chucvu"].ToString(),
                            Salary = reader["luong"] != DBNull.Value ? reader.GetDecimal(reader.GetOrdinal("luong")) : 0,
                            Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "",
                            PhoneNumber = reader["sdt"] != DBNull.Value ? reader["sdt"].ToString() : "",
                            Status = reader["TrangThai"].ToString(),
                            DateOfBirth = reader["ngaysinh"] != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("ngaysinh")) : DateTime.MinValue,
                            Gender = reader["gioiTinh"] != DBNull.Value && reader.GetBoolean(reader.GetOrdinal("gioiTinh")) ? "Nam" : "Nữ"

                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
                }
            }
        }
        
        

    }
}
