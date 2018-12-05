using Plugin.MediaManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using bbc.Data.Models;
using bbc.Views;

namespace bbc.ViewModels
{
    public class TestAudioViewModel : BaseViewModel
    {
        #region properties
        //private double _minimumSlider{get;set;}
        //public double MinimumSlider
        //{
        //    get { return _minimumSlider; }
        //    set
        //    {
        //        _minimumSlider = value;
        //        OnPropertyChanged();
        //    }
        //}

        private int _maximumSlider { get; set; }
        public int MaximumSlider
        {
            get { return _maximumSlider; }
            set
            {
                _maximumSlider = value;
                OnPropertyChanged();
            }
        }
        private Lesson _lesson { get; set; }
        public string NameLesson { get; set; }
        public string Transcript { get; set; }
        private double _valueSlider { get; set; }
        public double ValueSlider
        {
            get { return _valueSlider; }
            set
            {
                _valueSlider = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public TestAudioViewModel(Lesson lesson)
        {
            this._lesson = lesson;
            ShowLesson();
        }
        #endregion

        #region commands
        public ICommand PlayClick
        {
            get
            {
                return new Command(async () =>
                {
                    await DoWhenPlayClickAsync();
                });
            }
            set { }
        }

        public Command ExamCommand
        {
            get { return new Command(BeginExam); }
        }
        #endregion

        #region Methods
        private async void BeginExam()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ExamPage(_lesson));
        }

        private void ShowLesson()
        {
            NameLesson = _lesson.Name;
            Transcript = _lesson.Transcript;
            //_minimumSlider = 0;
            _maximumSlider = 100;
        }
        private void ValueSliderChanged()
        {

        }
        private async Task DoWhenPlayClickAsync()
        {
           await CrossMediaManager.Current.Play(_lesson.FileURLOnline);
        }
        #endregion
    }
}
