using ProjectTracker.Model;
using ProjectTracker.View;
using ProjectTracker.ViewModel.Commands.NoteEditorWindowCommands;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.WorkPage
{
    public class EditNoteCommand : ICommand
    {
        public WorkPageViewModel ViewModel { get; set; }

        public EditNoteCommand(WorkPageViewModel viewModel)
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
            if (((WorkPageViewModel)App.Current.Resources["WorkPageVM"]).SelectedNote.Author != ((MainWindowViewModel)App.Current.Resources["MainWindowVM"]).LoggedUser.Name)
            {
                MessageBox.Show("Cannot edit this note because you are not the author.");
            }
            else
            {
                NoteEditorWindow window = new NoteEditorWindow();
                window.Owner = App.Current.MainWindow;
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;


                window.Note = new Note
                {
                    Text = ((WorkPageViewModel)App.Current.Resources["WorkPageVM"]).SelectedNote.Text,
                    Author = ((WorkPageViewModel)App.Current.Resources["WorkPageVM"]).SelectedNote.Author
                };

                window.SaveCommand = new SaveCommand(window.Note, true);
                window.CancelCommand = new CancelCommand();

                window.ShowDialog();
            }
        }
    }
}
