using System;
using System.Collections.Generic;
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

namespace Tra_Sua
{
    /// <summary>
    /// Interaction logic for TrangChu.xaml
    /// </summary>
    public partial class TrangChu : Window
    {
        public TrangChu()
        {
            InitializeComponent();
        }
        private void Mo(Grid panel1, UserControl activeform, UserControl childform)
        {
            if (activeform != null)
            {
                panel1.Children.Remove(activeform); // Xóa giao diện cũ
            }
            activeform = childform; // Gán giao diện mới
            panel1.Children.Add(childform); // Thêm vào Grid
        }
        UserControl activeform = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Mo(chinhchu, activeform, new DatMon());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Mo(chinhchu,activeform, new TrangChuAnh()); 
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Mo(chinhchu, activeform, new NhanVien());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
             Mo(chinhchu,activeform,new DoanhThu());
        }
        private void Button_Seting(object sender, RoutedEventArgs e)
        {
            Seting seting = new Seting();
            seting.Show();
        }
    }
}
