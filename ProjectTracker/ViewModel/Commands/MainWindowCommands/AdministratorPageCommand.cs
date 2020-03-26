using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.MainWindowCommands
{
    public class AdministratorPageCommand : ICommand
    {
        public MainWindowViewModel ViewModel { get; set; }

        public AdministratorPageCommand(MainWindowViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public void RaiseCanExecuteChanged()
        {
            if(CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return (ViewModel.LoggedUser != null);
        }

        public void Execute(object parameter)
        {
            ViewModel.PageUri = new Uri("Pages/AdministratorPage.xaml", UriKind.Relative);
        }
    }
}
