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
using Kursach.ObjClas;
using System.Configuration;
using Kursach.Model;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            
        }

        public string log_info { get; private set; }
      

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            VictrovinaEntities context = new VictrovinaEntities();
            string login = txbLogin.Text.Trim();
            string password = psbPassword.Password.Trim();
         

            var user = DataBaseEntity.db.Users.FirstOrDefault(x => x.login == login && x.password == password);
            if(user != null)
            {
                if (user.id_role == 1)
                     ObjClas.Frame.FrameOBJ.Navigate(new UserInterface(txbLogin.Text));
                if (user.id_role == 2)
                    ObjClas.Frame.FrameOBJ.Navigate(new KuratorInteface(txbLogin.Text));
                if (user.id_role == 3)
                    ObjClas.Frame.FrameOBJ.Navigate(new AdminInterface(txbLogin.Text));
            }
            else
            {
                MessageBox.Show("Некореектно введенные данные");
                txbLogin.BorderBrush = Brushes.DarkRed;
                psbPassword.BorderBrush = Brushes.DarkRed;

            }

        }
       
        private void exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void svernut(object sender, RoutedEventArgs e)
        {
            
        }

        private void reg_click(object sender, RoutedEventArgs e)
        {
             ObjClas.Frame.FrameOBJ.Navigate(new RegistrationPage());
        }
    }
}
