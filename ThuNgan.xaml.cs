using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Tra_Sua
{
    public partial class ThuNgan : UserControl
    {
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();

        public ThuNgan()
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
                    string query = "SELECT maNV, hoten, chucvu, luong, Email, sdt, TrangThai, gioitinh, ngaysinh FROM NhanVien WHERE chucvu = N'Thu Ngân'";
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



        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.DataContext is Employee employee)
            {
                string newStatus = comboBox.SelectedItem.ToString();

                // Cập nhật trạng thái mới trong danh sách Employees
                employee.Status = newStatus;

                // Gọi hàm cập nhật trạng thái vào database
                UpdateEmployeeStatus(employee.EmployeeId, newStatus);
            }
        }
        private void UpdateEmployeeStatus(string employeeId, string newStatus)
        {
            string connectionString = "Data Source=ThanhBin;Persist Security Info=True;User ID=sa;Password=******;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE NhanVien SET TrangThai = @Status WHERE maNV = @EmployeeId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", newStatus);
                        command.Parameters.AddWithValue("@EmployeeId", employeeId);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật trạng thái: " + ex.Message);
                }
            }
        }

    }
}
