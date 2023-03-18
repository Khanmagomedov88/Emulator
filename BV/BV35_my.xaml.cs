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
    /// Логика взаимодействия для BV35_my.xaml
    /// </summary>
    public partial class BV35_my : Page
    {
        int per = 3;
        public BV35_my()
        {
            InitializeComponent();
        }

        private void Click_Per(object sender, RoutedEventArgs e)
        {
            if (per == 0)
            {
                ImageTumbler.Source = new BitmapImage(new Uri("Resources/Переключатель80.png", UriKind.Relative));
                per = 1;
            }
            else if (per == 1)
            {
                ImageTumbler.Source = new BitmapImage(new Uri("Resources/Переключатель65.png", UriKind.Relative));
                per = 2;
            }
            else if (per == 2)
            {
                ImageTumbler.Source = new BitmapImage(new Uri("Resources/Переключатель125.png", UriKind.Relative));

                per = 3;
            }
            else if (per == 3)
            {
                ImageTumbler.Source = new BitmapImage(new Uri("Resources/Переключатель110.png", UriKind.Relative));
                per = 0;
            }
        }
    }
}
