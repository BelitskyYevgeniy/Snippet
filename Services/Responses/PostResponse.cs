using Services.Models;
using System.Collections.Generic;


namespace Services.Responses
{
    public class PostResponse
    {
        
        public string OwnerId { get; set; }

        public string Tittle { get; set; }

        public string Description { get; set; }
        
        public string LanguageName { get; set; }
       
        public string SnippetCode { get; set; }

        public int LikeCount { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
