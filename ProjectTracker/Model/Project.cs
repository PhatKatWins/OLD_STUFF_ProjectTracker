using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ProjectTracker.Model
{
    public class Project : INotifyPropertyChanged
    {

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private string description;

        public string Descsription
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        private DateTime dateOfCreation;

        public DateTime DateOfCreation
        {
            get { return dateOfCreation; }
            set { dateOfCreation = value; OnPropertyChanged("DateOfCreation"); }
        }

        private DateTime dateOfLastEdit;

        public DateTime DateOfLastEdit
        {
            get { return dateOfLastEdit; }
            set { dateOfLastEdit = value; OnPropertyChanged("DateOfLastEdit"); }

        }

        private ObservableCollection<ProjectTask> tasks;

        public ObservableCollection<ProjectTask> Tasks
        {
            get { return tasks; }
            set { tasks = value; OnPropertyChanged("Tasks"); }
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
