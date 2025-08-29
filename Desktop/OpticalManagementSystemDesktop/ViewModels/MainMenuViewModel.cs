using OpticalManagementSystemDesktop.Helpers;
using System.Windows.Input;

namespace OpticalManagementSystemDesktop.ViewModels
{
    public class MainMenuViewModel
    {
        private readonly MainViewModel _mainViewModel;

        public ICommand NavigateToAddPatientCommand { get; }

        public MainMenuViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            NavigateToAddPatientCommand = new RelayCommand(_ => _mainViewModel.ShowAddPatient());
        }
    }
}
