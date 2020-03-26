using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjectTracker.Model
{
    public class ProjectTask : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        private Stage stage;

        public Stage Stage
        {
            get { return stage; }
            set { stage = value; OnPropertyChanged("Stage"); }
        }

        private bool isBeingWorkedOn;

        public bool IsBeingWorkedOn
        {
            get { return isBeingWorkedOn; }
            set { isBeingWorkedOn = value; OnPropertyChanged("IsBeingWorkedOn"); }
        }

        private DateTime lastWorkStartedOn;

        public DateTime LastWorkStartedOn
        {
            get { return lastWorkStartedOn; }
            set { lastWorkStartedOn = value; OnPropertyChanged("LastWorkStartedOn"); }
        }

        private TimeSpan timeSpentOnTask;

        public TimeSpan TimeSpentOnTask
        {
            get { return timeSpentOnTask; }
            set { timeSpentOnTask = value; OnPropertyChanged("TimeSpentOnTask"); }
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
    public enum Stage
    {
        ToDo,
        InProgress,
        Completed
    }
}
