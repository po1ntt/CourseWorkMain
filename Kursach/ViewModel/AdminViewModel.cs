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

namespace Kursach.ViewModel
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        #region propertiesusers
        // свойства для пользователя

        public static string Phone { get; set; }
        public static string Mail { get; set; }
        public static DateTime Birthday { get; set; }
        public static string Surname { get; set; }
        public static string Name { get; set; }
        public static string Password { get; set; }
        public static string Login { get; set; }
        public static Role Id_role { get; set; }

        #endregion

     


       
   
        public static Users SelectedUser { get; set; }

      
        public AdminViewModel()
        {
        }
      
        #region commands

       
     
        private RelayCommand updateuserOpen;
        public RelayCommand UpdateUserOpen
        {
            get
            {
                return updateuserOpen ?? new RelayCommand(obj =>
                {
                    
                    if (SelectedUser != null)
                    {
                        OpenEditRolePosWindow(SelectedUser);
                     

                    }
                    else
                    {
                        MessageBox.Show("Пользователь не выбран!");
                    }
                });
            }
        }
      
        
        private RelayCommand openWndCreateuser;
        public RelayCommand OpenWndCreateUser
        {
            get
            {
                return openWndCreateuser ?? new RelayCommand(obj =>
                {
                    SetNullValuesToProperties();
                    OpenCreateNewUserWnd();
                    
                });
            }
        }
        #endregion

        #region properties
        private void SetRedBlockControll(Window wnd, string blockname)
        {
            Control block = wnd.FindName(blockname) as Control;
            block.BorderBrush = Brushes.Red;
        }
        private void SetNullValuesToProperties()
        {
            Phone = null;
            Mail = null;
            Name = null;
            Surname = null;
            Password = null;
            Login = null;
            Birthday = DateTime.Now;
        }
        private void UpdateAllDatagrid()
        {
           // UserList = CommandsSqlClass.getallusers();
            AdminInterface.UserListst.ItemsSource = null;
            AdminInterface.UserListst.Items.Clear();
          //  AdminInterface.UserListst.ItemsSource = UserList;
            AdminInterface.UserListst.Items.Refresh();
        }

        public void OpenEditRolePosWindow(Users user)
        {
            EditUserWindowForAdmin neweditwindow = new EditUserWindowForAdmin(user);
            OpenCenterPosAndOpen(neweditwindow);
        }
        public void OpenCreateNewUserWnd()
        {
            CreateNewUser neweditwindow = new CreateNewUser();
            OpenCenterPosAndOpen(neweditwindow);
        }
        private void OpenCenterPosAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion windows

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyname)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
