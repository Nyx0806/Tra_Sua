using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Tra_Sua.Model;

namespace Tra_Sua
{
    public partial class DatMon : UserControl
    {
        public ObservableCollection<SanPham> DanhSachMon { get; set; }
        private Dictionary<Button, ObservableCollection<SanPham>> banHoaDon = new Dictionary<Button, ObservableCollection<SanPham>>();
        private Button banDangChon = null; // Lưu bàn đang chọn

        public DatMon()
        {
            InitializeComponent();
            DanhSachMon = new ObservableCollection<SanPham>();
            dataGridMon.ItemsSource = DanhSachMon;
            KhoiTaoBanAn();
        }

        private void KhoiTaoBanAn()
        {
            for (int i = 1; i <= 16; i++)
            {
                Button btnBan = new Button
                {
                    Content = $"Bàn {i}",
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D49A6A")),
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    Width = 100,
                    Height = 80,
                    Margin = new Thickness(5)
                };

                btnBan.Click += (s, e) => ChonBan(btnBan);
                gridBanAn.Children.Add(btnBan);
                banHoaDon[btnBan] = new ObservableCollection<SanPham>(); // Mỗi bàn có 1 danh sách hóa đơn riêng
            }
        }

        private void ChonBan(Button btnBan)
        {
            if (banDangChon != null)
            {
                banDangChon.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D49A6A"));
            }

            // Cập nhật bàn đang chọn và đổi màu
            banDangChon = btnBan;
            banDangChon.Background = Brushes.LightGreen;

            // Gán danh sách món ăn của bàn vào DataGrid
            DanhSachMon.Clear();
            foreach (var item in banHoaDon[btnBan])
            {
                DanhSachMon.Add(item);
            }
            CapNhatTongTien();

            // **Mở form menu**
            MoFormMenu();
        }


        public void ThemMon(SanPham mon)
        {
            if (mon != null && banDangChon != null)
            {
                var danhSachCuaBan = banHoaDon[banDangChon];

                var monDaTonTai = danhSachCuaBan.FirstOrDefault(x => x.MaSanPham == mon.MaSanPham);
                if (monDaTonTai != null)
                {
                    monDaTonTai.SoLuong++;
                }
                else
                {
                    mon.SoLuong = 1;
                    danhSachCuaBan.Add(mon);
                }

                // Cập nhật lại danh sách hiển thị
                DanhSachMon.Clear();
                foreach (var item in danhSachCuaBan)
                {
                    DanhSachMon.Add(item);
                }

                dataGridMon.Items.Refresh();
                CapNhatTongTien();
            }
        }

        private void CapNhatTongTien()
        {
            float tongTien = DanhSachMon.Sum(mon => mon.ThanhTien);
            lblTongTien.Text = $"Tổng tiền: {tongTien:N0} VNĐ";
        }

        private void InDon_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("In hóa đơn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            HoaDon hoaDon = new HoaDon();
            hoaDon.Show();
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
        private void MoFormMenu()
        {
            Mo(gridMenu, activeform, new MenuUS(this));
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender == txtTenKhach) lblTenKhach.Visibility = Visibility.Collapsed;
            if (sender == txtSDT) lblSDT.Visibility = Visibility.Collapsed;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender == txtTenKhach && string.IsNullOrWhiteSpace(txtTenKhach.Text))
                lblTenKhach.Visibility = Visibility.Visible;

            if (sender == txtSDT && string.IsNullOrWhiteSpace(txtSDT.Text))
                lblSDT.Visibility = Visibility.Visible;
        }

    }
}
