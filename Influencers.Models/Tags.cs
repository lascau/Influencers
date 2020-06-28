using System;
using System.Collections.Generic;

namespace Influencers.Models
{
    public partial class Tags
    {
        public Tags()
        {
            ArticleTags = new HashSet<ArticleTags>();
        }

        public int TagsId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArticleTags> ArticleTags { get; set; }
    }
}
