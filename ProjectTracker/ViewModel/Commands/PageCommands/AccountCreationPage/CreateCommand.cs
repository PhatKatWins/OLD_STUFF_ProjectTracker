using ProjectTracker.ViewModel.Helpers;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.AccountCreationPage
{
    public class CreateCommand : ICommand
    {
        public AccountCreationPageViewModel ViewModel { get; set; }

        public CreateCommand(AccountCreationPageViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //Check if all UI credential fields have been filled out
            if(!String.IsNullOrWhiteSpace(ViewModel.User.Name) && !String.IsNullOrWhiteSpace(ViewModel.User.Number))
            {
                //Insert the new user into the user database
                DataBaseHelper.InsertUser(ViewModel.User);
                //Display a message upon successfull creation of account
                MessageBox.Show($"Account successfully created." +
                    $"\nName: {ViewModel.User.Name}" +
                    $"\nNumber: {ViewModel.User.Number}" +
                    $"\nUse your credentials to log in.");
                //Navigate to the LogIn page.
                ((MainWindowViewModel)App.Current.Resources["MainWindowVM"]).PageUri = new Uri("Pages/LogInPage.xaml", UriKind.Relative);
            } 
            //Display message notifying the user that he has to fill in all of the credential fields
            else
            {
                MessageBox.Show("Please chose a name and/or generate a number.");
            } 
        }
    }
}
