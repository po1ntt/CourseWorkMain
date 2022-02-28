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

namespace Kursach.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindowForAdmin.xaml
    /// </summary>
    public partial class EditUserWindowForAdmin : Window
    {
        public EditUserWindowForAdmin(Users usertoedit)
        {
             

            InitializeComponent();
            DataContext = new AdminViewModel();
            AdminViewModel.SelectedUser = usertoedit;
            AdminViewModel.Name = usertoedit.name;
            AdminViewModel.Surname = usertoedit.surname;
            AdminViewModel.Birthday =DateTime.Parse(usertoedit.birthday.ToString());
            AdminViewModel.Phone = usertoedit.phone;
            AdminViewModel.Mail = usertoedit.mail;
            
           
        }

        private void TextBlock_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
