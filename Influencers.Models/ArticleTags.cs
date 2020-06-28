using System;
using System.Collections.Generic;

namespace Influencers.Models
{
    public partial class ArticleTags
    {
        public int ArticleTagsId { get; set; }
        public int? ArticleId { get; set; }
        public int? TagsId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Tags Tags { get; set; }
    }
}
