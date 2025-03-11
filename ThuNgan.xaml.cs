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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tra_Sua
{
    /// <summary>
    /// Interaction logic for ThuNgan.xaml
    /// </summary>
    public partial class ThuNgan : UserControl
    {
         public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        public class Employee
        {
            public string Name { get; set; }
            public string EmployeeId { get; set; }
            public string DateOfBirth { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Status { get; set; }  

        }
        public ThuNgan()
        {
            InitializeComponent();
            Employees = new ObservableCollection<Employee>
        {
                new Employee { EmployeeId = "123", Name = "Nguyễn Văn A", DateOfBirth = "01/01/1990", PhoneNumber = "0987654321", Email = "nguyenvana@gmail.com", Status = "Đang làm" },
                new Employee { EmployeeId = "456", Name = "Trần Văn B", DateOfBirth = "05/06/1995", PhoneNumber = "0976543210", Email = "tranvanb@gmail.com", Status = "Đã nghỉ" }
        };
            this.DataContext = this;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XoaNV xoaNV = new XoaNV();
            xoaNV.Show();
        }
    }
}
