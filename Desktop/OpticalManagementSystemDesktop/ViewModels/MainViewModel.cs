using OpticalManagementSystemDesktop.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OpticalManagementSystemDesktop.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            ShowMainMenu();
        }

        // Navigation helpers
        public void ShowMainMenu()
        {
            CurrentView = new MainMenuView(new MainMenuViewModel(this));
        }

        public void ShowAddPatient()
        {
            var patientVM = new PatientViewModel(this);
            CurrentView = new AddPatientView(patientVM);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
