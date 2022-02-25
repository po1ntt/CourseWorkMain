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
using Kursach.ObjClas;
using Kursach.Model;

namespace Kursach.Pages
{
    /// <summary>
    /// Логика взаимодействия для KuratorInteface.xaml
    /// </summary>
    public partial class KuratorInteface : Page
    {
        public static string log_info { get; set; }
        public KuratorInteface(string log1_info = "")
        {
            InitializeComponent();
            log_info = log1_info;
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {

            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }
        private void Profile(object sender, MouseButtonEventArgs e)
        {
            ObjClas.Frame.FrameOBJ.Navigate(new ProfileUser(YourLogin.Text));
        }
        private void CloseApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Logout(object sender, MouseButtonEventArgs e)
        {
            ObjClas.Frame.FrameOBJ.Navigate(new AuthorizationPage());
        }
    }
}
