using ProjectTracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace ProjectTracker.ViewModel.Converters
{
    public class FullToFilteredListConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<ProjectTask> list = new ObservableCollection<ProjectTask>();
            foreach (ProjectTask task in (ObservableCollection<ProjectTask>)value)
            {
                list.Add(task);
            }

            switch (parameter)
            {
                case "ToDo":
                    for (int n = 0; n < ((ObservableCollection<ProjectTask>)value).Count; n++)
                    {
                        if (((ObservableCollection<ProjectTask>)value)[n].Stage != Stage.ToDo)
                        {
                            list.Remove(((ObservableCollection<ProjectTask>)value)[n]);
                        }
                    }
                    break;
                case "InProgress":
                    for (int n = 0; n < ((ObservableCollection<ProjectTask>)value).Count; n++)
                    {
                        if (((ObservableCollection<ProjectTask>)value)[n].Stage != Stage.InProgress)
                        {
                            list.Remove(((ObservableCollection<ProjectTask>)value)[n]);
                        }
                    }
                    break;
                case "Complete":
                    for (int n = 0; n < ((ObservableCollection<ProjectTask>)value).Count; n++)
                    {
                        if (((ObservableCollection<ProjectTask>)value)[n].Stage != Stage.Completed)
                        {
                            list.Remove(((ObservableCollection<ProjectTask>)value)[n]);
                        }
                    }
                    break;
            }
            return list;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
