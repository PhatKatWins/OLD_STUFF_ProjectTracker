using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjectTracker.Model
{
    public class Note : INotifyPropertyChanged
    {
        private string _author;

        public string Author
        {
            get { return _author; }
            set { _author = value; OnPropertyChanged("Author"); }
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged("Text"); }
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
