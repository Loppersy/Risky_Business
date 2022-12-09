
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Risky_Business.ViewModels;

namespace Risky_Business.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            if(parameter.ToString() == "Intro")
            {

                viewModel.SelectedViewModel = new IntroViewModel();
            }
            else if(parameter.ToString() == "Analysis")
            {

                viewModel.SelectedViewModel = new AnalysisViewModel();
            }
        }
    }
}