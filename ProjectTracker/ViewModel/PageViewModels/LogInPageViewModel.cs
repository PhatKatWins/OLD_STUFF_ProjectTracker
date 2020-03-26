using ProjectTracker.Model;
using ProjectTracker.ViewModel.Commands.PageCommands;
using ProjectTracker.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjectTracker.ViewModel.PageViewModels
{
    public class LogInPageViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// User property, data-bound to the UI fields for entering user credentials.
        /// </summary>
        private User _user;

        public User User
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged("User"); }
        }

        public LogInCommand LogInCommand { get; set; }
        public NoAccountCommand NoAccountCommand { get; set; }

        public LogInPageViewModel()
        {
            User = new User();
            LogInCommand = new LogInCommand(this);
            NoAccountCommand = new NoAccountCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
