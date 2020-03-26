using ProjectTracker.Model;
using ProjectTracker.ViewModel.Commands;
using ProjectTracker.ViewModel.Commands.PageCommands.ProjectsPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace ProjectTracker.ViewModel.PageViewModels
{
    public class ProjectsPageViewModel : INotifyPropertyChanged
    {
        private Project project;

        public Project Project
        {
            get { return project; }
            set { project = value; OnPropertyChanged("Project"); }
        }

        private ProjectTask selectedTask;

        public ProjectTask SelectedTask
        {
            get { return selectedTask; }
            set 
            { 
                selectedTask = value; 
                OnPropertyChanged("SelectedTask");
                RemoveTaskCommand.RaiseCanExecuteChanged();
            }
        }


        public NewProjectCommand NewProjectCommand { get; set; }
        public AddTaskCommand AddTaskCommand { get; set; }
        public RemoveTaskCommand RemoveTaskCommand { get; set; }
        public SaveProjectCommand SaveProjectCommand { get; set; }
        public OpenProjectCommand OpenProjectCommand { get; set; }

        public List<Stage> EnumList { get; set; }

        public ProjectsPageViewModel()
        {
            NewProjectCommand = new NewProjectCommand(this);
            AddTaskCommand = new AddTaskCommand(this);
            RemoveTaskCommand = new RemoveTaskCommand(this);
            SaveProjectCommand = new SaveProjectCommand(this);
            OpenProjectCommand = new OpenProjectCommand(this);

            EnumList = new List<Stage>();
            foreach (Stage stage in Enum.GetValues(typeof(Stage)))
            {
                EnumList.Add(stage);
            }
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
