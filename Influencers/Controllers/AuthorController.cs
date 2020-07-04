using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Influencers.BusinessLogic;
using Influencers.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Influencers.Controllers
{
    public class AuthorController : Controller
    {
        
        private IAuthorService _authorService;
        private IArticleService _articleService;

        public AuthorController(IAuthorService authorService, IArticleService articleService)
        {
            _authorService = authorService;
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAuthor([FromForm]AuthorViewModel authorViewModel)
        {
            if (ModelState.IsValid)
            {
                _authorService.AddAuthor(authorViewModel.Nickname,
                                     authorViewModel.Email,
                                     0);
                _articleService.AddArticle(authorViewModel.Email, authorViewModel.ArticleTitle, authorViewModel.ArticleContent, DateTime.UtcNow);
                return Redirect(Url.Action("Index", "Home"));
            }
            return View(authorViewModel);
        }

        [HttpPost]
        public IActionResult SaveScore([FromForm(Name = "article.Email")] string email, [FromForm(Name = "article.Votes")] int score)
        {
            var authorId = _authorService.GetAuthorIdBy(email);
            _authorService.UpdateScoreByAddingWith(authorId, score);
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}