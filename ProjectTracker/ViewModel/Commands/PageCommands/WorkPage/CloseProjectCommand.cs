using ProjectTracker.ViewModel.Helpers;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.WorkPage
{
    public class CloseProjectCommand : ICommand
    {
        public WorkPageViewModel ViewModel { get; set; }

        public CloseProjectCommand(WorkPageViewModel viewModel)
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
            if(ViewModel.TaskWorkedOn != null)
            {
                MessageBox.Show("You are currently working on: " + ViewModel.TaskWorkedOn.Name +
                                "\nFinish your current work before closing the project");
            }
            else
            {
                if(MessageBox.Show("Are you sure you want to close the project?", "Close project", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    ProjectFileHelper.SaveProjectToFile(ViewModel.LoadedProject);
                    ViewModel.LoadedProject = null;
                    ViewModel.SelectedTask = null;
                    ViewModel.TaskWorkedOn = null;
                }
            }
        }
    }
}
