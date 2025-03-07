using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tra_Sua.Model;

namespace Tra_Sua
{
    public partial class TraSua1 : UserControl
    {
        private DatMon datMon;
        private string imageFolder = @"F:\C_C#_C++\Visual Studio Code\Tra_Sua\Images\"; // 🔹 Thư mục chứa ảnh

        public TraSua1(DatMon datMon)
        {
            InitializeComponent();
            this.datMon = datMon;
            TaiDanhSachMon(); // 🔹 Tự động tải danh sách món từ database
        }

        private void TaiDanhSachMon()
        {
            string query = "SELECT masp, tensp, gia FROM SanPham";
            List<SanPham> danhSachSanPham = new Modify().SanPhams(query);

            // Xóa danh sách cũ
            panelMon.Children.Clear();

            foreach (var mon in danhSachSanPham)
            {
                string imagePath = TimAnhTuThuMuc(mon.MaSanPham);

                StackPanel stackPanel = new StackPanel { Orientation = Orientation.Vertical, Margin = new Thickness(10) };

                try
                {
                    Image img = new Image
                    {
                        Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute)),
                        Width = 180,
                        Height = 140,
                        Stretch = Stretch.Fill
                    };
                    stackPanel.Children.Add(img);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi tải ảnh {imagePath}: {ex.Message}");
                }

                TextBlock txtTen = new TextBlock
                {
                    Text = mon.TenSanPham,
                    FontSize = 14,
                    FontWeight = FontWeights.Bold,
                    TextAlignment = TextAlignment.Center
                };

                TextBlock txtGia = new TextBlock
                {
                    Text = $"Giá: {mon.Gia:N0} VNĐ",
                    FontSize = 12,
                    Foreground = Brushes.Red,
                    TextAlignment = TextAlignment.Center
                };

                stackPanel.Children.Add(txtTen);
                stackPanel.Children.Add(txtGia);

                Button btn = new Button
                {
                    Content = stackPanel,
                    Width = 202,
                    Height = 220,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F2C193")),
                    BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F2C193"))
                };

                btn.Click += (s, e) => ThemMonVaoDatMon(mon);
                panelMon.Children.Add(btn);
            }
        }

        private string TimAnhTuThuMuc(string maSanPham)
        {
            string imagePath = Path.Combine(imageFolder, $"{maSanPham}.png");

            if (!File.Exists(imagePath))
            {
                string defaultImagePath = Path.Combine(imageFolder, "default.jpg");
                return File.Exists(defaultImagePath) ? defaultImagePath : "";
            }

            return imagePath;
        }

        private void ThemMonVaoDatMon(SanPham mon)
        {
            datMon.ThemMon(mon);
        }
    }
}
