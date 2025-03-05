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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tra_Sua
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            PasswordTextBox.Text = text_MatKhau.Password;
            PasswordTextBox.Visibility = Visibility.Visible;
            text_MatKhau.Visibility = Visibility.Collapsed;
        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            text_MatKhau.Password = PasswordTextBox.Text;
            PasswordTextBox.Visibility = Visibility.Collapsed;
            text_MatKhau.Visibility = Visibility.Visible;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (text_MatKhau.Visibility == Visibility.Visible)
            {
                PasswordTextBox.Text = text_MatKhau.Password;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            MessageBox.Show("Đăng nhập thành công!");
            this.Close();
            trangChu.Show();
        }

        private void Text_TenDangNhap_TextChanged(object sender, TextChangedEventArgs e)
        {
            string tenDangNhap = Text_TenDangNhap.Text;
            string mk = text_MatKhau.Password;
            Clear();
        }
    }
}
