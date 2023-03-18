
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

namespace Emulator
{
    /// <summary>
    /// Логика взаимодействия для Glav.xaml
    /// </summary>
    public partial class Glav : Page
    {
        public Glav()
        {
            InitializeComponent();
        }

        private void Click_BV34(object sender, RoutedEventArgs e)
        {
            Grid_Information.Content = new BV34();
        }
        private void Click_BV35(object sender, RoutedEventArgs e)
        {
            //Grid_Information.Content = new BV35();
        }
        private void Click_BV37(object sender, RoutedEventArgs e)
        {
            Grid_Information.Content = new BV34();
        }
        private void Button_ClickExit(object sender, RoutedEventArgs e)
        {
            Grid_Information.Content = new Glav();

        }
    }
}
