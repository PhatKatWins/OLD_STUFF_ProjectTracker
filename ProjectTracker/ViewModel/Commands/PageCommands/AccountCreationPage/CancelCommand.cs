using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.AccountCreationPage
{
    public class CancelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ((MainWindowViewModel)App.Current.Resources["MainPageVM"]).PageUri = new Uri("Pages/LogInPage.xaml", UriKind.Relative);
        }
    }
}
