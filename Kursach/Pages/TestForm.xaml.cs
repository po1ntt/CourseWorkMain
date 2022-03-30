using System;
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
using Kursach.ObjClas;
using Kursach.Model;
using Kursach.ViewModel;
using Kursach.services;

namespace Kursach.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestForm.xaml
    /// </summary>
    public partial class TestForm : Page
    {
        public static int CountQuestions = 0;
        public static int currentPos = 0;
        public static int posforinte = 1;
        public static double score = 0;
        public static double scorepercent = 0;
        public static string imageMedal = null;
        public Tests TestModel { get; set; }
        TestFormVM cvm;

        public static string namebutton { get; set; }
        public TestForm(Tests SelectedTest)
        {
            InitializeComponent();
            TestModel = SelectedTest;
            cvm = new TestFormVM(SelectedTest);
            this.DataContext = cvm;

        }

        private void goback(object sender, RoutedEventArgs e)
        {
            ObjClas.Frame.FrameOBJ.GoBack();
        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content == FirstAnswer.Content)
            {

                FirstAnswer.BorderBrush = Brushes.Yellow;
                FirstAnswer.Background = Brushes.Yellow;
                SecondAnswer.BorderBrush = Brushes.DarkBlue;
                SecondAnswer.Background = Brushes.White;
                ThirdAnswer.BorderBrush = Brushes.DarkBlue;
                ThirdAnswer.Background = Brushes.White;
                FourAnswer.BorderBrush = Brushes.DarkBlue;
                FourAnswer.Background = Brushes.White;

                NextButton.IsEnabled = true;
                OverButton.IsEnabled = true;
                OverButton.Background = Brushes.Yellow;
                NextButton.Background = Brushes.Yellow;


            }
            else if (((Button)sender).Content == SecondAnswer.Content)
            {

                SecondAnswer.BorderBrush = Brushes.Yellow;
                SecondAnswer.Background = Brushes.Yellow;
                ThirdAnswer.BorderBrush = Brushes.DarkBlue;
                ThirdAnswer.Background = Brushes.White;

                FourAnswer.BorderBrush = Brushes.DarkBlue;
                FourAnswer.Background = Brushes.White;
                FirstAnswer.BorderBrush = Brushes.DarkBlue;
                FirstAnswer.Background = Brushes.White;
                NextButton.IsEnabled = true;
                OverButton.IsEnabled = true;
                OverButton.Background = Brushes.Yellow;
                NextButton.Background = Brushes.Yellow;

            }
            else if (((Button)sender).Content == ThirdAnswer.Content)
            {

                ThirdAnswer.BorderBrush = Brushes.Yellow;
                ThirdAnswer.Background = Brushes.Yellow;
                FourAnswer.BorderBrush = Brushes.DarkBlue;
                FourAnswer.Background = Brushes.White;
                FirstAnswer.BorderBrush = Brushes.DarkBlue;
                FirstAnswer.Background = Brushes.White;
                SecondAnswer.BorderBrush = Brushes.DarkBlue;
                SecondAnswer.Background = Brushes.White;
                NextButton.IsEnabled = true;
                OverButton.IsEnabled = true;
                OverButton.Background = Brushes.Yellow;
                NextButton.Background = Brushes.Yellow;


            }
            else if (((Button)sender).Content == FourAnswer.Content)
            {

                FourAnswer.BorderBrush = Brushes.Yellow;
                FourAnswer.Background = Brushes.Yellow;
                FirstAnswer.BorderBrush = Brushes.DarkBlue;
                FirstAnswer.Background = Brushes.White;
                SecondAnswer.BorderBrush = Brushes.DarkBlue;
                SecondAnswer.Background = Brushes.White;
                ThirdAnswer.BorderBrush = Brushes.DarkBlue;
                ThirdAnswer.Background = Brushes.White;
                NextButton.IsEnabled = true;
                OverButton.IsEnabled = true;
                OverButton.Background = Brushes.Yellow;
                NextButton.Background = Brushes.Yellow;

            }

        }

        private async void OverButton_Click(object sender, RoutedEventArgs e)
        {
            cvm.CurrentPos = posforinte + currentPos + 1;
            if (FirstAnswer.BorderBrush == Brushes.Yellow)
            {
                var data = TestFormVM.QestionsBuTest.ToList();
                foreach (var item in data)
                {
                    if (item.quest_rightanswer == FirstAnswer.Content.ToString())
                    {
                        score++;
                        break;
                    }
                }
            }
            else if (SecondAnswer.BorderBrush == Brushes.Yellow)
            {
                var data = TestFormVM.QestionsBuTest.ToList();
                foreach (var item in data)
                {
                    if (item.quest_rightanswer == SecondAnswer.Content.ToString())
                    {
                        score++;
                        break;
                    }
                }
            }
            else if (ThirdAnswer.BorderBrush == Brushes.Yellow)
            {
                var data = TestFormVM.QestionsBuTest.ToList();
                foreach (var item in data)
                {
                    if (item.quest_rightanswer == ThirdAnswer.Content.ToString())
                    {
                        score++;
                        break;
                    }
                }

            }
            else if (FourAnswer.BorderBrush == Brushes.Yellow)
            {
                var data = TestFormVM.QestionsBuTest.ToList();
                foreach (var item in data)
                {
                    if (item.quest_rightanswer == FourAnswer.Content.ToString())
                    {
                        score++;
                        break;
                    }
                }
            }
            scorepercent = 0;
            scorepercent = score / TestFormVM.QestionsBuTest.Count * 100;
            if (scorepercent > 40 && scorepercent < 60)
            {
                imageMedal = "https://cdn3.iconfinder.com/data/icons/awards-achievements-2/96/Bronze-8-512.png";
            }
            else if (scorepercent > 60 && scorepercent < 85)
            {
                imageMedal = "https://cdn3.iconfinder.com/data/icons/awards-achievements-2/96/Silver-7-512.png";
            }
            else if (scorepercent >= 85)
            {
                imageMedal = "https://cdn3.iconfinder.com/data/icons/awards-achievements-2/96/Gold-8-512.png";
            }
            else if (scorepercent < 40)
            {
                imageMedal = "https://cdn4.iconfinder.com/data/icons/interactions/64/interaction_interact_preferences_preformance_medal_award_reward_bad-512.png";
            }
            cvm.CurrentPos = posforinte + currentPos;
            FirstAnswer.BorderBrush = Brushes.DarkBlue;
            FirstAnswer.Background = Brushes.White;
            SecondAnswer.BorderBrush = Brushes.DarkBlue;
            SecondAnswer.Background = Brushes.White;
            ThirdAnswer.BorderBrush = Brushes.DarkBlue;
            ThirdAnswer.Background = Brushes.White;
            FourAnswer.BorderBrush = Brushes.DarkBlue;
            FourAnswer.Background = Brushes.White;
            var resultservice = new ResultsService();
            
            string Login = AuthorizationViewModel.Login;
            bool Result;

            Result = await resultservice.RegisterResult(TestModel.Name, Login, TestModel.CategoryId, scorepercent, TestModel.TestId, imageMedal);
            if (Result)
            {

                MessageBox.Show("Результат сохранен! " + scorepercent + "%");
                ObjClas.Frame.FrameOBJ.GoBack();


            }
            else
            {


                if (await resultservice.UpdateResult(TestModel.Name, TestModel.CategoryId, Login, scorepercent, TestModel.TestId, imageMedal))
                {
                    MessageBox.Show("Результат обновлен! " + scorepercent + "%");
                    ObjClas.Frame.FrameOBJ.GoBack();

                }
                else
                {
                    MessageBox.Show("Процент правильных ответов не изменился, результат остался прежним");
                    ObjClas.Frame.FrameOBJ.GoBack();
                }

            }
            TestModel = null;
            TestFormVM.questions = null;


        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            CountQuestions = TestFormVM.QestionsBuTest.Count;
            if (currentPos < CountQuestions - 2)
            {
                NextButton.IsEnabled = false;
                NextButton.BorderBrush = Brushes.Gray;
                cvm.GetQuestInfo(TestModel.TestId);

                if (currentPos < CountQuestions - 2)
                {
                    currentPos++;
                }
                if (FirstAnswer.BorderBrush == Brushes.Yellow)
                {
                    var data = TestFormVM.QestionsBuTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == FirstAnswer.Content.ToString())
                        {
                            score++;
                            break;
                        }
                    }
                }
                else if (SecondAnswer.BorderBrush == Brushes.Yellow)
                {
                    var data = TestFormVM.QestionsBuTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == SecondAnswer.Content.ToString())
                        {
                            score++;
                            break;
                        }
                    }
                }
                else if (ThirdAnswer.BorderBrush == Brushes.Yellow)
                {
                    var data = TestFormVM.QestionsBuTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == ThirdAnswer.Content.ToString())
                        {
                            score++;
                            break;
                        }
                    }

                }
                else if (FourAnswer.BorderBrush == Brushes.Yellow)
                {
                    var data = TestFormVM.QestionsBuTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == FourAnswer.Content.ToString())
                        {
                            score++;
                            break;
                        }
                    }
                }
                cvm.CurrentPos = posforinte + currentPos;
                FirstAnswer.BorderBrush = Brushes.DarkBlue;
                FirstAnswer.Background = Brushes.White;
                SecondAnswer.BorderBrush = Brushes.DarkBlue;
                SecondAnswer.Background = Brushes.White;
                ThirdAnswer.BorderBrush = Brushes.DarkBlue;
                ThirdAnswer.Background = Brushes.White;
                FourAnswer.BorderBrush = Brushes.DarkBlue;
                FourAnswer.Background = Brushes.White;
            }
            else if (CountQuestions - 2 == currentPos)
            {
                cvm.GetQuestInfo(TestModel.TestId);
                cvm.CurrentPos = posforinte + currentPos + 1;
                if (FirstAnswer.BorderBrush == Brushes.Yellow)
                {
                    var data = TestFormVM.QestionsBuTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == FirstAnswer.Content.ToString())
                        {
                            score++;
                            break;
                        }
                    }
                }
                else if (SecondAnswer.BorderBrush == Brushes.Yellow)
                {
                    var data = TestFormVM.QestionsBuTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == SecondAnswer.Content.ToString())
                        {
                            score++;
                            break;
                        }
                    }
                }
                else if (ThirdAnswer.BorderBrush == Brushes.Yellow)
                {
                    var data = TestFormVM.QestionsBuTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == ThirdAnswer.Content.ToString())
                        {
                            score++;
                            break;
                        }
                    }

                }
                else if (FourAnswer.BorderBrush == Brushes.Yellow)
                {
                    var data = TestFormVM.QestionsBuTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == FourAnswer.Content.ToString())
                        {
                            score++;
                            break;
                        }
                    }
                }

                NextButton.Visibility = Visibility.Collapsed;
                NextButton.IsEnabled = false;
                OverButton.IsEnabled = false;
                FirstAnswer.BorderBrush = Brushes.DarkBlue;
                FirstAnswer.Background = Brushes.White;
                SecondAnswer.BorderBrush = Brushes.DarkBlue;
                SecondAnswer.Background = Brushes.White;
                ThirdAnswer.BorderBrush = Brushes.DarkBlue;
                ThirdAnswer.Background = Brushes.White;
                FourAnswer.BorderBrush = Brushes.DarkBlue;
                FourAnswer.Background = Brushes.White;
                NextButton.Background = Brushes.Gray;
                OverButton.Background = Brushes.Gray;
                OverButton.Visibility = Visibility.Visible;
            }
        }

        private void SaveButtons_Click(object sender, RoutedEventArgs e)
        {
            ObjClas.Frame.FrameOBJ.GoBack();
            TestFormVM.questions = null;

        }
    }
}
