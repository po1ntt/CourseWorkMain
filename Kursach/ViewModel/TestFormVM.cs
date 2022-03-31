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
using System.Collections.ObjectModel;

namespace Kursach.ViewModel
{
    public class TestFormVM : INotifyPropertyChanged
    {
        private int _CurrentPos;
        public int CurrentPos
        {
            get
            {
                return this._CurrentPos;
            }
            set
            {
                this._CurrentPos = value;
                OnPropertyChanged();
            }
        }

        public TestFormVM(Tests SelectedTesta)
        {
            UserInterfaceViewModelcs vmuser = new UserInterfaceViewModelcs();
            QestionsBuTest = new ObservableCollection<Questions>();
            SelectedTest = SelectedTesta;
            questions = null;
            GetQuestionsBuTest(SelectedTesta.TestId);
            GetQuestInfo(SelectedTesta.TestId);
            
        }
        private Questions _CurrentQuestion;

        public Questions CurrentQuestion
        {
            get { return _CurrentQuestion; }
            set { _CurrentQuestion = value;
                OnPropertyChanged(); 
            }
        }
        private Tests _SelectedTest;

        public Tests SelectedTest
        {
            get { return _SelectedTest; }
            set { _SelectedTest = value; }
        }


        public static ObservableCollection<Questions> QestionsBuTest { get; set; }
        private async void GetQuestionsBuTest(int test_id)
        {
            var data = await new services.QuestionService().GetQuestionsAsyncBYTest(test_id);
            QestionsBuTest.Clear();
            foreach (var item in data)
            {
                QestionsBuTest.Add(item);

            }

        }
        public static List<Questions> questions { get; set; }
        public async void GetQuestInfo(int test_id)
        {
            QuestionService questionService = new QuestionService();
            if (questions == null)
            {
                CurrentQuestion = null;
                questions = (await questionService.GetQuestionsAsync()).Where(p => p.id_test == test_id).ToList();
                foreach (var item in questions.ToList())
                {
                    CurrentQuestion = item;
                    questions.Remove(item);
                    break;
                }
            }
            else
            {
                foreach (var item in questions.ToList())
                {
                    CurrentQuestion = item;
                    questions.Remove(item);
                    if (questions.Count == 0)
                    {
                        questions = null;
                    }
                    break;
                }
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
