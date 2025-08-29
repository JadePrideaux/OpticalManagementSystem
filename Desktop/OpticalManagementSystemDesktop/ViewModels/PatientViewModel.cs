using OpticalManagementSystemDesktop.Helpers;
using OpticalManagementSystemDesktop.Models;
using OpticalManagementSystemDesktop.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace OpticalManagementSystemDesktop.ViewModels
{
    public class PatientViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel? _mainViewModel;
        private readonly PatientApiService _patientApi;

        public PatientViewModel() : this(null) { }

        // THIS constructor lets you call: new PatientViewModel(mainViewModel)
        public PatientViewModel(MainViewModel? mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _patientApi = new PatientApiService();

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

        // --- Commands ---
        public ICommand CreatePatientCommand { get; }
        public ICommand BackToMenuCommand { get; }

        // --- Action ---
        private async Task CreatePatient()
        {
            try
            {
                var newPatient = new Patient
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    DateOfBirth = DateOfBirth
                };

                var result = await _patientApi.CreatePatient(newPatient);

                if (result != null)
                    StatusMessage = $"✅ Created patient with ID: {result.Id}";
                else
                    StatusMessage = "❌ Failed to create patient. See API logs.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"❌ Error: {ex.Message}";
            }
        }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
