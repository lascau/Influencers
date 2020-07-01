using Influencers.BusinessLogic.ViewModels;
using Influencers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.BusinessLogic
{
    public interface IAuthorService
    {
        // Get all authors       
        public List<AuthorViewModel> GetAuthors();

        // Add authors
        public void AddAuthor(string Nickname, string Email, int? Votes);

        public void UpdateScoreByAddingWith(int id, int score);

        public Boolean isThereAnAuthorWithEmail(string email);

        public Author GetAuthorBy(int id);

        public int GetAuthorIdBy(string email);

    }
}
