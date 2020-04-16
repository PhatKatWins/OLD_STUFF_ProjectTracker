using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.WorkPage
{
    public class DeleteNoteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (((WorkPageViewModel)App.Current.Resources["WorkPageVM"]).SelectedNote.Author != ((MainWindowViewModel)App.Current.Resources["MainWindowVM"]).LoggedUser.Name)
            {
                MessageBox.Show("Cannot delete this note because you are not the author.");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this note?", "Delete note", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    ((WorkPageViewModel)App.Current.Resources["WorkPageVM"]).SelectedTask.Notes.Remove(((WorkPageViewModel)App.Current.Resources["WorkPageVM"]).SelectedNote);
                }
            }
        }
    }
}
