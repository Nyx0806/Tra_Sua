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
using Tra_Sua.Model;

namespace Tra_Sua
{
    /// <summary>
    /// Interaction logic for DatMon.xaml
    /// </summary>
    public partial class DatMon : UserControl
    {
        public ObservableCollection<SanPham> DanhSachMon { get; set; } = new ObservableCollection<SanPham>();

        public DatMon()
        {
            InitializeComponent();
            dataGridMon.ItemsSource = DanhSachMon; // Đảm bảo DataGrid nhận danh sách
        }

        public void ThemMon(SanPham mon)
        {
            if (mon != null)
            {
                var monDaTonTai = DanhSachMon.FirstOrDefault(x => x.MaSanPham == mon.MaSanPham);

                if (monDaTonTai != null)
                {
                    monDaTonTai.SoLuong++;
                }
                else
                {
                    mon.SoLuong = 1;
                    DanhSachMon.Add(mon);
                }
                dataGridMon.ItemsSource = null; // Reset binding
                dataGridMon.ItemsSource = DanhSachMon; // Gán lại danh sách
                dataGridMon.Items.Refresh();

                CapNhatTongTien();
            }
        }



        private void CapNhatTongTien()
        {
            float tongTien = DanhSachMon.Sum(mon => mon.ThanhTien); // Tính tổng tất cả món
            lblTongTien.Text = $"Tổng tiền: {tongTien:N0} VNĐ";
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
            Mo(dat, activeform, new Menu(this));
        }
    }
}
