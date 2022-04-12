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
using System.Windows.Shapes;
using Kursach.ViewModel;
using Kursach.Model;
using System.Text.RegularExpressions;
using Kursach.services;

namespace Kursach.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindowForAdmin.xaml
    /// </summary>
    public partial class EditUserWindowForAdmin : Window
    {
        public static Users user { get; set; }
        public AdminViewModel cvm { get; set; }
        public EditUserWindowForAdmin(Users usertoedit)
        {
             

            InitializeComponent();
            AdminViewModel viewModel = new AdminViewModel();
            cvm = new AdminViewModel();
            DataContext = cvm;
            txbName.Text = usertoedit.Name.ToString();
            txbData.Text = usertoedit.BirtDay.ToString();
            txbEmail.Text = usertoedit.Email.ToString();
            txbPhone.Text = usertoedit.Phone.ToString();
            txbSurName.Text = usertoedit.SurName.ToString();
            user = usertoedit;
            
           
        }

        private void TextBlock_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            UserService userService = new UserService();
            bool result = await userService.UpdateUser(txbName.Text, cvm.SelectedRole.id_role, user.Login, txbData.Text, txbSurName.Text, txbPhone.Text, txbEmail.Text, user.Password);
            if (result)
            {
                MessageBox.Show("Данные обновлены");
                cvm.UpdateAllDatagrid();
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
