using ProjectTracker.Model;
using ProjectTracker.View;
using ProjectTracker.ViewModel.Commands.NoteEditorWindowCommands;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.WorkPage
{
    public class AddNoteCommand : ICommand
    {
        public WorkPageViewModel ViewModel { get; set; }

        public AddNoteCommand(WorkPageViewModel viewModel)
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
            NoteEditorWindow window = new NoteEditorWindow();
            window.Owner = App.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            
            window.Note = new Note
            {
                Text = "Write your note here.",
                Author = ((MainWindowViewModel)App.Current.Resources["MainWindowVM"]).LoggedUser.Name
            };

            window.SaveCommand = new SaveCommand(window.Note, false);
            window.CancelCommand = new CancelCommand();

            window.ShowDialog();
        }
    }
}
