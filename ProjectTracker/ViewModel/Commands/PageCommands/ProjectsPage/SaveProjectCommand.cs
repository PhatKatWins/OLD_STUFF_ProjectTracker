using ProjectTracker.ViewModel.Helpers;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.ProjectsPage
{
    public class SaveProjectCommand : ICommand
    {
        public ProjectsPageViewModel ViewModel { get; set; }

        public SaveProjectCommand(ProjectsPageViewModel viewModel)
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
            MessageBoxResult result = MessageBox.Show("Are you sure you want to save your project?", "Save project to file", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                ProjectFileHelper.SaveProjectToFile(ViewModel.Project);
            }
        }
    }
}
