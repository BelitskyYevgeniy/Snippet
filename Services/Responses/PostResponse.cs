using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Responses
{
    public class PostResponse
    {
        
        public string OwnerName { get; set; }

        public string Tittle { get; set; }

        public string Description { get; set; }
        
        public string LanguageName { get; set; }
       
        public string SnippetCode { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
