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
using Kursach.ViewModel;
using Kursach.Model;
using Kursach.services;
using Kursach.Properties;
using System.IO;

namespace Kursach.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        private static readonly string appData =
    System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyLoginSaver");
        public AuthorizationPage()
        {
            InitializeComponent();
            DataContext = new AuthorizationViewModel();
          
        }

        public string log_info { get; private set; }
      


       
        private void exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void svernut(object sender, RoutedEventArgs e)
        {
            
        }

        private void txbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            AuthorizationViewModel.Password = txbPassword.Password;
        }

        private async void Authorication_Click(object sender, RoutedEventArgs e)
        {
            var UserServices = new UserService();
            bool exists = await UserServices.LoginUser(txbLogin.Text, txbPassword.Password);
            if (exists == false)
            {
                MessageBox.Show("Данные не верны");
            }
            else
            {
                
                ObjClas.Frame.FrameOBJ.Navigate(new UserInterface());
            }
            
        }
    }
}
