using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Kursach.ObjClas;
using Kursach.ViewModel;
using Kursach.Model;
using System.Windows.Controls;
using System.Windows;
using System.Drawing;
using System.Windows.Media;
using Kursach.Pages;
using Brushes = System.Windows.Media.Brushes;

namespace Kursach.ViewModel
{
    class UserInterfaceViewModelcs : INotifyPropertyChanged
    {
        
        public UserInterfaceViewModelcs()
        {
            VictrovinaEntities context = new VictrovinaEntities();
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
                NameTest.Name = $"button{id}";

                NameTest.Content = $"{cathegory1.name_cathegory}";
                NameTest.Foreground = Brushes.Black;
                
                UserInterface.stackfortest.Children.Add(NameTest);
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
                        Chose.Command = NavigateTest;
                        Chose.HorizontalContentAlignment = HorizontalAlignment.Left;
                        submenu.Children.Add(Chose);
                        d++;
                        k++;
                    }
                    UserInterface.stackfortest.Children.Add(submenu);
                }

                id++;
                i++;
                d = 0;

            }
        }

        private RelayCommand navigateTest;
        public RelayCommand NavigateTest
        {
            get
            {
                return navigateTest ?? new RelayCommand(obj =>
                {
                    ObjClas.Frame.FrameOBJ.Navigate(new TestForm());
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
