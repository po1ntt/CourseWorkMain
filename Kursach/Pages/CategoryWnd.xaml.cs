using Kursach.Model;
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

namespace Kursach.Pages
{
    /// <summary>
    /// Логика взаимодействия для CategoryWnd.xaml
    /// </summary>
    public partial class CategoryWnd : Window
    {
        public CategoryWnd()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Close();
            var SelectedTest = ((ListView)sender).SelectedItem as Tests;
            ObjClas.Frame.FrameOBJ.Navigate(new TestForm(SelectedTest));
        }
    }
}
