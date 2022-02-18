using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Kursach.Model;
namespace Kursach.ViewModel
{
     public class User : INotifyPropertyChanged
    {
        private Users UserSel;
        public string Name
        {

            get { return UserSel.name; }
            set
            {
                UserSel.name = value;
                OnPropertyChanged("Name");

            }
        }
        public string Surname
        {
            get { return UserSel.surname; }
            set
            {
                UserSel.surname = value;
                OnPropertyChanged("Surname");

            }
        }
 
        public string Mail
        {
            get { return UserSel.mail; }
            set
            {
                UserSel.mail = value;
                OnPropertyChanged("Mail");

            }
        }
        public string Login
        {
            get { return UserSel.login; }
            set
            {
                UserSel.login = value;
                OnPropertyChanged("Login");

            }
        }
        public string Phone
        {
            get { return UserSel.phone; }
            set
            {
                UserSel.phone = value;
                OnPropertyChanged("Phone");

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
