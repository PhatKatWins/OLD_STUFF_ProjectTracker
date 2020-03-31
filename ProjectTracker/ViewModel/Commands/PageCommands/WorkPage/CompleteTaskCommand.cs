using ProjectTracker.Model;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.WorkPage
{
    public class CompleteTaskCommand : ICommand
    {
        public WorkPageViewModel ViewModel { get; set; }

        public CompleteTaskCommand(WorkPageViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProjectTask task = ViewModel.SelectedTask;

            if(MessageBox.Show("Test", "Test", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                ViewModel.SelectedTask.Stage = Stage.Completed;
                ViewModel.LoadedProject.OnPropertyChanged("Are you sure you want to mark the task as completed?");

                ViewModel.SelectedTask = task;
            }
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
