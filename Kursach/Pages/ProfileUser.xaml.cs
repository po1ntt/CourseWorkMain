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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Kursach.ObjClas;
using Kursach.Model;
using Kursach.ViewModel;



namespace Kursach.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfileUser.xaml
    /// </summary>
    public partial class ProfileUser : Page
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string birthday { get; set; }
        public string surname { get; set; }

        public static string log_info { get; set; }
        public ProfileUser()
        {
           
            InitializeComponent();
            log_info = AuthorizationViewModel.Login;



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
            ObjClas.Frame.FrameOBJ.Navigate(new UserInterface());
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


     
      

        private void UnlockRed(object sender, RoutedEventArgs e)
        {
            Name.IsEnabled = true;
            name = Name.Text;
            Surname.IsEnabled = true;
            surname = Surname.Text;
            EMail.IsEnabled = true;
            email = EMail.Text;
            Phone.IsEnabled = true;
            phone = Phone.Text;
            Birthday.IsEnabled = true;
            birthday = Birthday.Text;
            lockButton.IsEnabled = true;
            unlockbutton.IsEnabled = false;
            savebtn.IsEnabled = true;
        }

        private void lockRed(object sender, RoutedEventArgs e)
        {
            Name.IsEnabled = false;
            Name.Text = name;
            Surname.IsEnabled = false;
            Surname.Text = surname;
            EMail.IsEnabled = false;
            EMail.Text = email;
            Phone.IsEnabled = false;
            Phone.Text = phone;
            Birthday.IsEnabled = false;
            Birthday.Text = birthday;
            lockButton.IsEnabled = false;
            unlockbutton.IsEnabled = true;
            savebtn.IsEnabled = false;
        }

     
    }
}
