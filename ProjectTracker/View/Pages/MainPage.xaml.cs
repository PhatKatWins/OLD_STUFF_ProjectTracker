using ProjectTracker.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectTracker.View.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ListBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(sender == toDoListBox)
            {
                inProgressListBox.SelectedItem = null;
                completedListbox.SelectedItem = null;
            }
            if (sender == inProgressListBox)
            {
                toDoListBox.SelectedItem = null;
                completedListbox.SelectedItem = null;
            }
            if (sender == completedListbox)
            {
                toDoListBox.SelectedItem = null;
                inProgressListBox.SelectedItem = null;
            }
        }

        private void ToggleButton_Pressed(object sender, RoutedEventArgs e)
        {
            if (((ToggleButton)sender).IsChecked == true)
            {
                ((ToggleButton)sender).Content = "Stop Work";
            }
            if (((ToggleButton)sender).IsChecked == false)
            {
                ((ToggleButton)sender).Content = "Begin Work";
            }
        }
    }
}
