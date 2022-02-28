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

namespace Kursach.ViewModel
{
    public class AuthorizationViewModel : INotifyPropertyChanged
    {
        public static string Phone { get; set; }
        public static string Mail { get; set; }
        public static DateTime Birthday { get; set; }
        public static string Surname { get; set; }
        public static string Name { get; set; }
        public static string Password { get; set; }
        public static string Password2 { get; set; }
        public static string Login { get; set; }
        public static Role Id_role { get; set; }

        private RelayCommand registrationCLick;
        public RelayCommand RegistrationClick
        {
            get
            {
                return registrationCLick ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    StringBuilder errors = new StringBuilder();
                   
                    if (string.IsNullOrWhiteSpace(Login))
                    {
                        SetRedBlockControll(wnd, "txbLogin");
                        errors.AppendLine("укажите логин");
                    }
                    if (string.IsNullOrWhiteSpace(Mail))
                    {
                        SetRedBlockControll(wnd, "txbEmail");
                        errors.AppendLine("укажите почту");
                    }
                    if (string.IsNullOrWhiteSpace(Password))
                    {
                        errors.AppendLine("укажите пароль");
                        SetRedBlockControll(wnd, "txbPassFirst");
                    }
                    if (string.IsNullOrWhiteSpace(Password2))
                    {
                        errors.AppendLine("укажите пароль");
                        SetRedBlockControll(wnd, "psbPassSecond");
                    }

                    if (Password != Password2)
                    {
                        SetRedBlockControll(wnd, "psbPassSecond");
                        SetRedBlockControll(wnd, "txbPassFirst");

                        errors.AppendLine("пароли не совпадают");
                    }
                    var user = CommandsSqlClass.GetUsersBylogin(Login);
                    if (user != null)
                    {
                        SetRedBlockControll(wnd, "txbLogin");
                        errors.AppendLine("Пользователь уже существует");
                    }
                    if (errors.Length > 0)
                    {
                        MessageBox.Show(errors.ToString());
                        return;
                    }
                    if (errors.Length == 0)
                    {
                        ObjClas.CommandsSqlClass.Create_user(Name, Surname, Birthday.ToString() ,Mail, Password, Login, newid_role: 1, Phone);
                        MessageBox.Show("Регистрация прошла успешно!");
                        ObjClas.Frame.FrameOBJ.Navigate(new AuthorizationPage());
                    }
                });
            }
        }
        private RelayCommand authorizationCLick;
        public RelayCommand AuthorizationClick
        {
            get
            {
                return authorizationCLick ?? new RelayCommand(obj =>
                {
                    
                    Page page = obj as Page;
                    
                    string result = CommandsSqlClass.authorization(Login, Password);
                    if(result == "Авторизация прошла успешно!")
                    {
                        MessageBox.Show(result);
                    }
                    else
                    {
                        MessageBox.Show(result);
                        SetRedBlockControllPages(page, "txbPassword");
                        SetRedBlockControllPages(page, "txbLogin");
                    }
                });
                     
            }
        }
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
