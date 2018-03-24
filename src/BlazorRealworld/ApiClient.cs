using System;
using System.Collections.Generic;
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

        public async Task<UserResponse> SignUpAsync(UserFormModel userForm)
        {
            return await PostUserForm("/users", userForm);
        }

        public async Task<UserResponse> SignInAsync(UserFormModel userForm)
        {
            return await PostUserForm("/users/login", userForm);
        }

        async Task<UserResponse> PostUserForm(string urlFragment, UserFormModel userForm)
        {
            return await _httpClient.PostJsonAsync<UserResponse>($"{BaseUrl}{urlFragment}",
                new
                {
                    user = userForm
                });
        }

        public async Task<UserResponse> GetUserAsync()
        {
            return await _httpClient.GetJsonAsync<UserResponse>($"{BaseUrl}/user");
        }

        public async Task<IEnumerable<ArticleModel>> GetArticlesAsync(string tag = null)
        {
            return await GetArticlesAsync("/articles", tag);
        }

        public async Task<IEnumerable<ArticleModel>> GetArticleFeedAsync()
        {
            return await GetArticlesAsync("/articles/feed");
        }

        async Task<IEnumerable<ArticleModel>> GetArticlesAsync(string urlFragment, string tag = null)
        {
            var tagFilter = tag == null ? "" : $"tag={tag}&";
            var query = $"?{tagFilter}limit=10&offset=0";
            var articleResponse = await _httpClient.GetJsonAsync<ArticleResponse>($"{BaseUrl}{urlFragment}{query}");
            return articleResponse.articles;
        }

        public async Task<IEnumerable<string>> GetTagsAsync()
        {
            var tagsResponse = await _httpClient.GetJsonAsync<TagResponse>($"{BaseUrl}/tags");
            return tagsResponse.tags;
        }
    }

    public class UserResponse
    {
        public Errors errors { get; set; }
        public User user { get; set; }
    }

    public class Errors
    {
        public string[] username { get; set; }
        public string[] email { get; set; }
        public string[] password { get; set; }
    }

    class ArticleResponse
    {
        public ArticleModel[] articles { get; set; }
    }

    class TagResponse
    {
        public string[] tags { get; set; }
    }
}
