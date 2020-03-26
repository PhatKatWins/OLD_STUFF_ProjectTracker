using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.ProjectsPage
{
    public class RemoveTaskCommand : ICommand
    {
        public ProjectsPageViewModel ViewModel { get; set; }

        public RemoveTaskCommand(ProjectsPageViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if(CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        public bool CanExecute(object parameter)
        {
            return (ViewModel.SelectedTask != null);
        }

        public void Execute(object parameter)
        {
            ViewModel.Project.Tasks.Remove(ViewModel.SelectedTask);
            ViewModel.SelectedTask = null;
        }
    }
}
