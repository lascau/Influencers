using Influencers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Influencers.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private InfluencersContext _dbContext;

        public AuthorRepository(InfluencersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Author entity)
        {
            _dbContext.Author.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Author entity)
        {
            _dbContext.Author.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Author Get(int id)
        {
            return _dbContext.Author.Find(id);
        }

        public List<Author> GetAll()
        {
            return _dbContext.Author.ToList();
        }

        public int GetAuthorIdBy(string email)
        {
            var author = _dbContext.Author.Where(author =>
                                          (author.Email).Equals(email))
                                    .FirstOrDefault();   
            if (author == null)
            {
                return -1;
            }
            return author.AuthorId;
        }

        public int getVotesBy(int id)
        {
            return (int)_dbContext.Author.Find(id).Votes;
        }

        public int NoAuthorsInTable()
        {
            return _dbContext.Author.Count();
        }

        public void Update(Author entity)
        {
            _dbContext.Author.Update(entity);
            _dbContext.SaveChanges();
        }

        
    }
}
