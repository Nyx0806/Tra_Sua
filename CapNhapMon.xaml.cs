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
    /// Interaction logic for CapNhapMon.xaml
    /// </summary>
    public partial class CapNhapMon : UserControl
    {
        public CapNhapMon()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThemMon themMon = new ThemMon();
            themMon.Show();
        }
    }
}
