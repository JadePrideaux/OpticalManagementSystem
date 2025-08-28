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
        private readonly PatientApiService _patientApi = new PatientApiService();

        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private DateTime _dateOfBirth;
        private string _statusMessage;

        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(); }
        }

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(); }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(); }
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set { _dateOfBirth = value; OnPropertyChanged(); }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }

        public ICommand CreatePatientCommand { get; }

        public PatientViewModel()
        {
            CreatePatientCommand = new RelayCommand(async (_) => await CreatePatient());
        }

        private async Task CreatePatient()
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
            {
                StatusMessage = $"✅ Patient created with ID: {result.Id}";
            }
            else
            {
                StatusMessage = "❌ Failed to create patient.";
            }
        }

        // INotifyPropertyChanged boilerplate
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
