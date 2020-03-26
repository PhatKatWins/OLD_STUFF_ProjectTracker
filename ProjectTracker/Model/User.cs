using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjectTracker.Model
{
    public class User : INotifyPropertyChanged
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private string number;

        public string Number
        {
            get { return number; }
            set { number = value; OnPropertyChanged("Number"); }
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
