using OpticalManagementSystemDesktop.Models;
using System.Net.Http.Json;

namespace OpticalManagementSystemDesktop.Services
{
    public class PatientApiService : BaseApiService
    {
        public PatientApiService() : base() { }

        // Create a patient
        public async Task<Patient?> CreatePatient(Patient patient)
        {
            var response = await _httpClient.PostAsJsonAsync("patient", patient);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Patient>();
            }

            return null;
        }
    }
}
