using ProjectTracker.Model;
using ProjectTracker.ViewModel.Helpers;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands
{
    public class LogInCommand : ICommand
    {
        public LogInPageViewModel ViewModel { get; set; }

        public LogInCommand(LogInPageViewModel viewModel)
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
            User user = DataBaseHelper.FindUser(ViewModel.User);

            if(user != null)
            {
                ((MainWindowViewModel)App.Current.Resources["MainWindowVM"]).PageUri = new Uri("Pages/WorkPage.xaml", UriKind.Relative);
                ((MainWindowViewModel)App.Current.Resources["MainWindowVM"]).LoggedUser = user;
            } 
            else
            {
                MessageBox.Show("Wrong name or number.");
            }
        }
    }
}
