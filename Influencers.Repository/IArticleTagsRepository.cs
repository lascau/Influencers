using Influencers.IRepository;
using Influencers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.Repository
{
    public interface IArticleTagsRepository : IRepository<ArticleTags>
    {
        public IEnumerable<Tags> GetTagsOfAnArticleBy(int articleId);

        public void deleteAllArticleTagsBy(int articleId);
    }
}
