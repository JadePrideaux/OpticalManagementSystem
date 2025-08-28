using System.Net.Http;

namespace OpticalManagementSystemDesktop.Services
{
    // Base API service class

    public class BaseApiService
    {
        protected readonly HttpClient _httpClient;

        public BaseApiService()
        {
            _httpClient = new HttpClient
            {
                // Server address to send requests to
                BaseAddress = new Uri("http://localhost:5181/api/")
            };
        }
    }
}
