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
    }
}
