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
    public class TestFormVM : INotifyPropertyChanged
    {
        public TestFormVM()
        {
            VictrovinaEntities context = new VictrovinaEntities();
            var test = context.Tests.Where(p => p.name_test);
            var qustion = context.Question.Where(p => p.id_test == TestForm.namebutton.ToString()).ToArray();
            int i = 0;
            int id = 1;
            while (i < qustion.Length)
            {
                int k = 1;
                var question = context.Question.Where(x => x.id_quest == id).FirstOrDefault();
                TextBlock NameQuest = new TextBlock();
                NameQuest.FontSize = 20;
                NameQuest.HorizontalAlignment = HorizontalAlignment.Left;
                NameQuest.VerticalAlignment = VerticalAlignment.Top;
                NameQuest.Text = $"{question.text_quest}";

                TestForm.stack.Children.Add(NameQuest);

                i++;
                id++;
            }
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
