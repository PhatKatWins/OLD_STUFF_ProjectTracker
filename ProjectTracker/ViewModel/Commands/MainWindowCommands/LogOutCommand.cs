using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.MainWindowCommands
{
    public class LogOutCommand : ICommand
    {
        public MainWindowViewModel ViewModel { get; set; }

        public LogOutCommand(MainWindowViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.LoggedUser = null;
            ((WorkPageViewModel)App.Current.Resources["WorkPageVm"]).LoadedProject = null;
            ViewModel.PageUri = new Uri("Pages/LogInPage.xaml", UriKind.Relative);
        }
    }
}
