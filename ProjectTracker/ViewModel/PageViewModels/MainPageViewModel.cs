using ProjectTracker.Model;
using ProjectTracker.ViewModel.Commands.PageCommands.MainPage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace ProjectTracker.ViewModel.PageViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Project property holding the project used in the main page (core app functionality; work tracking).
        /// </summary>
        private Project _loadedProject;

        public Project LoadedProject
        {
            get { return _loadedProject; }
            set { _loadedProject = value; OnPropertyChanged("LoadedProject"); UpdateTaskCollections(); }
        }

        /// <summary>
        /// ProjectTask property representing the currently selected task in the main page.
        /// </summary>
        private ProjectTask _selectedTask;

        public ProjectTask SelectedTask
        {
            get { return _selectedTask; }
            set { _selectedTask = value; OnPropertyChanged("SelectedTask"); MPCompleteTaskCommand.OnCanExecuteChanged(); }
        }

        public ObservableCollection<ProjectTask> ToDoTasks { get; set; }
        public ObservableCollection<ProjectTask> InProgressTasks { get; set; }
        public ObservableCollection<ProjectTask> CompletedTasks { get; set; }


        public MPOpenProjectCommand MPOpenProjectCommand { get; set; }
        public MPCompleteTaskCommand MPCompleteTaskCommand { get; set; }
        public MPBeginStopWorkCommand MPBeginStopWorkCommand { get; set; }


        public MainPageViewModel()
        {
            ToDoTasks = new ObservableCollection<ProjectTask>();
            InProgressTasks = new ObservableCollection<ProjectTask>();
            CompletedTasks = new ObservableCollection<ProjectTask>();

            MPOpenProjectCommand = new MPOpenProjectCommand();
            MPCompleteTaskCommand = new MPCompleteTaskCommand();
            MPBeginStopWorkCommand = new MPBeginStopWorkCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void UpdateTaskCollections()
        {
            if(LoadedProject.Tasks != null)
            {
                ToDoTasks.Clear();
                InProgressTasks.Clear();
                CompletedTasks.Clear();

                foreach (ProjectTask task in LoadedProject.Tasks)
                {
                    switch (task.Stage)
                    {
                        case Stage.ToDo:
                            ToDoTasks.Add(task);
                            break;
                        case Stage.InProgress:
                            InProgressTasks.Add(task);
                            break;
                        case Stage.Completed:
                            CompletedTasks.Add(task);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
