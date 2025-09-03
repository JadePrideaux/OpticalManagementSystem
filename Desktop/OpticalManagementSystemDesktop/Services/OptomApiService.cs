using OpticalManagementSystemDesktop.Models;
using System.Net.Http.Json;

namespace OpticalManagementSystemDesktop.Services
{
    public class OptomApiService : BaseApiService
    {
        public OptomApiService() : base() { }

        public async Task<Optometrist?> CreateOptom(Optometrist optom)
        {
            var response = await _httpClient.PostAsJsonAsync("optometrist", optom);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Optometrist>();
            }

            return null;
        }
    }
}
