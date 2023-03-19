using HomeLibrary.Core;
using System;

namespace HomeLibrary.Content.ViewModels
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand ShowAvailableBooksCommand { get; set; }
        public RelayCommand ShowUnavailableBooksCommand { get; set; }

        public ShowAvailableBooksViewModel ShowAvailableBooksVM { get; set; }

        public ShowUnavailableBooksViewModel ShowUnavailableBooksVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value;
                OnPropertyChanged(); 
                }
        }

        public MainViewModel()
        {
            ShowAvailableBooksVM = new ShowAvailableBooksViewModel();
            ShowUnavailableBooksVM = new ShowUnavailableBooksViewModel();
            
            CurrentView = ShowAvailableBooksVM;

            ShowAvailableBooksCommand = new RelayCommand(o => CurrentView = ShowAvailableBooksVM);
            ShowUnavailableBooksCommand = new RelayCommand(o => CurrentView = ShowUnavailableBooksVM);
        }
    }
}
