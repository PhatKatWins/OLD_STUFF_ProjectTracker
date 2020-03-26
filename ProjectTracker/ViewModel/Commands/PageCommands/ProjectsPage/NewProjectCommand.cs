using ProjectTracker.Model;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.ProjectsPage
{
    public class NewProjectCommand : ICommand
    {
        public ProjectsPageViewModel ViewModel { get; set; }

        public NewProjectCommand(ProjectsPageViewModel viewModel)
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
            ViewModel.Project = new Project() { Name = "New Project", Descsription = "No Description", 
                                                DateOfCreation = DateTime.Now, DateOfLastEdit = DateTime.Now,
                                                Tasks = new ObservableCollection<ProjectTask>()};
        }
    }
}
