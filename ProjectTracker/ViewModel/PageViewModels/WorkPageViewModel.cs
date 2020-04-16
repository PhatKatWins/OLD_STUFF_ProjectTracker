using ProjectTracker.Model;
using ProjectTracker.ViewModel.Commands.PageCommands.WorkPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjectTracker.ViewModel.PageViewModels
{
    public class WorkPageViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The project opened in the work page.
        /// </summary>
        private Project _loadedProject;

        public Project LoadedProject
        {
            get { return _loadedProject; }
            set { _loadedProject = value; OnPropertyChanged("LoadedProject"); }
        }

        /// <summary>
        /// The currently selected task in the work page.
        /// </summary>
        private ProjectTask _selectedTask;

        public ProjectTask SelectedTask
        {
            get { return _selectedTask; }
            set 
            { 
                _selectedTask = value; OnPropertyChanged("SelectedTask");
                CompleteTaskCommand.RaiseCanExecuteChanged();
            }
        }
        /// <summary>
        /// Holds the task being worked on, if any.
        /// </summary>
        public ProjectTask TaskWorkedOn { get; set; }

        /// <summary>
        /// The note, selected in the Notes panel
        /// </summary>
        private Note _selectedNote;

        public Note SelectedNote
        {
            get { return _selectedNote; }
            set { _selectedNote = value; OnPropertyChanged("SelectedNote"); }
        }

        public WPOpenProjectCommand WPOpenProjectCommand { get; set; }
        public BeginStopWorkCommand BeginStopWorkCommand { get; set; }
        public CompleteTaskCommand CompleteTaskCommand { get; set; }
        public AddNoteCommand AddNoteCommand { get; set; }
        public ToggleNotesCommand ToggleNotesCommand { get; set; }
        public CloseProjectCommand CloseProjectCommand { get; set; }
        public DeleteNoteCommand DeleteNoteCommand { get; set; }
        public EditNoteCommand EditNoteCommand { get; set; }

        public WorkPageViewModel()
        {
            WPOpenProjectCommand = new WPOpenProjectCommand(this);
            BeginStopWorkCommand = new BeginStopWorkCommand(this);
            CompleteTaskCommand = new CompleteTaskCommand(this);
            AddNoteCommand = new AddNoteCommand(this);
            ToggleNotesCommand = new ToggleNotesCommand();
            CloseProjectCommand = new CloseProjectCommand(this);
            DeleteNoteCommand = new DeleteNoteCommand();
            EditNoteCommand = new EditNoteCommand(this);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
