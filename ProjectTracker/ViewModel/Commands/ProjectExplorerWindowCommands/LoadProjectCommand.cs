using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.ProjectExplorerWindowCommands
{
    public class LoadProjectCommand : ICommand
    {
        public ProjectExplorerWindowViewModel ViewModel { get; set; }

        public LoadProjectCommand(ProjectExplorerWindowViewModel viewModel)
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
            ((WorkPageViewModel)Application.Current.Resources["WorkPageVM"]).LoadedProject = ViewModel.SelectedProject;
            ((Window)parameter).Close();
        }
    }
}
