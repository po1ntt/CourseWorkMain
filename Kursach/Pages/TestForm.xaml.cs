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
using Kursach.ViewModel;

namespace Kursach.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestForm.xaml
    /// </summary>
    public partial class TestForm : Page
    {
        public static StackPanel stack;
        
        public static string namebutton { get; set; }
        public TestForm(string NameButton = "")
        {
            InitializeComponent();
            DataContext = new TestFormVM();
            stack = stackTest;
            namebutton = NameButton;
        }

        private void goback(object sender, RoutedEventArgs e)
        {
            ObjClas.Frame.FrameOBJ.GoBack();
        }
    }
}
