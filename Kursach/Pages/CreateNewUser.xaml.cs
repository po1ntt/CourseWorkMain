using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Kursach.ViewModel;
using Kursach.Model;
using System.Text.RegularExpressions;
using Kursach.services;

namespace Kursach.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateNewUser.xaml
    /// </summary>
    public partial class CreateNewUser : Window
    {
       
        public CreateNewUser()
        {
            InitializeComponent();
            DataContext = new AdminViewModel();
        }
        private void TextBlock_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            UserService userService = new UserService();
            bool result = await userService.RegisterUser(txbLogin.Text, txbPassword.Text, txbEmail.Text, txbData.Text, txbName.Text, txbSurName.Text,txbPhone.Text);
            if (result)
            {
                MessageBox.Show("Новый пользователь добавлен");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
