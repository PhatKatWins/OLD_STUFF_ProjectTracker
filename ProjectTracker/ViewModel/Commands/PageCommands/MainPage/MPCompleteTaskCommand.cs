using ProjectTracker.Model;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.MainPage
{
    public class MPCompleteTaskCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(((MainPageViewModel)parameter).SelectedTask != null)
            {
                return ((MainPageViewModel)parameter).SelectedTask.Stage != Stage.Completed;
            }
            else
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            ((MainPageViewModel)parameter).SelectedTask.Stage = Stage.Completed;
            ((MainPageViewModel)parameter).UpdateTaskCollections();
        }

        public void OnCanExecuteChanged()
        {
            if(CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
