using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Kursach.Model;
using System.Windows;
using System;
using System.Windows.Input;
using Kursach.ObjClas;
using Kursach.Pages;
using System.Windows.Controls;
using System.Windows.Media;
using System.Text;
using Kursach.services;
using System.Web.UI.MobileControls;

namespace Kursach.ViewModel
{
    public class AuthorizationViewModel : INotifyPropertyChanged
    {
       public RelayCommand newCommand { get; set; }
        public AuthorizationViewModel()
        {
        }
        public static string Phone { get; set; }
        public static string Mail { get; set; }
        public static DateTime Birthday { get; set; }
        public static string Surname { get; set; }
        public static string Name { get; set; }
        public static string Password { get; set; }
        public static string Password2 { get; set; }
        public static string Login { get; set; }
        public static Role Id_role { get; set; }

     
      
        private RelayCommand openWndRegistration;
        public RelayCommand OpenWndReg
        {
            get
            {
                return openWndRegistration ?? new RelayCommand(obj =>
                {
                    SetNullValuesToProperties();
                    OpenRegistrationWindow();
                });
            }
        }
        public RelayCommand Reg_Click { get; private set; }
        public void OpenRegistrationWindow()
        {
            RegistrationWindows neweditwindow = new RegistrationWindows();
            OpenCenterPosAndOpen(neweditwindow);
        }
        private void SetRedBlockControll(Window wnd, string blockname)
        {
            Control block = wnd.FindName(blockname) as Control;
            block.BorderBrush = Brushes.Red;
        }
        private void SetRedBlockControllPages(Page page, string blockname)
        {
            Control block = page.FindName(blockname) as Control;
            block.BorderBrush = Brushes.Red;
        }
        private void OpenCenterPosAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        public void SetNullValuesToProperties()
        {
            Phone = null;
            Mail = null;
            Name = null;
            Surname = null;
            Password = null;
            Login = null;
            Birthday = DateTime.Now;
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
