using Microsoft.Win32;
using ProjectTracker.Model;
using ProjectTracker.ViewModel.Helpers;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.MainPage
{
    public class MPOpenProjectCommand : ICommand
    {

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

            if (openFileDialog.ShowDialog() == true)
            {
                ((MainPageViewModel)parameter).LoadedProject = ProjectFileHelper.ReadProjectFromFile(openFileDialog.FileName);
            }

        }
    }
}
