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
using Kursach.ViewModel;
using Kursach.ObjClas;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Kursach.services;

namespace Kursach.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindows.xaml
    /// </summary>
    public partial class RegistrationWindows : Window
    {
        
        public RegistrationWindows()
        {
            InitializeComponent();
            DataContext = new AuthorizationViewModel();
        }

        
        

        private void psbPassSecond_PasswordChanged(object sender, RoutedEventArgs e)
        {
            AuthorizationViewModel.Password2 = psbPassSecond.Password;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            UserService userService = new UserService();
            if(txbLogin.Text != null || txbPassFirst.Text == psbPassSecond.Password || txbData.Text == null || txbPhone == null || txbEmail.Text == null || txbSurname.Text == null  )
            {
                bool result = await userService.RegisterUser(txbLogin.Text, txbPassFirst.Text, txbEmail.Text, txbData.Text, txbName.Text, txbSurname.Text, Convert.ToInt32(txbPhone.Text));
                if (result)
                {
                    MessageBox.Show("Регистрация прошла успешка");
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                }
            }
            else
            {
                MessageBox.Show("Введите данные корректно");
            }
        }
    }
}
