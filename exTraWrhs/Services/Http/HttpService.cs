using exTraWrhs.Services.Preferences;
using exTraWrhs.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exTraWrhs.Services.Http
{
    public class HttpService : IHttpService
    {
        private readonly IPreferencesService _preferencesService;

        public HttpService(IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;
        }

        private async Task<string> GetServerUri()
        {
            return await Task.FromResult(_preferencesService.GetPreferences("Appserver", string.Empty));
        }

        private HttpClient GetOrCreateHttpClient(string username = "", string password = "", string domain = "")
        {
            HttpClient httpClient = new HttpClient();

            var user = username;
            var pass = password;
            var basicAuthValue = "";
            if (domain == "")
                basicAuthValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            else
                basicAuthValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{domain}:{username}:{password}"));

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("X-Authorization", basicAuthValue);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "exTra Wrhs");

            return httpClient;
        }

        public async Task<string> Ping()
        {
            string serverUri = await GetServerUri();

            if (string.IsNullOrEmpty(serverUri))
            {
                return serverUri;
            }

            serverUri = serverUri + GlobalSettings.PingUri;

            try
            {
                using (var client = GetOrCreateHttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(serverUri);
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
