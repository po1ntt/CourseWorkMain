using System;
using Kursach.ObjClas;
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





namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для UserInterface.xaml
    /// </summary>
    public partial class UserInterface : Page
    {
        public static string log_info { get; set; }
        public UserInterface(string log1_info = "")
        {
            InitializeComponent();
            log_info = log1_info;
        }
    



        private void Python_click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Sharp_Click(object sender, RoutedEventArgs e)
        {

            ObjClas.Frame.FrameOBJ.Navigate(new SharpTests());
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

     

      

        private void CloseApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Logout(object sender, MouseButtonEventArgs e)
        {


            ObjClas.Frame.FrameOBJ.Navigate(new AuthorizationPage());
        }

        private void Teaching(object sender, MouseButtonEventArgs e)
        {

        }

        private void Profile(object sender, MouseButtonEventArgs e)
        {
            ObjClas.Frame.FrameOBJ.Navigate(new ProfileUser(YourLogin.Text));
            
          
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            YourLogin.Text = log_info;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            YourLogin.Text = log_info;
        }

        private void MoveToXamarin(object sender, RoutedEventArgs e)
        {
            scroll.ScrollToRightEnd();
        }

        private void MoveToWpf(object sender, RoutedEventArgs e)
        {
            scroll.ScrollToLeftEnd();
        }
    }
}
