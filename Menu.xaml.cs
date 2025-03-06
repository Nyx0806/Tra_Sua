using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {

        private DatMon datMon;
        public Menu(DatMon datMon)
        {
            InitializeComponent();
            this.datMon = datMon;
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
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenMon = btn.Tag as string; // ✅ Lấy tên món từ Button.Tag
                
                SanPham mon = LayThongTinMon(tenMon);
                if (mon != null)
                {
                    datMon.ThemMon(mon);
                }
            }
        }

        private SanPham LayThongTinMon(string tenMon)
        {
                string query = "SELECT masp, tensp, gia FROM SanPham WHERE tensp = @tenMon";
                List<SanPham> sanPhams = new Modify().SanPhams(query, new SqlParameter("@tenMon", tenMon));

                if (sanPhams != null && sanPhams.Count > 0)
                {
                    return sanPhams[0];
                }
            return null; // Trả về null nếu không tìm thấy món
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Mo(menu, activeform, new TraSua1());
        }
    }
}
