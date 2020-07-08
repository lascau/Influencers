using Influencers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.BusinessLogic
{
    public interface IArticleTagsService
    {
        public void Add(Tags tag, Article article);

        public IEnumerable<Tags> GetTagsOfArticleById(int articleId);

    }
}
