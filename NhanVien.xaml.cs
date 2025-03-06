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
    /// Interaction logic for NhanVien.xaml
    /// </summary>
    public partial class NhanVien : UserControl
    {
        public NhanVien()
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
                        MessageBox.Show("Bạn đã chọn: Pha Chế");
                        break;

                    case "Chạy Bàn":
                        Mo(chayban, activeform, new ChayBan());
                        break;

                    default:
                    
                        break;
                }
            }
        }
    }
}
