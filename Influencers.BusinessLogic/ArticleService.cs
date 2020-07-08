using Influencers.BusinessLogic.ViewModels;
using Influencers.Models;
using Influencers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Influencers.BusinessLogic
{
    public class ArticleService: IArticleService
    {
        private IArticleRepository _articleRepository;
        private IAuthorRepository _authorRepository;
        private IArticleTagsRepository _articleTagsRepository;
        private ITagsRepository _tagsRepository;

        public ArticleService(IArticleRepository articleRepository, IAuthorRepository authorRepository, IArticleTagsRepository articleTagsRepository, ITagsRepository tagsRepository)
        {
            _articleRepository = articleRepository;
            _authorRepository = authorRepository;
            _articleTagsRepository = articleTagsRepository;
            _tagsRepository = tagsRepository;
        }

        public void AddArticle(string email, string title, string content, DateTime date)
        {
            //verificare daca exista email-ul
            _articleRepository.Add(new Article()
            {
                //De adaugat tag-uri
                AuthorId = _authorRepository.GetAuthorIdBy(email),
                Content = content,
                Title = title,
                Date = date
            }); 
        }

        public ArticleViewModel GetArticleBy(int id)
        {
            var article =  _articleRepository.Get(id);
            var author = _authorRepository.Get((int)article.AuthorId);
            var authorName = author.Nickname;
            var authorVotes = author.Votes;
            var articleViewModel = new ArticleViewModel();
            
            articleViewModel.ArticleId = article.ArticleId;
            articleViewModel.Content = article.Content;
            articleViewModel.Date = article.Date;
            articleViewModel.Title = article.Title;
            articleViewModel.AuthorName = authorName;
            articleViewModel.Votes = (int)authorVotes;

            var tagsOfCurrentArticles = _articleTagsRepository.GetTagsOfAnArticleBy(article.ArticleId);

            string stringTags = "";
            foreach (var tag in tagsOfCurrentArticles)
            {
                stringTags = stringTags + tag.Name + " ";
            }
            articleViewModel.Hashtags = stringTags;

            return articleViewModel;
        }

        public List<ArticleViewModel> GetArticles()
        {
            var articles =_articleRepository.GetAll();
            List<ArticleViewModel> articlesViewModels = new List<ArticleViewModel>();


            foreach (var article in articles)
            {
                ArticleViewModel articleViewModel = new ArticleViewModel();
                var authorName = _authorRepository.Get((int)article.AuthorId).Nickname;


                articleViewModel.ArticleId = article.ArticleId;
                articleViewModel.Content = article.Content;
                articleViewModel.Date = article.Date;
                articleViewModel.Title = article.Title;
                articleViewModel.AuthorName = authorName;
                articleViewModel.Votes = _authorRepository.getVotesBy((int)article.AuthorId);

                var tagsOfCurrentArticles = _articleTagsRepository.GetTagsOfAnArticleBy(article.ArticleId);

                string stringTags = "";
                foreach (var tag in tagsOfCurrentArticles)
                {
                    stringTags = stringTags + tag.Name + " ";
                }
                articleViewModel.Hashtags = stringTags;
                //articleViewModel = article;

                articlesViewModels.Add(articleViewModel);

            }

            //Sort Decreasing by Date
            
            //Sa nu uit sa incerc sa sortez din repository articolele(mai eficient)
             articlesViewModels.Sort((article1, article2) => 
              DateTime.Compare((DateTime)article2.Date, (DateTime)article1.Date));

            return articlesViewModels;
        }

        public Article GetNewestAddedArticle(string title, string content, string email)
        {
            return _articleRepository.GetNewestAddedArticle(title, content, email);
        }

        public void UpdateArticle(int articleId, string title, string content, string tags)
        {
            var article = _articleRepository.Get(articleId);
            article.Title = title;
            article.Content = content;


            if (tags != null)
            {
                // sterg legaturile cu tag-urile de la articolul repsectiv
                _articleTagsRepository.deleteAllArticleTagsBy(articleId);

                //Adaug tag-urile in bdd
                foreach (var tag in tags.Split(""))
                {
                    _tagsRepository.Add(new Tags
                    {
                        Name = tag
                    });
                    // iau tagul nou creat
                    var recentlyCreatedTag = _tagsRepository.GetTagBy(tag);

                    // Dupa care leg articolul de noile taguri;
                    _articleTagsRepository.Add(new ArticleTags { Article = article, ArticleId = article.ArticleId, Tags = recentlyCreatedTag, TagsId = recentlyCreatedTag.TagsId });
                }
            }

            _articleRepository.Update(article);

        }
    }
}
