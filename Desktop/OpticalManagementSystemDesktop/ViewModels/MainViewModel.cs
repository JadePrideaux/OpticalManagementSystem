using OpticalManagementSystemDesktop.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OpticalManagementSystemDesktop.ViewModels
{
    // The root View Model for the app, controlls what view is displayed in the main window.

    public class MainViewModel : INotifyPropertyChanged
    {
        // Holds the current view
        private object? _currentView;

        // Get and Set methods to change the current view
        public object? CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        // When the app starts, show the main menu
        public MainViewModel()
        {
            ShowMainMenu();
        }


        // --- Navigation helpers, decide what view to show ---

        // Shows the main menu
        public void ShowMainMenu()
        {
            CurrentView = new MainMenuView(new MainMenuViewModel(this));
        }

        // Shows the add patient screen
        public void ShowAddPatient()
        {
            var patientVM = new AddPatientViewModel(this);
            CurrentView = new AddPatientView(patientVM);
        }

        // Data binding, update and change the UI
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
