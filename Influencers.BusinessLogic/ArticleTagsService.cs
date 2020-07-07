using Influencers.Models;
using Influencers.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.BusinessLogic
{
    public class ArticleTagsService : IArticleTagsService
    {
        private IArticleTagsRepository _articleTagsRepository;

        public ArticleTagsService(IArticleTagsRepository articleTagsRepository)
        {
            _articleTagsRepository = articleTagsRepository;
        }

        public void Add(Tags tag, Article article)
        {
            _articleTagsRepository.Add(new ArticleTags { Article = article, ArticleId = article.ArticleId, Tags = tag, TagsId = tag.TagsId });
        }

        public IEnumerable<Tags> GetTagsOfArticleById(int articleId)
        {
            return _articleTagsRepository.GetTagsOfAnArticleBy(articleId);
        }
    }
}

