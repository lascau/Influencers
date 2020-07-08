using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.BusinessLogic.ViewModels
{
    public class ArticleViewModel
    {
        public int ArticleId { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }
        
        public DateTime? Date { get; set; }

        public string AuthorName { get; set; }

        public string Email { get; set; }

        public int Votes { get; set; }
        
        public String Hashtags { get; set; }

    }
}
