using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.NoteEditorWindowCommands
{
    public class CancelCommand : ICommand
    {
        public bool IsEditing { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ((Window)parameter).Close();
        }
    }
}
