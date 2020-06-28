using Influencers.BusinessLogic.ViewModels;
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

        public Boolean isThereAnAuthorWithEmail(string email);

    }
}
