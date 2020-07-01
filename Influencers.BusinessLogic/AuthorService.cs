﻿using Influencers.BusinessLogic.ViewModels;
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

        public Author GetAuthorBy(int id)
        {
            return _authorRepository.Get(id);
        }

        public int GetAuthorIdBy(string email)
        {
            return _authorRepository.GetAuthorIdBy(email);
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

        public void UpdateScoreByAddingWith(int id, int score)
        {
            var author = _authorRepository.Get(id);
            author.Votes += score;
            _authorRepository.Update(author);
        }
    }
}
