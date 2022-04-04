using Kursach.Model;
using Kursach.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.ViewModel
{
   public class ResultsPageVm : INotifyPropertyChanged
    {

        public static Users SelectedUser { get; set; }

        private Category _SelectedCathegory;

        public Category SelectedCathegory
        {
            get { return _SelectedCathegory; }
            set
            {
                _SelectedCathegory = value;
                string login = AuthorizationViewModel.Login;
                if (_SelectedCathegory != null)
                {
                    GetItemsForCathegory(_SelectedCathegory.CathegoryId, login);

                }
                OnPropertyChanged();
            }
        }
        private Tema _SelectedTema;

        public Tema SelectedTema
        {
            get { return _SelectedTema; }
            set
            {
                _SelectedTema = value;
                if (_SelectedTema != null)
                {
                    GetCategories(SelectedTema.TemaID);
                }
                OnPropertyChanged();
            }
        }
        private Category _SelectedCathegoryForAdmin;

        public Category SelectedCathegoryForAdmin
        {
            get { return _SelectedCathegoryForAdmin; }
            set
            {
                _SelectedCathegoryForAdmin = value;
                string login = SelectedUser.Login;
                if (_SelectedCathegoryForAdmin != null)
                {
                    GetItemsForCathegory(_SelectedCathegoryForAdmin.CathegoryId, login);

                }
                OnPropertyChanged();
            }
        }
        private Tema _SelectedTemaForAdmin;

        public Tema SelectedTemaForAdmin
        {
            get { return _SelectedTema; }
            set
            {
                _SelectedTemaForAdmin = value;
                if (_SelectedTemaForAdmin != null)
                {
                    GetCategories(_SelectedTemaForAdmin.TemaID);
                }
                OnPropertyChanged();
            }
        }


        private async void GetTemaList()
        {
            var data = await new services.TemaService().GetListTemaAsunc();
            TemaList.Clear();
            foreach (var item in data)
            {
                TemaList.Add(item);
            }
        }


        public ResultsPageVm()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            ResultsService resultsService = new ResultsService();
            Cathegories = new ObservableCollection<Category>();
            CathegoriesItems = new ObservableCollection<Results>();
            TemaList = new ObservableCollection<Tema>();
           
            GetTemaList();
        }
        public ObservableCollection<Category> Cathegories { get; set; }
        public ObservableCollection<Results> CathegoriesItems { get; set; }
        public ObservableCollection<Tema> TemaList { get; set; }
        private async void GetCategories(int tema_id)
        {
            var data = await new services.СathegoryServices().GetCathegoryBuTema(tema_id);
            Cathegories.Clear();
            foreach (var item in data)
            {
                Cathegories.Add(item);
            }
        }
        private async void GetItemsForCathegory(int id_cathegory, string user_login)
        {

            var data = await new services.ResultsService().GetTestResultByCathegoryAsync(id_cathegory, user_login);
            CathegoriesItems.Clear();
            foreach (var item in data)
            {
                CathegoriesItems.Add(item);
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
