using OpticalManagementSystemDesktop.Helpers;
using OpticalManagementSystemDesktop.Models;
using OpticalManagementSystemDesktop.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace OpticalManagementSystemDesktop.ViewModels
{
    public class CalendarsViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel? _mainViewModel;
        private readonly OptomCalendarApiService _optomCalendarApi;

        public CalendarsViewModel() : this(null) { }

        public CalendarsViewModel(MainViewModel? mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _optomCalendarApi = new OptomCalendarApiService();

            BackToMenuCommand = new RelayCommand(_ => _mainViewModel?.ShowMainMenu());

            // Initialize appointments collection
            Appointments = new ObservableCollection<Appointment>();
            Slots = new ObservableCollection<Slot>();

            // Load appointments for a default calendar/date (hardcoded for now)
            _ = LoadAppointmentsAsync(1, DateTime.Today);
        }

        // Class properties, private with public get/set
        private bool _isBooked = false;
        public bool isBooked
        {
            get => _isBooked;
            set { _isBooked = value; OnPropertyChanged(); }
        }


        private string _statusMessage = string.Empty;
        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }

        // Collection bound to ListView
        public ObservableCollection<Appointment> Appointments { get; }
        public ObservableCollection<Slot> Slots { get; }

        // Command to navigate back to main menu
        public ICommand BackToMenuCommand { get; }

        // Load appointments from API for a specific calendar and date
        public async Task LoadAppointmentsAsync(int calendarId, DateTime date)
        {
            var result = await _optomCalendarApi.GetAppointmentsForDateAsync(calendarId, date);
            if (result != null)
            {
                Appointments.Clear();
                foreach (var appointment in result)
                {
                    Appointments.Add(appointment);
                }

                // Example: generate slots using default working hours and slot length
                GenerateSlots(date, TimeSpan.FromMinutes(25), TimeSpan.FromHours(9), TimeSpan.FromHours(17));
            }
        }


        public void GenerateSlots(DateTime date, TimeSpan slotLength, TimeSpan workStart, TimeSpan workEnd)
        {
            Slots.Clear();

            // Start at the beginning of the working day
            DateTime current = date.Date + workStart;
            DateTime endTime = date.Date + workEnd;

            while (current < endTime)
            {
                // Find an appointment at this time, if any
                var appointment = Appointments.FirstOrDefault(a => a.StartTime == current);

                // Add a slot — either empty or booked
                Slots.Add(new Slot
                {
                    StartTime = current,
                    Appointment = appointment // null if no appointment
                });

                current += slotLength; // move to next slot
            }
        }



        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
