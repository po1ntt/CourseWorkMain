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

using Kursach.services;
namespace Kursach.ViewModel
{
    public class UserInterfaceViewModelcs : INotifyPropertyChanged
    {
        
        private Category _SelectedCathegory;

        public Category SelectedCathegory
        {
            get { return _SelectedCathegory; }
            set {
                _SelectedCathegory = value;
                CategoryVm categoryVm = new CategoryVm();
                if(_SelectedCathegory != null)
                {
                    categoryVm.GetTestsItems(_SelectedCathegory.CathegoryId);
                }
                OnPropertyChanged();
            }
        }

        private Tema _SelectedTema;

        public Tema SelectedTema
        {
            get { return _SelectedTema; }
            set { _SelectedTema = value;
                if(_SelectedTema != null)
                {
                    GetCategories(SelectedTema.TemaID);
                }
                OnPropertyChanged();
            }
        }


        public UserInterfaceViewModelcs()
        {
            TemaColl = new ObservableCollection<Tema>();
            categories = new ObservableCollection<Category>();
            GetTema();

            
        }
        public ObservableCollection<Tema> TemaColl { get; set; }
        public ObservableCollection<Category> categories { get; set; }
        public async void GetTema()
        {
            var TemaServices = new TemaService();
            var TemaColl1 = await TemaServices.GetListTemaAsunc();

            foreach (var item in TemaColl1)
            {
                TemaColl.Add(item);
            }
        }
        public async void GetCategories(int temaid)
        {
            var categoriesServices = new services.СathegoryServices();
            var cathegoriesColl = await categoriesServices.GetCathegoryBuTema(temaid);
            categories.Clear();
            foreach(var item in cathegoriesColl)
            {
                categories.Add(item);
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
