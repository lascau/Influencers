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

        public ArticleController(IArticleService articleService, IAuthorService authorService)
        {
            _articleService = articleService;
            _authorService = authorService;
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
                return Redirect(Url.Action("AddAuthor", "Author"));
            }
            _articleService.AddArticle(articleViewModel.Email,
                                       articleViewModel.Title,
                                       articleViewModel.Content,
                             (DateTime)articleViewModel.Date);
            return Redirect(Url.Action("Index", "Home"));
        }

    }
}