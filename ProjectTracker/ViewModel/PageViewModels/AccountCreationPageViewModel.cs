using ProjectTracker.Model;
using ProjectTracker.ViewModel.Commands.PageCommands.AccountCreationPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjectTracker.ViewModel.PageViewModels
{
    public class AccountCreationPageViewModel : INotifyPropertyChanged
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

        public CancelCommand CancelCommand { get; set; }
        public GenerateNumberCommand GenerateNumberCommand { get; set; }
        public CreateCommand CreateCommand { get; set; }

        public AccountCreationPageViewModel()
        {
            User = new User();
            CancelCommand = new CancelCommand();
            GenerateNumberCommand = new GenerateNumberCommand(this);
            CreateCommand = new CreateCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
