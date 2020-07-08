using Influencers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Influencers.Repository
{
    public class ArticleTagsRepository: IArticleTagsRepository
    {
        private InfluencersContext _dbContext;

        public ArticleTagsRepository(InfluencersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(ArticleTags entity)
        {
            _dbContext.ArticleTags.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(ArticleTags entity)
        {
            _dbContext.ArticleTags.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void deleteAllArticleTagsBy(int articleId)
        {
            var articleTags = _dbContext.ArticleTags.Where(a => a.ArticleId == articleId).AsEnumerable();
            foreach(var articleTag in articleTags)
            {
                Delete(articleTag);
                //int x = 23;
            }
        }

        public ArticleTags Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ArticleTags> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tags> GetTagsOfAnArticleBy(int articleId)
        {
            return  _dbContext.ArticleTags.Where(a => a.ArticleId == articleId).Select(t => t.Tags).AsEnumerable();
        }

        public void Update(ArticleTags entity)
        {
            _dbContext.ArticleTags.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
