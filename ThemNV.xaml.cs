using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Tra_Sua
{
    public partial class ThemNV : Window
    {
        public ObservableCollection<Employee> Employees { get; set; }

        public ThemNV(ObservableCollection<Employee> employees)
        {
            InitializeComponent();
            this.Employees = employees;
            this.DataContext = this;
        }

        private void BtnThemNhanVien_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtma.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSDT_Copy1.Text) ||
                cmbChucVu.SelectedItem == null || cbGioitinh.SelectedItem == null || dpNgaySinh.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(txtSDT_Copy1.Text, out decimal luong))
            {
                MessageBox.Show("Lương không hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtSDT.Text, out int sdt))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string connectionString = "Data Source=ThanhBin;User ID=sa;Password=1234;Encrypt=False;";
            string query = "INSERT INTO NhanVien (maNV, hoten, chucvu, luong, Email, sdt, TrangThai, ngaysinh, gioitinh) " +
                           "VALUES (@maNV, @hoten, @chucvu, @luong, @Email, @sdt, @TrangThai, @ngaysinh, @gioitinh)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNV", txtma.Text);
                        cmd.Parameters.AddWithValue("@hoten", txtHoTen.Text);
                        cmd.Parameters.AddWithValue("@chucvu", cmbChucVu.Text);
                        cmd.Parameters.AddWithValue("@luong", luong);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@sdt", sdt);
                        cmd.Parameters.AddWithValue("@TrangThai", "Đang Làm"); // Mặc định
                        cmd.Parameters.AddWithValue("@ngaysinh", dpNgaySinh.SelectedDate);
                        cmd.Parameters.AddWithValue("@gioitinh", cbGioitinh.Text == "Nam" ? 1 : 0);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Thêm nhân viên thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Thêm nhân viên thất bại!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            Close();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
