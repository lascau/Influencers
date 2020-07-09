using Influencers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Influencers.Repository
{
    public class TagsRepository : ITagsRepository
    {
        private InfluencersContext _dbContext;

        public TagsRepository(InfluencersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Tags entity)
        {
            _dbContext.Tags.Add(entity);
            _dbContext.SaveChanges();
        }

        public void AddTags(string[] tags)
        {
            foreach (var tag in tags)
            {
                if (!TagExists(tag))
                {
                    Add(new Tags()
                    {
                        Name = tag
                    }) ; 
                }
            }
        }

        public void Delete(Tags entity)
        {
            _dbContext.Tags.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Tags Get(int id)
        {
            return _dbContext.Tags.Find(id);
        }

        public List<Tags> GetAll()
        {
            return _dbContext.Tags.ToList();
        }

        public Tags GetTagBy(string tagName)
        {
            return _dbContext.Tags.Where(tag => tag.Name == tagName).FirstOrDefault();
        }

        public bool TagExists(string tagName)
        {
            var counterTags = _dbContext.Tags.Where(tag => tag.Name == tagName).Count();
            if (counterTags > 0)
            {
                return true;
            }
            return false;
        }

        public void Update(Tags entity)
        {
            _dbContext.Tags.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
