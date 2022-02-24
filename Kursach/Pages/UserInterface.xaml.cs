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




namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для UserInterface.xaml
    /// </summary>
    public partial class UserInterface : Page
    {
        public static string log_info { get; set; }
        public UserInterface(string log1_info = "")
        {
            VictrovinaEntities context = new VictrovinaEntities();
            InitializeComponent();
            log_info = log1_info;
            DataContext = new  UserInterfaceViewModelcs();
            var cathegory = context.CathegoryTests.ToArray();
            int i = 0;
            int id = 1;
            int d = 0;
           
          
            while (i < cathegory.Length) 
            {
                int k = 1;
                var cathegory1 = context.CathegoryTests.Where(x => x.id_cat == id).FirstOrDefault();
                Button NameTest = new Button();
                NameTest.Background = Brushes.Transparent;
               
                NameTest.Content = $"{cathegory1.name_cathegory}";
                NameTest.Foreground = Brushes.Black;
                stack.Children.Add(NameTest);
                var tests = context.Tests.Where(x => x.id_cathegory == id).FirstOrDefault();
                if (tests != null)
                {
                    StackPanel submenu = new StackPanel();
                    var test2 = context.Tests.Where(x => x.id_cathegory == id).ToArray();
                    while (d < test2.Length)
                    {
                        var tests3 = context.Tests.Where(x => x.id_t == k).FirstOrDefault();
                        submenu.Margin = new Thickness(20, 0, 0, 0);
                        submenu.Name = $"submenu{id}";
                        Button Chose = new Button();
                        Chose.Content = $"{tests3.name_test}";
                        Chose.Click += new RoutedEventHandler(this.subl_click);
                        Chose.HorizontalContentAlignment = HorizontalAlignment.Left;
                        submenu.Children.Add(Chose);
                        d++;
                        k++;
                    }
                    stack.Children.Add(submenu);
                }

                id++;
                i++;
                d = 0;
                
            }
        
        

        }

        private void subl_click(object sender, RoutedEventArgs e)
        {
            ObjClas.Frame.FrameOBJ.Navigate(new TestForm());
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

        private void Python_click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Sharp_Click(object sender, RoutedEventArgs e)
        {

            ObjClas.Frame.FrameOBJ.Navigate(new SharpTests());
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

        private void Profile(object sender, MouseButtonEventArgs e)
        {
            ObjClas.Frame.FrameOBJ.Navigate(new ProfileUser(YourLogin.Text));
            
          
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            YourLogin.Text = log_info;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            YourLogin.Text = log_info;
        }

        private void MoveToXamarin(object sender, RoutedEventArgs e)
        {
            
        }

        private void MoveToWpf(object sender, RoutedEventArgs e)
        {
            
        }

       
    }
}
