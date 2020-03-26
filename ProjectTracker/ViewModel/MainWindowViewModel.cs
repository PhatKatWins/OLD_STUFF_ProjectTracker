using ProjectTracker.Model;
using ProjectTracker.View.Pages;
using ProjectTracker.ViewModel.Commands;
using ProjectTracker.ViewModel.Commands.MainWindowCommands;
using ProjectTracker.ViewModel.Commands.PageCommands.MainPage;
using ProjectTracker.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProjectTracker.ViewModel
{
    /// <summary>
    /// The main window model is instantiated at runtime in App.xaml, due to the necessity that some properties exist throughout the entire run time.
    /// Said properties are used throughout different pages in order to prevent the loss of their values.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// User property for log in/out functionality.
        /// </summary>
        private User _loggedUser;

        public User LoggedUser
        {
            get { return _loggedUser; }
            set 
            {
                _loggedUser = value; OnPropertyChanged("LoggedUser");

                //Making sure that the Main and Admin pages cannot be accessed if there is no user logged in.
                WorkPageCommand.RaiseCanExecuteChanged();
                AdministratorPageCommand.RaiseCanExecuteChanged();
            }
        }
        /// <summary>
        /// URI property for handling the currently displayed page and page navigation.
        /// </summary>
        private Uri _pageUri;

        public Uri PageUri
        {
            get { return _pageUri; }
            set { _pageUri = value; OnPropertyChanged("PageUri"); }
        }
        /// <summary>
        /// Bool property denoting wether the user is working on a task.
        /// </summary>
        private bool _isWorking;

        public bool IsWorking
        {
            get { return _isWorking; }
            set { _isWorking = value; OnPropertyChanged("IsWorking"); }
        }


        public LogInPageCommand LogInPageCommand { get; set; }
        public WorkPageCommand WorkPageCommand { get; set; }
        public AdministratorPageCommand AdministratorPageCommand { get; set; }
        //Command for the Log Out button in the LogOut page
        //since there is no use in creating a view model for a single command.
        public LogOutCommand LogOutCommand { get; set; }
        public QuitCommand QuitCommand { get; set; }

        public MPOpenProjectCommand MPOpenProjectCommand { get; set; }
        public MPCompleteTaskCommand MPCompleteTaskCommand { get; set; }

        public MainWindowViewModel()
        {
            PageUri = new Uri("Pages/LogInPage.xaml", UriKind.Relative);
            IsWorking = false;

            LogInPageCommand = new LogInPageCommand(this);
            WorkPageCommand = new WorkPageCommand(this);
            AdministratorPageCommand = new AdministratorPageCommand(this);
            LogOutCommand = new LogOutCommand(this);
            QuitCommand = new QuitCommand();

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
