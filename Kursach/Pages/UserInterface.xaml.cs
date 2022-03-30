using System;
using Kursach.ObjClas;
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
using Kursach.Model;
using Kursach.ViewModel;
using Kursach.Properties;

namespace Kursach.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserInterface.xaml
    /// </summary>
    public partial class UserInterface : Page
    {
        public static StackPanel stackfortest;
        public static string log_info { get; set; }
        public UserInterface()
        {
            InitializeComponent();
            log_info = AuthorizationViewModel.Login;

            DataContext = new UserInterfaceViewModelcs();
            
         

        }

      
        private void submenycloseandop(object sender, RoutedEventArgs e)
        {
            
            string sourceName = ((FrameworkElement)e.Source).Name;
            if(sourceName == "button1")
            {
              
            }
        }
      


        private void showStack(StackPanel name)
        {
            if (name.Visibility == Visibility.Collapsed)
            {
                name.Visibility = Visibility.Visible;
            }
            else
                name.Visibility = Visibility.Collapsed;
        }

        private void staccont()
        {

            Button NameTest = new Button();
            NameTest.Background = System.Windows.Media.Brushes.Transparent;
            NameTest.Content = "Введение";
            NameTest.Foreground = System.Windows.Media.Brushes.Black;
            StackPanel submenu = new StackPanel();
            submenu.Margin = new Thickness(20, 0, 0, 0);
            Button Chose = new Button();
            submenu.Children.Add(Chose);
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

        private void Teaching(object sender, MouseButtonEventArgs e)
        {

        }

        private  void Profile(object sender, MouseButtonEventArgs e)
        {
            ObjClas.Frame.FrameOBJ.Navigate(new ProfileUser());
            
          
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            YourLogin.Text = log_info = AuthorizationViewModel.Login;

        }


        private void OpenCenterPosAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }


        private void ListTests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if(ListTests.SelectedItem != null)
            {
                CategoryWnd categoryWnd = new CategoryWnd();
                OpenCenterPosAndOpen(categoryWnd);
            }
            ListTests.SelectedItem = null;

        }
    }
}
