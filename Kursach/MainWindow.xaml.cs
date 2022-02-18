﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Kursach.ObjClas;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public static MainWindow window;
     
        public MainWindow()
        {
            InitializeComponent();
            ObjClas.Frame.FrameOBJ = MainFrame;
         
           
        }
        public static string log_info { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObjClas.Frame.FrameOBJ.Navigate(new UserInterface());
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
       

    }
}
