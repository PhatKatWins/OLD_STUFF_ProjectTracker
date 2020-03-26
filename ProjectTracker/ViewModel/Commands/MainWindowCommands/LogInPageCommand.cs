using ProjectTracker.View.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands
{
    public class LogInPageCommand : ICommand
    {
        public MainWindowViewModel ViewModel { get; set; }

        public LogInPageCommand(MainWindowViewModel viewModel)
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
            if (ViewModel.LoggedUser == null)
            {
                ViewModel.PageUri = new Uri("Pages/LogInPage.xaml", UriKind.Relative);
            } 
            else
            {
                ViewModel.PageUri = new Uri("Pages/LogOutPage.xaml", UriKind.Relative);
            }
            
        }
    }
}
