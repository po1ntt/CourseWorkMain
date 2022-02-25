using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Kursach.Model;
using System.Windows;
using System;

namespace Kursach.ViewModel
{
    public class AdminViewModel : DependencyObject
    {
        VictrovinaEntities context = new VictrovinaEntities();

        private Users selecteduser;
        private static string filtertext;
        

        public static Users[] GetUsers()
        {
            VictrovinaEntities context = new VictrovinaEntities();
            var result = context.Users.ToArray();
            return result;
        }

        public Users SelectedUser
        {
            get { return selecteduser; }
            set
            {
                selecteduser = value;
                OnPropertyChanged("SelectedUser");

            }

        }
        public AdminViewModel()
        {

            VictrovinaEntities context = new VictrovinaEntities();
            UsersList = GetUsers().ToList();
            UsersList.FindAll(FilterUsers);
        }


        public  string FilterText
        {
            get { return filtertext; }
            set
            {
                filtertext = value;
                OnPropertyChanged("FilterText");
            }
        }

        // Using a DependencyProperty as the backing store for FilterText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(AdminViewModel), new PropertyMetadata("", Filtertext_changed));


        private static void Filtertext_changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as AdminViewModel;
            if (current != null)
            {
                current.UsersList.FindAll(null);
                current.UsersList.FindAll(FilterUsers);
            }
        }


        public List<Users> UsersList
        {
            get { return (List<Users>)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("UsersList", typeof(List<Users>), typeof(AdminViewModel), new PropertyMetadata(null));


        private static bool FilterUsers(object obj)
        {
            bool result = true;
            Users current = obj as Users;
            if(!string.IsNullOrWhiteSpace(filtertext) && current!=null && !current.login.Contains(filtertext))
            {
               result = false;
            }
            return result;
        }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

     

       

    }
}
