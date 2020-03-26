using Microsoft.Win32;
using ProjectTracker.ViewModel.Helpers;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.ProjectsPage
{
    /// <summary>
    /// TEMPORARY APPROACH TO PROJECT FILE ACCESS UNTILL I IMPLEMENT THE PROJECT FILES WINDOW
    /// </summary>
    public class OpenProjectCommand : ICommand
    {
        public ProjectsPageViewModel ViewModel { get; set; }

        public OpenProjectCommand(ProjectsPageViewModel viewModel)
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = ProjectFileHelper.projectSaveFolder;
            openFileDialog.Filter = "ProjectTracker files (*.ptf)|*.ptf";

            if(openFileDialog.ShowDialog() == true)
            {
                ViewModel.Project = ProjectFileHelper.ReadProjectFromFile(openFileDialog.FileName);
            }

        }
    }
}
