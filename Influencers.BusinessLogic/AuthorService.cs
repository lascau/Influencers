using Influencers.BusinessLogic.ViewModels;
using Influencers.Models;
using Influencers.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.BusinessLogic
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void AddAuthor(string nickname, string email, int? votes)
        {     
            _authorRepository.Add(new Author()
                {
                    //AuthorId = _authorRepository.NoAuthorsInTable() + 1,
                    Nickname = nickname,
                    Email = email,
                    Votes = votes

                });
        }

        public List<AuthorViewModel> GetAuthors()
        {
            var authors = _authorRepository.GetAll();
            List<AuthorViewModel> authorsViewModel = new List<AuthorViewModel>();

            foreach(var author in authors) {
                AuthorViewModel authorViewModel = new AuthorViewModel();

                authorViewModel.Nickname = author.Nickname;
                authorViewModel.Email = author.Email;
                authorViewModel.Votes = author.Votes;
                authorsViewModel.Add(authorViewModel);
            }
            authorsViewModel.Sort((a, b) => ((int)b.Votes).CompareTo((int)a.Votes));
            return authorsViewModel;
        }

        public bool isThereAnAuthorWithEmail(string email)
        {
            return (_authorRepository.GetAuthorIdBy(email) != -1);
        }
    }
}
