using ProjectTracker.Model;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.WorkPage
{
    public class BeginStopWorkCommand : ICommand
    {
        public WorkPageViewModel ViewModel { get; set; }

        public BeginStopWorkCommand(WorkPageViewModel viewModel)
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
            //TESTS DONE ON TASK SELECTION AND TAB ACTUALIZATION

            //Back up the SelectedTask so that it's not lost when the Task Tabs are refreshed
            ProjectTask task = ViewModel.SelectedTask;

            ViewModel.SelectedTask.Stage = Stage.InProgress;
            ViewModel.LoadedProject.OnPropertyChanged("Tasks");
            
            //Restore the SelectedTask value after it's lost upon the OnPropertyChanged call
            ViewModel.SelectedTask = task;
            //Open the InProgress task tab
            ((TabControl)parameter).SelectedIndex = 1;
        }
    }
}
