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
    public class AdminViewModel :INotifyPropertyChanged
    {

        // свойства для пользователя

        public string Phone { get; set; }
        public string Mail { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int Id_role { get; set; }

        private Users selecteduser;

        public List<Users> userList = CommandsSqlClass.getallusers();
        public List<Users> UserList
        {
            get { return userList; }
            set
            {
                userList = value;
                NotifyPropertyChanged("UserList");
            }
        }
        public Users SelectedUser
        {
            get { return selecteduser; }
            set
            {
                selecteduser = value;
                NotifyPropertyChanged("SelectedUser");

            }

        }
        public AdminViewModel()
        {

            
            
          
        }
        private RelayCommand openDeleteUser;
        public RelayCommand OpenDeleteUser
        {
            get
            {
                return openDeleteUser ?? new RelayCommand(obj =>
                {
                    OpenDeletePosWindow();
                }
                );

            }
        }
        private RelayCommand openEditRole;
        public RelayCommand OpenEditRole
        {
            get
            {
                return openDeleteUser ?? new RelayCommand(obj =>
                {
                   OpenEditRolePosWindow();
                }
                );

            }
        }
        private void SetRedBlockControll(Window wnd, string blockname)
        {
            Control block = wnd.FindName(blockname) as Control;
            block.BorderBrush = Brushes.Red;
        }
        private void SetNullValuesToProperties()
        {
            
        }
        private void UpdateAllDatagrid()
        {
            UserList = CommandsSqlClass.getallusers();
            AdminInterface.UserListst.ItemsSource = null;
            AdminInterface.UserListst.Items.Clear();
            AdminInterface.UserListst.ItemsSource = UserList;
            AdminInterface.UserListst.Items.Refresh();
        }
        public void OpenDeletePosWindow()
        {
            Window newwindow = new Window();
            OpenCenterPosAndOpen(newwindow);
        }
        public void OpenEditRolePosWindow()
        {
            EditUserWindowForAdmin neweditwindow = new EditUserWindowForAdmin();
            OpenCenterPosAndOpen(neweditwindow);
        }
        private void OpenCenterPosAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

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
