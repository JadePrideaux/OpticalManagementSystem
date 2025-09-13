using OpticalManagementSystemDesktop.Models;
using System.Net.Http.Json;

namespace OpticalManagementSystemDesktop.Services
{
    public class OptomCalendarApiService : BaseApiService
    {
        public OptomCalendarApiService() : base() { }

        // Get calendar info (slot length + working hours)
        public async Task<OptomCalendar?> GetCalendarAsync(int calendarId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<OptomCalendar>($"optomcalendar/{calendarId}");
            }
            catch
            {
                return null;
            }
        }

        // Get all appointments for a specific date
        public async Task<List<Appointment>> GetAppointmentsForDateAsync(int calendarId, DateTime date)
        {
            try
            {
                var url = $"optomcalendar/{calendarId}/appointments?date={date:yyyy-MM-dd}";
                var result = await _httpClient.GetFromJsonAsync<List<Appointment>>(url);
                return result ?? new List<Appointment>();
            }
            catch
            {
                return new List<Appointment>();
            }
        }
    }
}