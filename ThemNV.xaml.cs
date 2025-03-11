using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Tra_Sua.ThuNgan;

namespace Tra_Sua
{
    /// <summary>
    /// Interaction logic for ThemNV.xaml
    /// </summary>
    public partial class ThemNV : Window
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public ThemNV(ObservableCollection<Employee> employees)
        {
            InitializeComponent();
            this.Employees = employees;  // Lưu danh sách nhân viên
            this.DataContext = this;
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedText = selectedItem.Content.ToString();

                // Xử lý khi chọn mục
                switch (selectedText)
                {
                    case "Thu Ngân":
                        break;

                    case "Pha Chế":
                        break;

                    case "Chạy Bàn":
                        break;

                    default:

                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void BtnThemNhanVien_Click(object sender, RoutedEventArgs e)
        {
            // Lấy giá trị từ ComboBox
            string chucVu = ((ComboBoxItem)cmbChucVu.SelectedItem).Content.ToString();

            // Chỉ thêm nếu chức vụ là "Thu Ngân"
            if (chucVu == "Thu Ngân")
            {
                var newEmployee = new Employee
                {
                    Name = txtHoTen.Text,
                    EmployeeId = Guid.NewGuid().ToString(),  // Mã nhân viên tự động
                    DateOfBirth = txtNgaySinh.Text,
                    PhoneNumber = txtSDT.Text,
                    Email = txtEmail.Text,
                    Status = "Đang làm"
                };

                // Thêm vào danh sách
                Employees.Add(newEmployee);
            }

            // Đóng cửa sổ thêm nhân viên
            this.Close();
        }

    }
}
