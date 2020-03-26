using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands
{
    public class NoAccountCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ((MainWindowViewModel)App.Current.Resources["MainWindowVM"]).PageUri = new Uri("Pages/AccountCreationPage.xaml", UriKind.Relative);
        }
    }
}
