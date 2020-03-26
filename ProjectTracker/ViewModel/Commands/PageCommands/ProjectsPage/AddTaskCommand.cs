using ProjectTracker.Model;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.ProjectsPage
{
    public class AddTaskCommand : ICommand
    {
        public ProjectsPageViewModel ViewModel { get; set; }

        public AddTaskCommand(ProjectsPageViewModel viewModel)
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
            if(ViewModel.Project.Tasks == null)
            {
                ViewModel.Project.Tasks = new ObservableCollection<ProjectTask>();
            }

            ViewModel.Project.Tasks.Add(new ProjectTask() { Name = "New Task", Description = "No Description", Stage = Stage.ToDo });
        }
    }
}
