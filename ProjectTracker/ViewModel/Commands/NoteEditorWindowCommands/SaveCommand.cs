using ProjectTracker.Model;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.WorkPage
{
    public class SaveCommand : ICommand
    {
        public Note Note { get; set; }
        public bool IsEditing { get; set; }

        public SaveCommand(Note note, bool isEditing)
        {
            Note = note;
            IsEditing = isEditing;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (IsEditing == false)
            {
                ((WorkPageViewModel)App.Current.Resources["WorkPageVM"]).SelectedTask.Notes.Add(Note);
                ((Window)parameter).Close();
            }
            else
            {
                ((WorkPageViewModel)App.Current.Resources["WorkPageVM"]).SelectedNote.Text = Note.Text;
                ((Window)parameter).Close();
            }
        }
    }
}
