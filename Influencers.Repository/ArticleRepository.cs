using Influencers.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Influencers.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private InfluencersContext _dbContext;
        
        public ArticleRepository(InfluencersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Article entity)
        {
            _dbContext.Article.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Article entity)
        {
            _dbContext.Article.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Article Get(int id)
        {
            return _dbContext.Article.Find(id);
        }

        public List<Article> GetAll()
        {
            return _dbContext.Article.ToList();
        }

 
        public void SortDecreasingByDate()
        {
            _dbContext.Article.OrderByDescending(article => article.Date);
            _dbContext.SaveChanges();
        }

        public void Update(Article entity)
        {
            _dbContext.Article.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
