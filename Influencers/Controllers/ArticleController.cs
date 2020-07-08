using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Influencers.BusinessLogic;
using Influencers.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Influencers.Controllers
{
    public class ArticleController : Controller
    {
        
        private IArticleService _articleService;
        private IAuthorService _authorService;
        private ITagsService _tagsService;
        private IArticleTagsService _articleTagsService;

        public ArticleController(IArticleService articleService, IAuthorService authorService, ITagsService tagsService, IArticleTagsService articleTagsService)
        {
            _articleService = articleService;
            _authorService = authorService;
            _tagsService = tagsService;
            _articleTagsService = articleTagsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddArticle([FromForm]ArticleViewModel articleViewModel)
        {
            if (!_authorService.isThereAnAuthorWithEmail(articleViewModel.Email))
            {
                return Redirect(Url.Action("AddAuthor", "Author", articleViewModel));
            }

            _articleService.AddArticle(articleViewModel.Email,
                                       articleViewModel.Title,
                                       articleViewModel.Content,
                             (DateTime)articleViewModel.Date);
     
            String[] hashtags = articleViewModel.Hashtags.Split(" ");
            _tagsService.AddTags(hashtags);
           
            var recentlyCreatedArticle = _articleService.GetNewestAddedArticle(articleViewModel.Title,
                                                                               articleViewModel.Content,
                                                                               articleViewModel.Email);

            foreach (var hashtag in hashtags)
            {
                var tag = _tagsService.GetTagBy(hashtag);

                _articleTagsService.Add(tag, recentlyCreatedArticle);
            }
            return Redirect(Url.Action("Index", "Home"));
        }

    }
}