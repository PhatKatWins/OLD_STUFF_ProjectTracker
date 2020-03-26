using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.MainPage
{
    public class MPBeginStopWorkCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainPageViewModel viewModel = ((MainPageViewModel)parameter);

            if (viewModel.SelectedTask.IsBeingWorkedOn)
            {
                viewModel.SelectedTask.LastWorkStartedOn = DateTime.Now;
                ((MainWindowViewModel)Application.Current.Resources["MainWindowVM"]).IsWorking = true;
            }
            else
            {
                viewModel.SelectedTask.TimeSpentOnTask = DateTime.Now - viewModel.SelectedTask.LastWorkStartedOn;
                ((MainWindowViewModel)Application.Current.Resources["MainWindowVM"]).IsWorking = false;
            }
        }

        public void OnCanExecuteChanged()
        {
            if(CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
