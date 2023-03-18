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
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_StartEmulator(object sender, RoutedEventArgs e)
        {
            MainWindow emul = new MainWindow();
            emul.Show();
        }

        private void Button_Information(object sender, RoutedEventArgs e)
        {
            Information info = new Information();
            info.Show();
        }

        private void Button_Setting(object sender, RoutedEventArgs e)
        {
            Setting set = new Setting();
            set.Show();

        }
    }
}
