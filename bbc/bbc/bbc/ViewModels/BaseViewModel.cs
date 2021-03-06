﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace bbc.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        protected Page GetCurrentPage()
        {
            var _currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            return _currentPage;
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        //public bool IsNotBusy => !IsBusy;

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        // private bool _offline;
        public bool Offline;

        // public static bool IsBusy { get; set; }
        public static bool myOffline { get; set; }

        private string _actionName;
        public string ActionName
        {
            get { return _actionName; }
            set
            {
                _actionName = value;
                OnPropertyChanged();
            }
        }
    }
}
