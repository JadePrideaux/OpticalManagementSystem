using OpticalManagementSystemDesktop.Helpers;
using OpticalManagementSystemDesktop.Models;
using OpticalManagementSystemDesktop.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace OpticalManagementSystemDesktop.ViewModels
{
    // A view model for the add patient screen
    // Handles logic for binding bata from the view and calling the api to create patients.
    public class AddPatientViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel? _mainViewModel;
        private readonly PatientApiService _patientApi;

        public AddPatientViewModel() : this(null) { }

        // Constructor:
        public AddPatientViewModel(MainViewModel? mainViewModel)
        {
            // Set main view model and create a new patient API service
            _mainViewModel = mainViewModel;
            _patientApi = new PatientApiService();

            // Commands that buttons in the view bind to
            CreatePatientCommand = new RelayCommand(async _ => await CreatePatient());
            BackToMenuCommand = new RelayCommand(_ => _mainViewModel?.ShowMainMenu());
        }

        // --- Bindable properties ---
        private string _firstName = string.Empty;
        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(); }
        }

        private string _lastName = string.Empty;
        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(); }
        }

        private string _phoneNumber = string.Empty;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(); }
        }

        private DateTime _dateOfBirth = DateTime.Now;
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set { _dateOfBirth = value; OnPropertyChanged(); }
        }

        private string _statusMessage = string.Empty;
        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }

        // Commands exposed to View
        public ICommand CreatePatientCommand { get; }
        public ICommand BackToMenuCommand { get; }

        // Method to create a patient
        private async Task CreatePatient()
        {
            try
            {
                // Build a new patient based on input data
                var newPatient = new Patient
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    DateOfBirth = DateOfBirth
                };

                // Call API to create patient
                var result = await _patientApi.CreatePatient(newPatient);


                if (result != null)
                    StatusMessage = $"Created patient with ID: {result.Id}";
                else
                    StatusMessage = "Failed to create patient. See API logs.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
