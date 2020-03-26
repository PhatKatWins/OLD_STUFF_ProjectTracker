using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.MainWindowCommands
{
    public class WorkPageCommand : ICommand
    {
        public MainWindowViewModel ViewModel { get; set; }

        public WorkPageCommand(MainWindowViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return ViewModel.LoggedUser != null;
        }

        public void Execute(object parameter)
        {
            ViewModel.PageUri = new Uri("Pages/WorkPage.xaml", UriKind.Relative);
        }

        public void RaiseCanExecuteChanged()
        {
            if(CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
