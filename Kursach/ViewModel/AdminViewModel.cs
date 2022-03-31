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
using Kursach.services;

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







        private Users _SelectedUser;

        public Users SelectedUser
        {
            get { return _SelectedUser; }
            set { _SelectedUser = value;
                OnPropertyChanged();
            }
        }
        private Role _SelectedRole;

        public Role SelectedRole
        {
            get { return _SelectedRole; }
            set { _SelectedRole = value;
                OnPropertyChanged();
            }
        }



        public static List<Users> UserList { get; set; }

        public static List<Role> RoleList { get; set; }
        public async void GetRoleList()
        {
            UserService user = new UserService();
            var roles = await user.Roles();
            foreach(var item in roles)
            {
                RoleList.Add(item);
            }
        }

        public AdminViewModel()
        {
            RoleList = new List<Role>();
            UpdateAllDatagrid();
            GetRoleList();
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
        public async void UpdateAllDatagrid()
        {
            UserService userService = new UserService();
            // UserList = CommandsSqlClass.getallusers();
            UserList = await userService.SelectUsers();
            AdminInterface.UserListst.ItemsSource = null;
            AdminInterface.UserListst.Items.Clear();
            AdminInterface.UserListst.ItemsSource = UserList;
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
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
