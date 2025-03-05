﻿using System;
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

        Modify modify = new Modify();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            string tenDangNhap = Text_TenDangNhap.Text;
            string matKhau = text_MatKhau.Password;
            if (tenDangNhap.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                Text_TenDangNhap.Focus();
            }
            else if (matKhau.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                text_MatKhau.Focus();
            }
            else
            {
                string query = "SELECT * FROM TaiKhoan WHERE tenTK = '" + tenDangNhap + "' AND matkhau = '" + matKhau + "'";
                if (modify.TaiKhoans(query).Count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    trangChu.Show();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    Text_TenDangNhap.Clear();
                    text_MatKhau.Clear();
                    Text_TenDangNhap.Focus();
                }
            }
        }

        private void Text_TenDangNhap_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        Close();
        }
    }
}
