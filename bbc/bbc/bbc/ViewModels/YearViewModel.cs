using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using bbc.Data.Models;
using bbc.Data.Services;
using bbc.Interfaces;
using bbc.Views;
using bbc.Functions;

using Xamarin.Forms;
using bbc.LocalDatabase;
using System.IO;

namespace bbc.ViewModels
{
    public class YearViewModel : BaseViewModel
    {
        public LessonDatabaseAccess lessonDb;
        public QuestionDatabaseAccess questionDb;
        public AnswerDatabaseAccess answerDb;

        #region Attributes
        private RestLessonService restLessonService = null;
        private Lesson _selectedItem { get; set; }
        private List<Lesson> _listLesson { get; set; }
        private string _actionName;
        #endregion

        #region properties
        public Lesson SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public List<Lesson> ListLesson
        {
            get
            {
                return _listLesson;
            }
            set
            {
                _listLesson = value;
                OnPropertyChanged();
            }
        }

        public string ActionName
        {
            get
            {
                return _actionName;
            }
            set
            {
                _actionName = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region constructors
        public YearViewModel()
        {
            //if (Offline)
            //{
            //    IsBusy = true;
            //    // ShowListLessonFollowYear(null, null).GetAwaiter();
            //    ShowMyDataOffline();
            //    IsBusy = false;
            //}
            ActionName = "Delete";
            IsBusy = true;
            ShowMyDataOffline().GetAwaiter();
            IsBusy = false;
        }

        public YearViewModel(string title, string idTopic)
        {
            myOffline = false;
            IsBusy = true;
            ActionName = "Download";
            ShowListLessonFollowYear(title, idTopic).GetAwaiter();
            IsBusy = false;
        }

        #endregion

        #region commands
        public ICommand ItemListViewClick
        {
            get
            {
                return new Command(() =>
                {
                    GoToAudioPage();
                });
            }
            set { }
        }

        public Command<string> DownloadCommand
        {
            get { return new Command<string>(Download); }
        }
        #endregion

        #region methods
        private async Task ShowListLessonFollowYear(string year, string idTopic)
        {
            restLessonService = new RestLessonService();
            ListLesson = await restLessonService.GetDataAsync(); // Lấy tất cả các Lesson hiện có

            if (idTopic == null)
            {
                if (year != "All") // Lấy danh sách các Lesson theo năm
                {
                    ListLesson = ListLesson.Where(c => c.Year.Equals(int.Parse(year))).ToList();
                }
            }
            else
            {
                if (year != "All") // Lấy danh sách các Lesson theo năm
                {
                    ListLesson = ListLesson.Where(c => c.Year.Equals(int.Parse(year))).ToList();
                }
                // Lấy các Lesson theo Topic chọn
                ListLesson = ListLesson.Where(c => c.IdTP.Equals(idTopic)).ToList();
            }
            // Download();
        }

        private async void Download(string idLesson)
        {
            // DeleteLessonByID(idLesson);

            string nameLesson = null; //lưu tên Lesson để thông báo
            // Download Lesson
            foreach (var myLesson in ListLesson)
            {
                if (myLesson.Id.Equals(idLesson))
                {
                    nameLesson = myLesson.Name.Trim();
                    lessonDb = new LessonDatabaseAccess();
                    lessonDb.AddLesson(myLesson);
                    break;
                }
            }

            RestQuestionService resQuestionService = new RestQuestionService();
            List<Question> myLstQuestion = await resQuestionService.GetDataWithIDAsync(idLesson); // Lấy các câu hỏi có trong Lesson
            questionDb = new QuestionDatabaseAccess();
            answerDb = new AnswerDatabaseAccess();
            foreach (var myQuestion in myLstQuestion)
            {
                questionDb.AddQuestion(myQuestion); // Download Question
                RestAnswerService resAnswerService = new RestAnswerService();
                List<Answer> myLstAnswer = await resAnswerService.GetDataWithIDAsync(myQuestion.QuestionID); // Lấy các câu trả lời có trong cầu hỏi
                foreach (var myAnswer in myLstAnswer)
                    answerDb.AddAnswer(myAnswer); //Download Answer
            }

            DependencyService.Get<IMessage>().LongToast("Download " + nameLesson + " Completed");
        }

        private void DeleteLessonByID(string idLesson)
        {
            // Lấy các câu hỏi có trong Lesson
            questionDb = new QuestionDatabaseAccess();
            List<Question> myLstQuestion = new List<Question>();
            myLstQuestion = questionDb.GetQuestionDb(idLesson);
            foreach (var myQuestion in myLstQuestion)
            {
                // Thực hiện xóa câu trả lời
                answerDb = new AnswerDatabaseAccess();
                answerDb.DeleteAnswer(myQuestion.QuestionID);
            }
            // Thực hiện xóa câu hỏi
            questionDb.DeleteQuestion(idLesson);
            // Thực hiện xóa Lesson
            lessonDb = new LessonDatabaseAccess();
            lessonDb.DeleteLesson(idLesson);

            DependencyService.Get<IMessage>().ShortToast("Delete completed");

            ShowMyDataOffline();
        }

        private async Task ShowMyDataOffline()
        {
            //lessonDb = new LessonDatabaseAccess();
            //ListLesson = lessonDb.GetLessonDb();

            ListLesson = GetDataOffline.getLessonOffline();

            //foreach (var myLesson in ListLesson)
            //{
            //    DownloadImage downloadImage = new DownloadImage();
            //    // var ahihi= downloadImage.DownloadImageAsync(myLesson.ImageURL).GetAwaiter();
            //    byte[] ahihi = await downloadImage.MyDonwload(myLesson.ImageURL);
            //    myLesson.ImageURL = ahihi.ToString();
            //}

            // DependencyService.Get<IMessage>().ShortToast("Load Local Database Completed");

        }

        NavigationService navigationService;
        private void GoToAudioPage()
        {
            int _positionItem = _listLesson.IndexOf(_selectedItem);

            navigationService = new NavigationService();
            navigationService.NavigateOnDetail(_listLesson[_positionItem]);
        }
        #endregion

    }
}
