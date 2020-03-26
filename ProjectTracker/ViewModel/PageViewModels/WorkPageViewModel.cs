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
            set { _selectedTask = value; OnPropertyChanged("SelectedTask"); }
        }

        public WPOpenProjectCommand WPOpenProjectCommand { get; set; }
        public BeginStopWorkCommand BeginStopWorkCommand { get; set; }

        public WorkPageViewModel()
        {
            WPOpenProjectCommand = new WPOpenProjectCommand(this);
            BeginStopWorkCommand = new BeginStopWorkCommand(this);
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
