using Microsoft.Win32;
using ProjectTracker.View;
using ProjectTracker.View.Pages;
using ProjectTracker.ViewModel.Helpers;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
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
            if(ViewModel.LoadedProject != null)
            {
                MessageBox.Show("You currently have a project open. To avoid losing any changes made please use the 'Close' button first.", "Load new project", MessageBoxButton.OK);
            }
            else
            {
                ProjectExplorerWindow projectExplorer = new ProjectExplorerWindow();
                projectExplorer.Owner = App.Current.MainWindow;
                projectExplorer.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                projectExplorer.ShowDialog();
            }
        }
    }
}
