using Kursach.Model;
using Kursach.Pages;
using Kursach.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.ViewModel
{
     public class ProfileVM: INotifyPropertyChanged
    {
        public List<Users> ListUsers { get; set; }
        private Users _User;

        public Users User
        {
            get { return _User; }
            set { _User = value;
                ProfileUser.thisuser = _User;
                OnPropertyChanged();
            }
        }

        public ProfileVM()
        {
            ListUsers = new List<Users>();
            string login = AuthorizationViewModel.Login;
            GetUserLogin(login);

        }
        public async void GetUserLogin(string login)
        {
          
                User = null;
                UserService userService = new UserService();
                ListUsers = (await userService.SelectUsers()).Where(p => p.Login == login).ToList();
                foreach (var item in ListUsers.ToList())
                {
                    User = item;
                    break;
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
