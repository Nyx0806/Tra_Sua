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
    /// Interaction logic for ThemMon.xaml
    /// </summary>
    public partial class ThemMon : Window
    {
        public ThemMon()
        {
            InitializeComponent();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedText = selectedItem.Content.ToString();

                // Xử lý khi chọn mục
                switch (selectedText)
                {
                    case "Ăn Vặt":
                        break;

                    case "Trà Sữa":
                        break;

                    default:

                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
