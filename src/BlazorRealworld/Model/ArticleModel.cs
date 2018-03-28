using System;

namespace BlazorRealworld.Model
{
    public class ArticleModel
    {
        public ArticleModel()
        {
            author = new AuthorModel();
        }

        public string title { get; set; }
        public string slug { get; set; }
        public string body { get; set; }
        public DateTime createdAt { get; set; }
        public string[] tagList { get; set; }
        public string description { get; set; }
        public AuthorModel author { get; set; }
        public int favoritesCount { get; set; }
    }

    public class AuthorModel
    {
        public string username { get; set; }
        public string image { get; set; }
    }
}
