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

        public static string Phone { get; set; }
        public static string Mail { get; set; }
        public static DateTime Birthday { get; set; }
        public static string Surname { get; set; }
        public static string Name { get; set; }
        public static Role Id_role { get; set; }

        

        public List<Users> userList = CommandsSqlClass.getallusers();

        public List<Role> roleList = CommandsSqlClass.GetRoles();
        public List<Users> UserList
        {
            get { return userList; }
            set
            {
                userList = value;
                NotifyPropertyChanged("UserList");
            }
        }
        public List<Role> RoleList
        {
            get { return roleList; }
            set
            {
                roleList = value;
                NotifyPropertyChanged("RoleList");
            }
        }
        public static Users SelectedUser { get; set; }
      
        
        public AdminViewModel()
        {

            
            
          
        }
      
       
        private RelayCommand deleteuser;
        public RelayCommand DeleteUser
        {
            get
            {
                return deleteuser ?? new RelayCommand(obj =>
                {
                    string result = "nothing";
                    if(SelectedUser != null)
                    {
                        VictrovinaEntities context = new VictrovinaEntities();
                        var user = context.Users.Where(p => p.login == SelectedUser.login).FirstOrDefault();
                        context.Users.Remove(user);
                        context.SaveChangesAsync();
                        MessageBox.Show("Пользователь успешно удален!");
                        UpdateAllDatagrid();
                        
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не выбран!");
                    }

                    
                });
            }
        }
        private RelayCommand updateuserOpen;
        public RelayCommand UpdateUserOpen
        {
            get
            {
                return updateuserOpen ?? new RelayCommand(obj =>
                {
                    string result = "nothing";
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
        private RelayCommand edituser;
        public RelayCommand EditUser
        {
            get
            {
                return edituser ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string result = "не выбран пользователь";
                    string noRole = "не выбрана роль";
                    if (SelectedUser != null && Id_role != null)
                    {
                        string date = Birthday.ToString();
                        DateTime.Parse(date);
                        result = CommandsSqlClass.EditUserInfo(SelectedUser, Name, Surname, date, Phone, Mail, Id_role.id_r);
                        UpdateAllDatagrid();
                        SetNullValuesToProperties();
                        MessageBox.Show(result);
                        window.Close();
                    }

                });
            }
        }
        #region
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
            
        }
        private void UpdateAllDatagrid()
        {
            UserList = CommandsSqlClass.getallusers();
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
