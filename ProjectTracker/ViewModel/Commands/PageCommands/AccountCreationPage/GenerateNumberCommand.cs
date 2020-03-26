using ProjectTracker.ViewModel.Helpers;
using ProjectTracker.ViewModel.PageViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProjectTracker.ViewModel.Commands.PageCommands.AccountCreationPage
{
    public class GenerateNumberCommand : ICommand
    {
        public AccountCreationPageViewModel ViewModel { get; set; }

        public GenerateNumberCommand(AccountCreationPageViewModel viewModel)
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
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            sb.Append(random.Next(1, 10));
            for (int x = 0; x < 3; x++)
            {
                sb.Append(random.Next(10));
            }

            if (!DataBaseHelper.NumberExists(sb.ToString())) ViewModel.User.Number = sb.ToString();
            else MessageBox.Show("Generated number already in use. Please generate again.");
        }
    }
}
