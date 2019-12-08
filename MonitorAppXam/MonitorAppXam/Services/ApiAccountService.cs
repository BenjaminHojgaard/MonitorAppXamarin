using MonitorAppXam.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MonitorAppXam.Services
{
    class ApiAccountService
    {
        public async Task<bool> RegisterPrivilegedUser(string email, string password, string confirmPassword, string relation)
        {
            if (String.Equals(relation, "Medical", StringComparison.OrdinalIgnoreCase))
            {
                relation = "admin";
            }
            var registerModel = new RegisterModel()
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword,
                Country = RegionInfo.CurrentRegion.EnglishName,
                UserRole = relation.ToLower()
            };

            using (var httpClient = new HttpClient())
            {
                var token = Settings.AccessToken;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}"); 

                var json = JsonConvert.SerializeObject(registerModel);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://monitorappdevtest.azurewebsites.net/api/Account/RegisterTest", content);

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> RegisterUser(string email, string password, string confirmPassword, string relation)
        {
            var registerModel = new RegisterModel()
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword,
                Country = RegionInfo.CurrentRegion.EnglishName,
                UserRole = relation.ToLower()
            };

            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(registerModel);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://monitorappdevtest.azurewebsites.net/api/Account/Register", content);

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            var keyvalues = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("username", email),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password"),

            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://monitorappdevtest.azurewebsites.net/Token");

            request.Content = new FormUrlEncodedContent(keyvalues);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                JObject jObject = JsonConvert.DeserializeObject<dynamic>(content);
                var accessToken = jObject.Value<string>("access_token");

                if (response.IsSuccessStatusCode)
                {
                    Settings.AccessToken = accessToken;
                    Settings.UserName = email;
                    Settings.Password = password;
                }
                return response.IsSuccessStatusCode;
            }
        }
    }
}
