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
    /// Interaction logic for MenuUS.xaml
    /// </summary>
    public partial class MenuUS : UserControl
    {
        private DatMon datMon;
        public MenuUS(DatMon datMon)
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
            this.Visibility = Visibility.Collapsed;
            datMon.QuayLaiManHinhChonBan();
        }

        private void Menu_Trasua_Click(object sender, RoutedEventArgs e)
        {
            Mo(menu, activeform, new TraSua1(datMon));
        }
    }
}
