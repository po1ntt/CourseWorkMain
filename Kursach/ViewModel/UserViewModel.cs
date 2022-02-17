using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using System.Runtime.CompilerServices;

namespace Kursach.ViewModel
{
    class UserViewModel : INotifyPropertyChanged
    {
        private User UserSel;
        public UserViewModel(User p)
        {
            UserSel = p;
        }
        public string Name
        {

            get { return UserSel.Name; }
            set
            {
                UserSel.Name = value;
                OnPropertyChanged("Name");

            }
        }
        public string Surname
        {
            get { return UserSel.Surname; }
            set
            {
                UserSel.Surname = value;
                OnPropertyChanged("Surname");

            }
        }

        public string Mail
        {
            get { return UserSel.Mail; }
            set
            {
                UserSel.Mail = value;
                OnPropertyChanged("Mail");

            }
        }
        public string Login
        {
            get { return UserSel.Login; }
            set
            {
                UserSel.Login = value;
                OnPropertyChanged("Login");

            }
        }
        public string Phone
        {
            get { return UserSel.Phone; }
            set
            {
                UserSel.Phone = value;
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
