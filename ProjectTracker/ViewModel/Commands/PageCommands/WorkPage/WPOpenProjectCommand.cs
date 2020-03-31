using Microsoft.Win32;
using ProjectTracker.View;
using ProjectTracker.View.Pages;
using ProjectTracker.ViewModel.Helpers;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.WorkPage
{
    /// <summary>
    /// TEMPORARY APPROACH TO PROJECT FILE ACCESS UNTILL I IMPLEMENT THE PROJECT FILES WINDOW
    /// </summary>
    public class WPOpenProjectCommand : ICommand
    {
        public WorkPageViewModel ViewModel { get; set; }

        public WPOpenProjectCommand(WorkPageViewModel viewModel)
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
            ProjectExplorerWindow projectExplorer = new ProjectExplorerWindow();
            projectExplorer.ShowDialog();
        }
    }
}
