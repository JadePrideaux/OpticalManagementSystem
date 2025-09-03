using OpticalManagementSystemDesktop.Helpers;
using OpticalManagementSystemDesktop.Models;
using OpticalManagementSystemDesktop.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace OpticalManagementSystemDesktop.ViewModels
{
    public class AddOptomViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel? _mainViewModel;
        private readonly OptomApiService _optomApi;

        public AddOptomViewModel() : this(null) { }

        public AddOptomViewModel(MainViewModel? mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _optomApi = new OptomApiService();

            CreateOptomCommand = new RelayCommand(async _ => await CreateOptom());
            BackToMenuCommand = new RelayCommand(_ => _mainViewModel?.ShowMainMenu());
        }

        // Class properties, private with public get/set
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

        private string _statusMessage = string.Empty;
        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }

        public ICommand CreateOptomCommand { get; }
        public ICommand BackToMenuCommand { get; }

        public async Task CreateOptom()
        {
            try
            {
                // Build an optom based on input data
                var newOptom = new Optometrist
                {
                    FirstName = FirstName,
                    LastName = LastName
                };

                // Call API to create optometrist
                var result = await _optomApi.CreateOptom(newOptom);

                if (result != null)
                    StatusMessage = $"Created optometrist with ID: {result.Id}";
                else
                    StatusMessage = "Failed to create optometrist. See API logs.";
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
