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
    /// Логика взаимодействия для SharpTests.xaml
    /// </summary>
    public partial class SharpTests : Page
    {
        public SharpTests()
        {
            InitializeComponent();
        }

        private void Back_click_to_User(object sender, RoutedEventArgs e)
        {
            ObjClas.Frame.FrameOBJ.GoBack();
        }
        private void CloseApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Logout(object sender, MouseButtonEventArgs e)
        {
            ObjClas.Frame.FrameOBJ.Navigate(new AuthorizationPage());
        }

        private void Rewards(object sender, MouseButtonEventArgs e)
        {

        }

        private void Results(object sender, MouseButtonEventArgs e)
        {

        }

        private void Teaching(object sender, MouseButtonEventArgs e)
        {
            ObjClas.Frame.FrameOBJ.Navigate(new UserInterface());
        }

        private void Profile(object sender, MouseButtonEventArgs e)
        {

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


      
    }
}
