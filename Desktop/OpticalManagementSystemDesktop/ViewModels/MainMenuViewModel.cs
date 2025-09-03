using OpticalManagementSystemDesktop.Helpers;
using System.Windows.Input;

namespace OpticalManagementSystemDesktop.ViewModels
{
    // View Model for the Main Menu
    public class MainMenuViewModel
    {
        private readonly MainViewModel _mainViewModel;

        // Command bound to AddPatient button
        public ICommand NavigateToAddPatientCommand { get; }
        public ICommand NavigateToAddOptomCommand { get; }

        public MainMenuViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            NavigateToAddPatientCommand = new RelayCommand(_ => _mainViewModel.ShowAddPatient());
            NavigateToAddOptomCommand = new RelayCommand(_ => _mainViewModel.ShowAddOptom());
        }
    }
}