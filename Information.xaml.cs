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

namespace Emulator
{
    /// <summary>
    /// Логика взаимодействия для Information.xaml
    /// </summary>
    public partial class Information : Window
    {
        public Information()
        {
            InitializeComponent();
            Grid_Information.Content = new Glav();

        }

        private void Click_BV34(object sender, RoutedEventArgs e)
        {
            Grid_Information.Content = new BV34();
        }
        private void Click_BV35(object sender, RoutedEventArgs e)
        {
            Grid_Information.Content = new BV35();
        }
        private void Click_BV37(object sender, RoutedEventArgs e)
        {
            Grid_Information.Content = new BV37();
        }
        private void Button_ClickExit(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
        private void Click_Glav(object sender, RoutedEventArgs e)
        {
            Grid_Information.Content = new Glav();

        }
    }
}
