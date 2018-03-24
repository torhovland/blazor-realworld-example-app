using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;

namespace BlazorRealworld
{
    public class ApiClient
    {
        const string BaseUrl = "https://conduit.productionready.io/api";
        private HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", token);
        }

        public async Task<User> GetUser()
        {
            var userResponse = await _httpClient.GetJsonAsync<UserResponse>($"{BaseUrl}/user");
            return userResponse.user;
        }
    }

    class UserResponse
    {
        public User user { get; set; }
    }
}
