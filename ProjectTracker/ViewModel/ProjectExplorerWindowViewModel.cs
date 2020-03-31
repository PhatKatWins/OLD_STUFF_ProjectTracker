using ProjectTracker.Model;
using ProjectTracker.ViewModel.Commands.ProjectExplorerWindowCommands;
using ProjectTracker.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ProjectTracker.ViewModel
{
    public class ProjectExplorerWindowViewModel : INotifyPropertyChanged
    {
        private Project _selectedProject;

        public Project SelectedProject
        {
            get { return _selectedProject; }
            set { _selectedProject = value; OnPropertyChanged("SelectedProject"); }
        }

        public List<Project> Projects { get; set; }

        public LoadProjectCommand LoadProjectCommand { get; set; }

        public ProjectExplorerWindowViewModel()
        {
            Projects = new List<Project>();
            LoadProjectCommand = new LoadProjectCommand(this);

            string[] files = Directory.GetFiles(ProjectFileHelper.projectSaveFolder);

            foreach(string filePath in files)
            {
                Projects.Add(ProjectFileHelper.ReadProjectFromFile(filePath));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
