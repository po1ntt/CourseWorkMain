using Kursach.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.ViewModel
{
    public class CategoryVm : INotifyPropertyChanged
    {
        public static ObservableCollection<Tests> TestsList { get; set; }
        public async void GetTestsItems(int cathegoryId)
        {
            var data = await new services.TestItemServices().GetTestByCathegoryAsync(cathegoryId);
            TestsList.Clear();
            foreach (var item in data)
            {

                {
                    TestsList.Add(item);
                }

            }
        }
        public CategoryVm()
        {
            TestsList = new ObservableCollection<Tests>();
            UserInterfaceViewModelcs user = new UserInterfaceViewModelcs();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
