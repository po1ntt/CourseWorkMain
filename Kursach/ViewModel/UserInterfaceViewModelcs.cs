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


namespace Kursach.ViewModel
{
    class UserInterfaceViewModelcs : INotifyPropertyChanged
    {
        
        public UserInterfaceViewModelcs()
        {
           
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
