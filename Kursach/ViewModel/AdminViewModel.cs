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

namespace Kursach.ViewModel
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        private Users selecteduser;

        public List<Users> Users { get; set; }

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
            Users = context.Users.Where(x=> x.id_role !=3).ToList();
            
        }
     
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private object userInterfaceViewModelcs;

        public object UserInterfaceViewModelcs { get => userInterfaceViewModelcs; set => SetProperty(ref userInterfaceViewModelcs, value); }
    }
}
