using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Media;
using System.Windows.Threading;

namespace Emulator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow
    {

        int ico_mt2 = 0, extr = 0, by = 0, chet = 0, chetKom = 0, chetNav = 0, chetMech = 0;
        bool a1 = true, a2 = false, mt2_kom = false, mt2_mech = false, mt2_nav = false;
        int per = 3, per2 = 3, numHelp = 0, mt2_komCh = 0, mt2_mechCh = 0, mt2_navCh = 0;

        public MainWindow()
        {
            this.KeyDown += new KeyEventHandler(OKP);
            InitializeComponent();
            Help_Inf.Text = "Перед началом работы, абоненты, участвующие надевают шлемофоны, подогнав их \nразмеры регулировочными ремешками. Особое внимание нужно" +
                " обратить на \nподгонку ларингофонов, которые должны плотно прилегать к гортани.";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt =  new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(0.5)
            };
            dt.Tick += dtTiker;
            dt.Start();
        }

        private void dtTiker(object sender, EventArgs e)
        {
            MT2_Gif();

            if (a2 == true) // Если аппарат включен
            {
                if (extr == 1)
                {
                    if (mt2_kom == true)
                    {
                        IndCom.Fill = new SolidColorBrush(Colors.Green);
                        RectSost.Fill = new SolidColorBrush(Colors.Green);
                        Sost.Content = "Принудительное переключение на внутреннюю связь";

                        RectSost2.Visibility = Visibility.Hidden;
                        Sost2.Content = "";
                    }
                    else
                    {
                        RectSost2.Fill = new SolidColorBrush(Colors.Red);
                        RectSost2.Visibility = Visibility.Visible;
                        Sost2.Content = "Отключены от МТ2";
                    }
                    if (mt2_nav == true)
                    {
                        IndNav.Fill = new SolidColorBrush(Colors.Green);
                        RectSost.Fill = new SolidColorBrush(Colors.Green);
                        Sost.Content = "Принудительное переключение на внутреннюю связь";

                        RectSost2.Visibility = Visibility.Hidden;
                        Sost2.Content = "";
                    }
                    else
                    {
                        RectSost2.Visibility = Visibility.Visible;
                        RectSost2.Fill = new SolidColorBrush(Colors.Red);
                        Sost2.Content = "Отключены от МТ2";
                    }
                    if (mt2_mech == true)
                    {
                        IndMech.Fill = new SolidColorBrush(Colors.Green);
                        RectSost.Fill = new SolidColorBrush(Colors.Green);
                        Sost.Content = "Принудительное переключение на внутреннюю связь";

                        RectSost2.Visibility = Visibility.Hidden;
                        Sost2.Content = "";
                    }
                    else
                    {
                        RectSost2.Fill = new SolidColorBrush(Colors.Red);
                        RectSost2.Visibility = Visibility.Visible;
                        Sost2.Content = "Отключены от МТ2";
                    }
                    if (mt2_kom == false && mt2_mech == false && mt2_nav == false)
                    {
                        RectSost.Fill = new SolidColorBrush(Colors.Red);
                        Sost.Content = "Не удалось принудительно настроить внутреннюю связь. МТ2 не подключены!";

                        RectSost2.Visibility = Visibility.Hidden;
                        Sost2.Content = "";
                        //extr = 0;
                        Lab2.Foreground = Brushes.LightGray;
                    }
                }
                else if (per == 3)
                {
                    if (mt2_kom == true && mt2_mech == true && mt2_nav == true)
                    {
                        RectSost.Fill = new SolidColorBrush(Colors.Orange);
                        Sost.Content = "Все члены экипажа подключены к МТ2";

                        RectSost2.Visibility = Visibility.Hidden;
                        Sost2.Content = "";
                       
                        IndCom.Fill = new SolidColorBrush(Colors.Orange);
                        IndNav.Fill = new SolidColorBrush(Colors.Orange);
                        IndMech.Fill = new SolidColorBrush(Colors.Orange);

                    }
                    else if(mt2_kom == false && mt2_mech == false && mt2_nav == false && extr != 1)
                    {

                        IndCom.Fill = new SolidColorBrush(Colors.Red);
                        IndNav.Fill = new SolidColorBrush(Colors.Red);
                        IndMech.Fill = new SolidColorBrush(Colors.Red);

                        RectSost.Fill = new SolidColorBrush(Colors.Red);
                        Sost.Content = "МТ2 не подключены";

                        RectSost2.Visibility = Visibility.Hidden;
                        Sost2.Content = "";
                    }
                    else
                    {
                        if (mt2_kom == true)
                        {
                            IndCom.Fill = new SolidColorBrush(Colors.Orange);
                            RectSost.Fill = new SolidColorBrush(Colors.Red);
                            Sost.Content = "Отключены от МТ2";

                            RectSost2.Visibility = Visibility.Visible;
                            RectSost2.Fill = new SolidColorBrush(Colors.Orange);
                            Sost2.Content = "Подключены к МТ2";
                        }
                        else
                        {
                            IndCom.Fill = new SolidColorBrush(Colors.Red);
                            RectSost.Fill = new SolidColorBrush(Colors.Red);
                            Sost.Content = "Отключены от МТ2";
                        }
                        if (mt2_mech == true)
                        {
                            IndMech.Fill = new SolidColorBrush(Colors.Orange);
                            RectSost.Fill = new SolidColorBrush(Colors.Red);
                            Sost.Content = "Отключены от МТ2";

                            RectSost2.Visibility = Visibility.Visible;
                            RectSost2.Fill = new SolidColorBrush(Colors.Orange);
                            Sost2.Content = "Подключены к МТ2";
                        }
                        else
                        {
                            IndMech.Fill = new SolidColorBrush(Colors.Red);
                            RectSost.Fill = new SolidColorBrush(Colors.Red);
                            Sost.Content = "Отключены от МТ2";
                        }
                        if (mt2_nav == true)
                        {
                            IndNav.Fill = new SolidColorBrush(Colors.Orange);
                            RectSost.Fill = new SolidColorBrush(Colors.Red);
                            Sost.Content = "Отключены от МТ2";

                            RectSost2.Visibility = Visibility.Visible;
                            RectSost2.Fill = new SolidColorBrush(Colors.Orange);
                            Sost2.Content = "Подключены к МТ2";
                        }
                        else
                        {
                            IndNav.Fill = new SolidColorBrush(Colors.Red);
                            RectSost.Fill = new SolidColorBrush(Colors.Red);
                            Sost.Content = "Отключены от МТ2";
                        }
                    }
                }
                else if (per == 1)
                {
                    if (mt2_kom == true && mt2_mech == true && mt2_nav == true)
                    {
                        IndCom.Fill = new SolidColorBrush(Colors.Green);
                        IndNav.Fill = new SolidColorBrush(Colors.Green);

                        if (a1 == false)
                        {
                            IndMech.Fill = new SolidColorBrush(Colors.Green);
                            RectSost.Fill = new SolidColorBrush(Colors.Green);
                            Sost.Content = "Работа во внутренней сети настроена";

                            RectSost2.Visibility = Visibility.Hidden;
                            Sost2.Content = "";
                        }
                        else
                        {
                            IndMech.Fill = new SolidColorBrush(Colors.Orange);

                            RectSost.Fill = new SolidColorBrush(Colors.Green);
                            Sost.Content = "Работа во внутренней сети настроена";

                            RectSost2.Visibility = Visibility.Visible;
                            RectSost2.Fill = new SolidColorBrush(Colors.Orange);
                            Sost2.Content = "Механик не подключен к внутренней связи";
                        }

                    }
                    if (mt2_kom == false && mt2_mech == false && mt2_nav == false)
                    {
                        IndCom.Fill = new SolidColorBrush(Colors.Red);
                        IndNav.Fill = new SolidColorBrush(Colors.Red);
                        IndMech.Fill = new SolidColorBrush(Colors.Red);

                        RectSost.Fill = new SolidColorBrush(Colors.Red);
                        Sost.Content = "Работа во внутренней связи не настроена. МТ2 не подключены!";

                        RectSost2.Visibility = Visibility.Hidden;
                        Sost2.Content = "";
                    }
                    if (mt2_kom == false && mt2_mech == false && mt2_nav == true)
                    {
                        IndCom.Fill = new SolidColorBrush(Colors.Red);
                        IndNav.Fill = new SolidColorBrush(Colors.Green);
                        IndMech.Fill = new SolidColorBrush(Colors.Red);

                        RectSost.Fill = new SolidColorBrush(Colors.Green);
                        Sost.Content = "Работа во внутренней связи настроена";

                        RectSost2.Visibility = Visibility.Visible;
                        RectSost2.Fill = new SolidColorBrush(Colors.Red);
                        Sost2.Content = "Отключены от МТ2";
                    }
                    if (mt2_kom == false && mt2_mech == true && mt2_nav == false)
                    {
                        IndCom.Fill = new SolidColorBrush(Colors.Red);
                        IndNav.Fill = new SolidColorBrush(Colors.Red);

                        if (a1 == false)
                        {
                            IndMech.Fill = new SolidColorBrush(Colors.Green);
                            RectSost.Fill = new SolidColorBrush(Colors.Green);
                            Sost.Content = "Работа во внутренней сети настроена";

                            RectSost2.Visibility = Visibility.Visible;
                            RectSost2.Fill = new SolidColorBrush(Colors.Red);
                            Sost2.Content = "Отключены от МТ2";
                        }
                        else
                        {
                            IndMech.Fill = new SolidColorBrush(Colors.Orange);

                            RectSost.Fill = new SolidColorBrush(Colors.Red);
                            Sost.Content = "Работа во внутренней сети не настроена";

                            RectSost2.Visibility = Visibility.Visible;
                            RectSost2.Fill = new SolidColorBrush(Colors.Orange);
                            Sost2.Content = "Механик не подключен к внутренней связи";
                        }

                    }
                    if (mt2_kom == false && mt2_mech == true && mt2_nav == true)
                    {
                        IndCom.Fill = new SolidColorBrush(Colors.Red);
                        IndNav.Fill = new SolidColorBrush(Colors.Green);

                        if (a1 == false)
                        {
                            IndMech.Fill = new SolidColorBrush(Colors.Green);
                            RectSost.Fill = new SolidColorBrush(Colors.Green);
                            Sost.Content = "Работа во внутренней сети настроена";

                            RectSost2.Visibility = Visibility.Hidden;
                            Sost2.Content = "";
                        }
                        else
                        {
                            IndMech.Fill = new SolidColorBrush(Colors.Orange);

                            RectSost.Fill = new SolidColorBrush(Colors.Green);
                            Sost.Content = "Работа во внутренней сети настроена";

                            RectSost2.Visibility = Visibility.Visible;
                            RectSost2.Fill = new SolidColorBrush(Colors.Orange);
                            Sost2.Content = "Механик не подключен к внутренней связи";
                        }
                    }
                    if (mt2_kom == true && mt2_mech == false && mt2_nav == false)
                    {
                        IndCom.Fill = new SolidColorBrush(Colors.Green);
                        IndNav.Fill = new SolidColorBrush(Colors.Red);
                        IndMech.Fill = new SolidColorBrush(Colors.Red);

                        RectSost.Fill = new SolidColorBrush(Colors.Green);
                        Sost.Content = "Работа во внутренней связи настроена";

                        RectSost2.Visibility = Visibility.Visible;
                        RectSost2.Fill = new SolidColorBrush(Colors.Red);
                        Sost2.Content = "Отключены от МТ2";
                    }
                    if (mt2_kom == true && mt2_mech == false && mt2_nav == true)
                    {
                        IndCom.Fill = new SolidColorBrush(Colors.Green);
                        IndNav.Fill = new SolidColorBrush(Colors.Green);
                        IndMech.Fill = new SolidColorBrush(Colors.Red);

                        RectSost.Fill = new SolidColorBrush(Colors.Green);
                        Sost.Content = "Работа во внутренней связи настроена";

                        RectSost2.Visibility = Visibility.Visible;
                        RectSost2.Fill = new SolidColorBrush(Colors.Red);
                        Sost2.Content = "Отключены от МТ2";
                    }
                    if (mt2_kom == true && mt2_mech == true && mt2_nav == false)
                    {
                        IndCom.Fill = new SolidColorBrush(Colors.Green);
                        IndNav.Fill = new SolidColorBrush(Colors.Red);

                        if (a1 == false)
                        {
                            IndMech.Fill = new SolidColorBrush(Colors.Green);
                            RectSost.Fill = new SolidColorBrush(Colors.Green);
                            Sost.Content = "Работа во внутренней сети настроена";

                            RectSost2.Visibility = Visibility.Hidden;
                            Sost2.Content = "";
                        }
                        else
                        {
                            IndMech.Fill = new SolidColorBrush(Colors.Orange);

                            RectSost.Fill = new SolidColorBrush(Colors.Green);
                            Sost.Content = "Работа во внутренней сети настроена";

                            RectSost2.Visibility = Visibility.Visible;
                            RectSost2.Fill = new SolidColorBrush(Colors.Orange);
                            Sost2.Content = "Механик не подключен к внутренней связи";
                        }
                    }
                }
                else if (per == 2)
                {
                    if (mt2_kom == true && mt2_mech == true && mt2_nav == true)
                    {
                        RectSost.Fill = new SolidColorBrush(Colors.Green);
                        Sost.Content = "Работа по радиостанции РСт1 настроена";

                        IndCom.Fill = new SolidColorBrush(Colors.Green);
                        IndNav.Fill = new SolidColorBrush(Colors.Green);

                        RectSost2.Visibility = Visibility.Hidden;
                        Sost2.Content = "";

                        if (a1 == true)
                        {
                            RectSost2.Visibility = Visibility.Hidden;
                            Sost2.Content = "";
                            IndMech.Fill = new SolidColorBrush(Colors.Green);
                        }
                        else
                        {
                            IndMech.Fill = new SolidColorBrush(Colors.Orange);
                            RectSost2.Visibility = Visibility.Visible;
                            RectSost2.Fill = new SolidColorBrush(Colors.Orange);
                            Sost2.Content = "Механик не подключен к РСт1";
                        }
                    }
                    if (mt2_kom == false && mt2_mech == false && mt2_nav == false)
                    {
                        RectSost.Fill = new SolidColorBrush(Colors.Red);
                        Sost.Content = "Работа по радиостанции РСт1 не настроена. МТ2 не подключены!";

                        IndCom.Fill = new SolidColorBrush(Colors.Red);
                        IndNav.Fill = new SolidColorBrush(Colors.Red);
                        IndMech.Fill = new SolidColorBrush(Colors.Red);

                        RectSost2.Visibility = Visibility.Hidden;
                        Sost2.Content = "";
                    }
                    if (mt2_kom == false && mt2_mech == false && mt2_nav == true)
                    {
                        IndCom.Fill = new SolidColorBrush(Colors.Red);
                        IndNav.Fill = new SolidColorBrush(Colors.Green);
                        IndMech.Fill = new SolidColorBrush(Colors.Red);

                        RectSost.Fill = new SolidColorBrush(Colors.Green);
                        Sost.Content = "Работа по радиостанции РСт1 настроена";

                        RectSost2.Visibility = Visibility.Visible;
                        RectSost2.Fill = new SolidColorBrush(Colors.Red);
                        Sost2.Content = "Отключены от МТ2";
                    }
                    if (mt2_kom == false && mt2_mech == true && mt2_nav == false)
                    {
                        IndCom.Fill = new SolidColorBrush(Colors.Red);
                        IndNav.Fill = new SolidColorBrush(Colors.Red);
                        if (a1 == true)
                        {
                            RectSost2.Visibility = Visibility.Hidden;
                            Sost2.Content = "";
                            IndMech.Fill = new SolidColorBrush(Colors.Green);

                            RectSost.Fill = new SolidColorBrush(Colors.Green);
                            Sost.Content = "Работа по радиостанции РСт1 настроена";

                            RectSost2.Visibility = Visibility.Visible;
                            RectSost2.Fill = new SolidColorBrush(Colors.Red);
                            Sost2.Content = "Отключены от МТ2";
                        }
                        else
                        {
                            IndMech.Fill = new SolidColorBrush(Colors.Orange);
                            RectSost2.Visibility = Visibility.Visible;
                            RectSost2.Fill = new SolidColorBrush(Colors.Orange);
                            Sost2.Content = "Механик не подключен к РСт1";

                            RectSost.Fill = new SolidColorBrush(Colors.Red);
                            Sost.Content = "Работа по радиостанции РСт1 не настроена";
                        }

                    }
                    if (mt2_kom == false && mt2_mech == true && mt2_nav == true)
                    {
                        IndCom.Fill = new SolidColorBrush(Colors.Red);
                        IndNav.Fill = new SolidColorBrush(Colors.Green);

                        if (a1 == true)
                        {
                            IndMech.Fill = new SolidColorBrush(Colors.Green);
                            RectSost.Fill = new SolidColorBrush(Colors.Green);
                            Sost.Content = "Работа по радиостанции РСт1 настроена";
                        }
                        else
                        {
                            IndMech.Fill = new SolidColorBrush(Colors.Orange);
                            Sost2.Content = "Механик не подключен к РСт1";
                        }

                        RectSost2.Visibility = Visibility.Visible;
                        RectSost2.Fill = new SolidColorBrush(Colors.Red);
                        Sost2.Content = "Отключены от МТ2";
                    }
                    if (mt2_kom == true && mt2_mech == false && mt2_nav == false)
                    {
                        IndCom.Fill = new SolidColorBrush(Colors.Green);
                        IndNav.Fill = new SolidColorBrush(Colors.Red);
                        IndMech.Fill = new SolidColorBrush(Colors.Red);

                        RectSost.Fill = new SolidColorBrush(Colors.Green);
                        Sost.Content = "Работа по радиостанции РСт1 настроена";

                        RectSost2.Visibility = Visibility.Visible;
                        RectSost2.Fill = new SolidColorBrush(Colors.Red);
                        Sost2.Content = "Отключены от МТ2";
                    }
                    if (mt2_kom == true && mt2_mech == false && mt2_nav == true)
                    {
                        IndCom.Fill = new SolidColorBrush(Colors.Green);
                        IndNav.Fill = new SolidColorBrush(Colors.Green);
                        IndMech.Fill = new SolidColorBrush(Colors.Red);

                        RectSost.Fill = new SolidColorBrush(Colors.Green);
                        Sost.Content = "Работа по радиостанции РСт1 настроена";

                        RectSost2.Visibility = Visibility.Visible;
                        RectSost2.Fill = new SolidColorBrush(Colors.Red);
                        Sost2.Content = "Отключены от МТ2";
                    }
                    if (mt2_kom == true && mt2_mech == true && mt2_nav == false)
                    {
                        IndCom.Fill = new SolidColorBrush(Colors.Green);
                        IndNav.Fill = new SolidColorBrush(Colors.Red);

                        if ( a1 == true)
                        {
                            IndMech.Fill = new SolidColorBrush(Colors.Green);
                        }
                        else
                        {
                            Sost2.Content = "Механик не подключен к РСт1";
                        }

                        RectSost.Fill = new SolidColorBrush(Colors.Green);
                        Sost.Content = "Работа по радиостанции РСт1 настроена";

                        RectSost2.Visibility = Visibility.Visible;
                        RectSost2.Fill = new SolidColorBrush(Colors.Red);
                        Sost2.Content = "Отключены от МТ2";
                    }
                }
            }
            else // Если аппарат выключен
            {
                IndCom.Fill = new SolidColorBrush(Colors.Black);
                IndNav.Fill = new SolidColorBrush(Colors.Black);
                IndMech.Fill = new SolidColorBrush(Colors.Black);

                RectSost.Fill = new SolidColorBrush(Colors.Black);
                Sost.Content = "Аппарат выключен";
            }

        }

        private void Click_Per(object sender, RoutedEventArgs e)
        {
            if (per == 0)
            {
                if(numHelp == 3)
                {
                    Help_Inf.Text = "Абонент прибора БВ37 подключается в сеть ВС путем установки " +
                                    "в положение ВС \nпереключателя 'ВОДИТЕЛЬ' на приборе БВ34. ";
                    numHelp = 4;
                }
                ImageTumbler.Source = new BitmapImage(new Uri("Resources/Переключатель30.png", UriKind.Relative));

                per = 1;
                extr = 0;
                Lab2.Foreground = Brushes.LightGray;

            }
            else if (per == 1)
            {
                ImageTumbler.Source = new BitmapImage(new Uri("Resources/Переключатель15.png", UriKind.Relative));

                per = 2;
                extr = 0;
                Lab2.Foreground = Brushes.LightGray;

            }
            else if (per == 2)
            {
                ImageTumbler.Source = new BitmapImage(new Uri("Resources/Переключатель-15.png", UriKind.Relative));

                per = 3;
                extr = 0;
                Lab2.Foreground = Brushes.LightGray;

            }
            else if (per == 3)
            {
                ImageTumbler.Source = new BitmapImage(new Uri("Resources/Переключатель-30.png", UriKind.Relative));

                per = 0;
                extr = 0;
                Lab2.Foreground = Brushes.LightGray;

            }
        }

        private void Click_Per2(object sender, RoutedEventArgs e)
        {
            if (per2 == 0)
            {
                ImageTumbler_1.Source = new BitmapImage(new Uri("Resources/Переключатель30.png", UriKind.Relative));
                per2 = 1;
                extr = 0;

            }
            else if (per2 == 1)
            {
                ImageTumbler_1.Source = new BitmapImage(new Uri("Resources/Переключатель15.png", UriKind.Relative));
                per2 = 2;
                extr = 0;

            }
            else if (per2 == 2)
            {
                ImageTumbler_1.Source = new BitmapImage(new Uri("Resources/Переключатель-15.png", UriKind.Relative));
                extr = 0;
                per2 = 3;
            }
            else if (per2 == 3)
            {
                ImageTumbler_1.Source = new BitmapImage(new Uri("Resources/Переключатель-30.png", UriKind.Relative));
                extr = 0;
                per2 = 0;
            }
        }


        private void Ckick_MT2_Kom(object sender, RoutedEventArgs e)
        {
            if (mt2_kom == false)
            {
                MT2_Kom.Content = "Отключить МТ2";
                IndCom.Fill = new SolidColorBrush(Colors.Orange);
                Sost.Content = "Командир подключился к МТ2";
                RectSost.Fill = new SolidColorBrush(Colors.Orange);

                mt2_kom = true;
                mt2_komCh = 2;

            }
            else if (mt2_kom == true)
            {
                IndCom.Fill = new SolidColorBrush(Colors.Red);
                Sost.Content = "Командир отключился от МТ2";

                RectSost.Fill = new SolidColorBrush(Colors.Orange);
                MT2_Kom.Content = "Подключить МТ2";

                mt2_kom = false;
                mt2_komCh = 1;

            }
        }

        private void Ckick_MT2_Nav(object sender, RoutedEventArgs e)
        {
            if (mt2_nav == false)
            {
                IndNav.Fill = new SolidColorBrush(Colors.Orange);
                Sost.Content = "Наводчик подключился к МТ2";
                RectSost.Fill = new SolidColorBrush(Colors.Orange);
                MT2_Nav.Content = "Отключить МТ2"; 
                mt2_nav = true;
                mt2_navCh = 2;
            }
            else if (mt2_nav == true)
            {
                IndNav.Fill = new SolidColorBrush(Colors.Red);
                Sost.Content = "Наводчик отключился от МТ2";
                RectSost.Fill = new SolidColorBrush(Colors.Orange);
                MT2_Nav.Content = "Подключить МТ2";
                mt2_nav = false;
                mt2_navCh = 1;
            }
        }

        private void Ckick_MT2_Mech(object sender, RoutedEventArgs e)
        {
            if (mt2_mech == false)
            {
                IndMech.Fill = new SolidColorBrush(Colors.Orange);
                Sost.Content = "Механик подключился к МТ2";
                RectSost.Fill = new SolidColorBrush(Colors.Orange);

                MT2_Mech.Content = "Отключить МТ2";

                mt2_mech = true;
                mt2_mechCh = 2;

            }
            else if (mt2_mech == true)
            {
                IndMech.Fill = new SolidColorBrush(Colors.Red);
                Sost.Content = "Механик отключился от МТ2";

                RectSost.Fill = new SolidColorBrush(Colors.Orange);
                MT2_Mech.Content = "Подключить МТ2";
                mt2_mech = false;
                mt2_mechCh = 1;

                RectSost2.Visibility = Visibility.Visible;
                RectSost2.Fill = new SolidColorBrush(Colors.Red);
                Sost2.Content = "Отключены от МТ2";
            }
        }

        private void Click_By (object sender, RoutedEventArgs e)
        {
            if (by == 0)
            {
                Khanm.Visibility = Visibility.Visible;
                by = 1;
            }
            else
            {
                Khanm.Visibility = Visibility.Hidden;
                by = 0;
            }
        }

        private void Click_Kom(object sender, RoutedEventArgs e)
        {
            VisKom();
            InvisMech();
            InvisNavod();
        }
        private void Click_Mech(object sender, RoutedEventArgs e)
        {
            VisMech();
            InvisNavod();
            InvisKom();
        }
        private void Click_Nav(object sender, RoutedEventArgs e)
        {
            VisNavod();
            InvisMech();
            InvisKom();
        }
        private void But_Dalee_Click(object sender, RoutedEventArgs e)
        {
            if (numHelp == 0)
            {
                Help_Inf.Text = "Шнуры шлемофонов подключаются к приборам МТ2, которые, в свою очредь, \nдолжны быть соеденены с приборами " +
                                "абонентов или с проходными разъемами.\n" +
                                "Для этого нажмите кнопку 'Q'.";
                numHelp = 1;
            }
            else if (numHelp == 1)
            {
                Help_Inf.Text = "После выполнения подготовительных операций, перечисленных ранее, " +
                                "на \nаппаратуру подают питание, установив переключатель БВ-откл на " +
                                "приборе БВ-34 \nв положение БС. ";
                But_Dalee.Visibility = Visibility.Hidden;
                numHelp = 2;
            }
            
        }

        private void Click_Call(object sender, RoutedEventArgs e)
        {
            if(extr == 0 && a2 == true)
            {
                Lab2.Foreground = Brushes.LimeGreen;

                extr = 1;
                RectSost.Fill = new SolidColorBrush(Colors.Green);
                Sost.Content = "Принудительное переключение на внутреннюю связь";

            }
            else
            {
                Lab2.Foreground = Brushes.LightGray;
                extr = 0;
            }
        }

        private void Click_Prav(object sender, RoutedEventArgs e)
        {
            if (numHelp == 2)
            {
                Help_Inf.Text = "Для выхода во внютреннюю связь абоненты приборов БВ34, БВ35, БВ37 \n" +
                                "устанавливают переключатели рода работ на своих приборах в положение ВС";

                numHelp = 3;
            }
            if (a2 == false)
            {
                ImageTumblerOnOff.Source = new BitmapImage(new Uri("Resources/On.png", UriKind.Relative));
                a2 = true;
                extr = 0;
                Lab2.Foreground = Brushes.LightGray;

                Stream str = Properties.Resources.Rec;
                SoundPlayer snd = new SoundPlayer(str);
                snd.Play();
            }
            else
            {
                ImageTumblerOnOff.Source = new BitmapImage(new Uri("Resources/Off.png", UriKind.Relative));
                a2 = false;
                extr = 0;
                Lab2.Foreground = Brushes.LightGray;

            }
        }

        private void Click_Lev(object sender, RoutedEventArgs e)
        {
            if (a1 == false)
            {

                ImageTumblerLev.Source = new BitmapImage(new Uri("Resources/On.png", UriKind.Relative));
                a1 = true;
                extr = 0;
                Lab2.Foreground = Brushes.LightGray;

            }
            else
            {
                ImageTumblerLev.Source = new BitmapImage(new Uri("Resources/Off.png", UriKind.Relative));
                a1 = false;
                extr = 0;
                Lab2.Foreground = Brushes.LightGray;

            }

            if (numHelp == 4)
            {
                Help_Inf.Text = "Работа в сети внутренней связи настроенна!";
            }
        }

        private void OKP(object sender, KeyEventArgs e)
        {

            switch (e.Key.ToString())
            {
                case "Q":
                    if (ico_mt2 == 0)
                    {
                        MT2_Kom.Visibility = Visibility.Visible;
                        MT2_Nav.Visibility = Visibility.Visible;
                        MT2_Mech.Visibility = Visibility.Visible;
                        ico_mt2 = 1;
                    }
                    else if (ico_mt2 == 1)
                    {
                        MT2_Kom.Visibility = Visibility.Hidden;
                        MT2_Nav.Visibility = Visibility.Hidden;
                        MT2_Mech.Visibility = Visibility.Hidden;
                        ico_mt2 = 0;
                    }
                    break;

                case "Escape":
                    if (MessageBox.Show("Вы уверены что хотите выйти из эмулятора?",
                    "Выход из эмулятора",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        this.Close();
                    }
                    break;

                case "Z":

                    if(But_ComR.Visibility == Visibility.Hidden)
                    {
                        But_ComR.Visibility = Visibility.Visible;
                        But_NavR.Visibility = Visibility.Visible;
                        But_MehR.Visibility = Visibility.Visible;

                        MessageBox.Show("Вы переключили режим на базовый", "Переключение режима", MessageBoxButton.OK, MessageBoxImage.Information);
                        
                    }
                    else
                    {
                        But_ComR.Visibility = Visibility.Hidden;
                        But_NavR.Visibility = Visibility.Hidden;
                        But_MehR.Visibility = Visibility.Hidden;

                        MessageBox.Show("Вы переключили режим на реалистичный", "Переключение режима", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    break;
            }

        }
        public void VisKom() {
            Rect1.Visibility = Visibility.Visible;
            Rect2.Visibility = Visibility.Visible;
            Rect3.Visibility = Visibility.Visible;
            Lab1.Visibility = Visibility.Visible;
            Lab2.Visibility = Visibility.Visible;
            Lab3.Visibility = Visibility.Visible;
            Lab4.Visibility = Visibility.Visible;
            Lab5.Visibility = Visibility.Visible;
            Lab6.Visibility = Visibility.Visible;
            Lab7.Visibility = Visibility.Visible;
            Lab8.Visibility = Visibility.Visible;
            Lab9.Visibility = Visibility.Visible;
            Lab10.Visibility = Visibility.Visible;
            Lab11.Visibility = Visibility.Visible;
            Lab12.Visibility = Visibility.Visible;
            Lab13.Visibility = Visibility.Visible;
            Lab14.Visibility = Visibility.Visible;
            Lab15.Visibility = Visibility.Visible;
            Lab16.Visibility = Visibility.Visible;
            Lab17.Visibility = Visibility.Visible;
            Lab18.Visibility = Visibility.Visible;
            Lab19.Visibility = Visibility.Visible;


            TumblerRST.Visibility = Visibility.Visible;
            btnEx.Visibility = Visibility.Visible;
            TumblerR.Visibility = Visibility.Visible;
            TumblerValue.Visibility = Visibility.Visible;
            TumblerOnOff.Visibility = Visibility.Visible;


            Sh1.Visibility = Visibility.Visible;
            Sh2.Visibility = Visibility.Visible;
            Sh3.Visibility = Visibility.Visible;
            Sh4.Visibility = Visibility.Visible;
            Sh5.Visibility = Visibility.Visible;
            Sh6.Visibility = Visibility.Visible;
            Sh7.Visibility = Visibility.Visible;
            Sh8.Visibility = Visibility.Visible;

            bvNext.Content = "БВ35";
        }
        public void InvisKom()
        {
            Rect1.Visibility = Visibility.Collapsed;
            Rect2.Visibility = Visibility.Collapsed;
            Rect3.Visibility = Visibility.Collapsed;
            Lab1.Visibility = Visibility.Collapsed;
            Lab2.Visibility = Visibility.Collapsed;
            Lab3.Visibility = Visibility.Collapsed;
            Lab4.Visibility = Visibility.Collapsed;
            Lab5.Visibility = Visibility.Collapsed;
            Lab6.Visibility = Visibility.Collapsed;
            Lab7.Visibility = Visibility.Collapsed;
            Lab8.Visibility = Visibility.Collapsed;
            Lab9.Visibility = Visibility.Collapsed;
            Lab10.Visibility = Visibility.Collapsed;
            Lab11.Visibility = Visibility.Collapsed;
            Lab12.Visibility = Visibility.Collapsed;
            Lab13.Visibility = Visibility.Collapsed;
            Lab14.Visibility = Visibility.Collapsed;
            Lab15.Visibility = Visibility.Collapsed;
            Lab16.Visibility = Visibility.Collapsed;
            Lab17.Visibility = Visibility.Collapsed;
            Lab18.Visibility = Visibility.Collapsed;
            Lab19.Visibility = Visibility.Collapsed;


            TumblerRST.Visibility = Visibility.Collapsed;
            btnEx.Visibility = Visibility.Collapsed;
            TumblerR.Visibility = Visibility.Collapsed;
            TumblerValue.Visibility = Visibility.Collapsed;
            TumblerOnOff.Visibility = Visibility.Collapsed;

            Sh1.Visibility = Visibility.Collapsed;
            Sh2.Visibility = Visibility.Collapsed;
            Sh3.Visibility = Visibility.Collapsed;
            Sh4.Visibility = Visibility.Collapsed;
            Sh5.Visibility = Visibility.Collapsed;
            Sh6.Visibility = Visibility.Collapsed;
            Sh7.Visibility = Visibility.Collapsed;
            Sh8.Visibility = Visibility.Collapsed;

            bvNext.Content = "БВ34";
        }
        public void VisNavod()
        {
            Rect0_1.Visibility = Visibility.Visible;
            Rect1_1.Visibility = Visibility.Visible;
            Rect2_1.Visibility = Visibility.Visible;
            Lab1_1.Visibility = Visibility.Visible;
            Lab2_1.Visibility = Visibility.Visible;
            Lab3_1.Visibility = Visibility.Visible;
            Lab4_1.Visibility = Visibility.Visible;

            Sh1_1.Visibility = Visibility.Visible;
            Sh2_1.Visibility = Visibility.Visible;
            Sh3_1.Visibility = Visibility.Visible;
            Sh4_1.Visibility = Visibility.Visible;

            TumblerR_1.Visibility = Visibility.Visible;

        }
        public void InvisNavod()
        {
            Rect0_1.Visibility = Visibility.Collapsed;
            Rect1_1.Visibility = Visibility.Collapsed;
            Rect2_1.Visibility = Visibility.Collapsed;

            Lab1_1.Visibility = Visibility.Collapsed;
            Lab2_1.Visibility = Visibility.Collapsed;
            Lab3_1.Visibility = Visibility.Collapsed;
            Lab4_1.Visibility = Visibility.Collapsed;

            Sh1_1.Visibility = Visibility.Collapsed;
            Sh2_1.Visibility = Visibility.Collapsed;
            Sh3_1.Visibility = Visibility.Collapsed;
            Sh4_1.Visibility = Visibility.Collapsed;

            TumblerR_1.Visibility = Visibility.Collapsed;
        }
        public void VisMech()
        {

        }
        public void InvisMech()
        {

        }

        public void MT2_Gif()
        {
            chet++;

            if (mt2_navCh == 2) // Анимация наводчика
            {
                if (chetNav == 0)
                {
                    chetNav = chet + 15;
                }
                if (chet < chetNav)
                {
                    Image_NavGifN.Play();
                    But_NavGifN.Visibility = Visibility.Visible;
                    MT2_Nav.IsEnabled = false;
                }
                else
                {
                    Image_NavGifN.Stop();
                    Image_Nav.Source = new BitmapImage(new Uri("Resources/gif/Gsecond.png", UriKind.Relative));
                    But_NavGifN.Visibility = Visibility.Hidden;
                    mt2_navCh = 0;
                    chetNav = 0;
                    MT2_Nav.IsEnabled = true;
                }
            }
            else if (mt2_navCh == 1)
            {
                if (chetNav == 0)
                {
                    chetNav = chet + 11;
                }
                if (chet < chetNav)
                {
                    Image_NavGifS.Play();
                    But_NavGifS.Visibility = Visibility.Visible;
                    MT2_Nav.IsEnabled = false;
                }
                else
                {
                    Image_NavGifS.Stop();
                    Image_Nav.Source = new BitmapImage(new Uri("Resources/gif/Gfirst.png", UriKind.Relative));
                    But_NavGifS.Visibility = Visibility.Hidden;
                    mt2_navCh = 0;
                    chetNav = 0;
                    MT2_Nav.IsEnabled = true;
                }
            }
            /////////////////////////////////// ---- 1000 строк кода ---- УРА УРА УРА ---- /////////////////////////////////////
            
            if (mt2_komCh == 2) // Анимация командира
            {
                if (chetKom == 0)
                {
                    chetKom = chet + 14;
                }
                if (chet < chetKom)
                {
                    Image_ComGifN.Play();
                    But_ComGifN.Visibility = Visibility.Visible;
                    MT2_Kom.IsEnabled = false;
                }
                else
                {
                    Image_ComGifN.Stop();
                    Image_Com.Source = new BitmapImage(new Uri("Resources/gif/Khsecond.png", UriKind.Relative));
                    But_ComGifN.Visibility = Visibility.Hidden;
                    mt2_komCh = 0;
                    chetKom = 0;
                    MT2_Kom.IsEnabled = true;
                }
            }
            else if (mt2_komCh == 1)
            {
                if (chetKom == 0)
                {
                    chetKom = chet + 11;
                }
                if (chet < chetKom)
                {
                    Image_ComGifS.Play();
                    But_ComGifS.Visibility = Visibility.Visible;
                    MT2_Kom.IsEnabled = false;
                }
                else
                {
                    Image_ComGifS.Stop();
                    Image_Com.Source = new BitmapImage(new Uri("Resources/gif/Khfirst.png", UriKind.Relative));
                    But_ComGifS.Visibility = Visibility.Hidden;
                    mt2_komCh = 0;
                    chetKom = 0;
                    MT2_Kom.IsEnabled = true;
                }
            }

            if (mt2_mechCh == 2) // Анимация механика
            {
                if (chetMech == 0)
                {
                    chetMech = chet + 18;
                }
                if (chet < chetMech)
                {
                    Image_MechGifN.Play();
                    But_MechGifN.Visibility = Visibility.Visible;
                    MT2_Mech.IsEnabled = false;
                }
                else
                {
                    Image_MechGifN.Stop();
                    Image_Meh.Source = new BitmapImage(new Uri("Resources/gif/Dsecond.png", UriKind.Relative));
                    But_MechGifN.Visibility = Visibility.Hidden;
                    mt2_mechCh = 0;
                    chetMech = 0;
                    MT2_Mech.IsEnabled = true;
                }
            }
            else if (mt2_mechCh == 1)
            {
                if (chetMech == 0)
                {
                    chetMech = chet + 13;
                }
                if (chet < chetMech)
                {
                    Image_MechGifS.Play();
                    But_MechGifS.Visibility = Visibility.Visible;
                    MT2_Mech.IsEnabled = false;
                }
                else
                {
                    Image_MechGifS.Stop();
                    Image_Meh.Source = new BitmapImage(new Uri("Resources/gif/Dfirst.png", UriKind.Relative));
                    But_MechGifS.Visibility = Visibility.Hidden;
                    mt2_mechCh = 0;
                    chetMech = 0;
                    MT2_Mech.IsEnabled = true;
                }
            }
        }
    }
}
