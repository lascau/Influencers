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
        }

        public void Delete(Tags entity)
        {
            _dbContext.Tags.Remove(entity);
        }

        public Tags Get(int id)
        {
            return _dbContext.Tags.Find(id);
        }

        public List<Tags> GetAll()
        {
            return _dbContext.Tags.ToList();
        }

        public void Update(Tags entity)
        {
            _dbContext.Tags.Update(entity);
        }
    }
}
