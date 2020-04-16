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

            if(MessageBox.Show("Are you sure you want to mark the task as completed?", "Complete task", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                task.Stage = Stage.Completed;
                ViewModel.LoadedProject.OnPropertyChanged("Tasks");
                task.IsBeingWorkedOn = false;
                task.TimeSpentOnTask = DateTime.Now - task.LastWorkStartedOn;
                ViewModel.TaskWorkedOn = null;
                ViewModel.LoadedProject.RecalculateTimeSpent();

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
