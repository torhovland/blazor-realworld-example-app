using System;

namespace BlazorRealworld
{
    public class ArticleModel
    {
        public string title { get; set; }
        public string slug { get; set; }
        public DateTime createdAt { get; set; }
        public string description { get; set; }
        public Author author { get; set; }
        public int favoritesCount { get; set; }
    }

    public class Author
    {
        public string username { get; set; }
        public string image { get; set; }
    }
}
