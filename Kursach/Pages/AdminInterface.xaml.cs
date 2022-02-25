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

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для AdminInterface.xaml
    /// </summary>
    public partial class AdminInterface : Page
    {
        public static string log_info { get; set; }
        public AdminInterface(string log1_info = "")
        {
            
            InitializeComponent();
            VictrovinaEntities context = new VictrovinaEntities();
            log_info = log1_info;
            DataContext = new AdminViewModel();
            var user = context.Users.Where(x => x.login == txbLogin.Text).FirstOrDefault();
          
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
        private void Profile(object sender, MouseButtonEventArgs e)
        {
            ObjClas.Frame.FrameOBJ.Navigate(new ProfileUser(YourLogin.Text));


        }



        private void btnStud_Click(object sender, RoutedEventArgs e)
        {
            if (txbLogin.Text == "")
                MessageBox.Show("Выберите пользователя!");
            VictrovinaEntities context = new VictrovinaEntities();
            var user = context.Users.Where(x => x.login == txbLogin.Text).FirstOrDefault();
            if (user.id_role == 1)
            {
                MessageBox.Show("У пользователя уже роль студента");
            }
            else
            {
                user.id_role = 1;
                context.SaveChanges();
               
                MessageBox.Show("успех!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txbLogin.Text == "")
                MessageBox.Show("Выберите пользователя!");
            if (MessageBox.Show("Удалить пользователя?", "Удаление аккаунта", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                VictrovinaEntities context = new VictrovinaEntities();
                context.Users.Remove(context.Users.Where(x => x.login == txbLogin.Text).FirstOrDefault());
                context.SaveChangesAsync();
                
               
            }
        }
    }
}
