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

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Reg_BUT(object sender, RoutedEventArgs e)
            
        {
          
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(txbLogin.Text))
            { 
                txbLogin.BorderBrush = Brushes.DarkRed;
                errors.AppendLine("укажите логин");
            }
            if (string.IsNullOrWhiteSpace(txbEmail.Text))
            {
                txbEmail.BorderBrush = Brushes.DarkRed;
                errors.AppendLine("укажите почту");
            }
            if (string.IsNullOrWhiteSpace(txbPassFirst.Text))
            {
                errors.AppendLine("укажите пароль");
                txbPassFirst.BorderBrush = Brushes.DarkRed;
            }
            if (txbPassFirst.Text != psbPassSecond.Password)
            {
                psbPassSecond.BorderBrush = Brushes.DarkRed;
                txbPassFirst.BorderBrush = Brushes.DarkRed;
                errors.AppendLine("пароли не совпадают");
            }
            var user = CommandsSqlClass.GetUsersBylogin(txbLogin.Text);
            if(user != null)
            {
                errors.AppendLine("Пользователь уже существует");
            }    
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if(errors.Length == 0)
            {
                DataBaseEntity.db.Users.Add(new Users
                {
                    login = txbLogin.Text,
                    password = psbPassSecond.Password,
                    mail = txbEmail.Text,
                    phone = txbPhone.Text,
                    birthday = DateTime.Parse(txbData.Text),
                    id_role = 1,
                    name = txbName.Text,
                    surname = txbSurname.Text
                });
                DataBaseEntity.db.SaveChangesAsync();
                ObjClas.Frame.FrameOBJ.Navigate(new AuthorizationPage());
            }
        }

        private void BACK_BUTT(object sender, RoutedEventArgs e)
        {
            ObjClas.Frame.FrameOBJ.Navigate(new AuthorizationPage());
        }
    }
}
