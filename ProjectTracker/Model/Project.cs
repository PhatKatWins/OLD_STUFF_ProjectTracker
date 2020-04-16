using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ProjectTracker.Model
{
    public class Project : INotifyPropertyChanged
    {

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        private string _description;

        public string Descsription
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged("Description"); }
        }

        private DateTime _dateOfCreation;

        public DateTime DateOfCreation
        {
            get { return _dateOfCreation; }
            set { _dateOfCreation = value; OnPropertyChanged("DateOfCreation"); }
        }

        private DateTime _dateOfLastEdit;

        public DateTime DateOfLastEdit
        {
            get { return _dateOfLastEdit; }
            set { _dateOfLastEdit = value; OnPropertyChanged("DateOfLastEdit"); }

        }

        private TimeSpan _timeSpentOnProject;

        public TimeSpan TimeSpentOnProject
        {
            get { return _timeSpentOnProject; }
            set { _timeSpentOnProject = value; OnPropertyChanged("TimeSpentOnProject"); }
        }


        private ObservableCollection<ProjectTask> _tasks;

        public ObservableCollection<ProjectTask> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; OnPropertyChanged("Tasks"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void RecalculateTimeSpent()
        {
            foreach(ProjectTask task in Tasks)
            {
                TimeSpentOnProject += task.TimeSpentOnTask;
            }
        }
    }
}
