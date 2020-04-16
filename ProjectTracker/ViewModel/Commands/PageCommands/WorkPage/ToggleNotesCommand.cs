using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.WorkPage
{
    public class ToggleNotesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(((StackPanel)parameter).Visibility == Visibility.Collapsed)
            {
                ((StackPanel)parameter).Visibility = Visibility.Visible;
            }
            else
            {
                ((StackPanel)parameter).Visibility = Visibility.Collapsed;
            }
            
        }
    }
}
