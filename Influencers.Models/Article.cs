using System;
using System.Collections.Generic;

namespace Influencers.Models
{
    public partial class Article
    {
        public Article()
        {
            ArticleTags = new HashSet<ArticleTags>();
        }

        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Date { get; set; }
        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual ICollection<ArticleTags> ArticleTags { get; set; }
    }
}
