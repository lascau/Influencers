using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Influencers.Models;
using Influencers.BusinessLogic;
using Influencers.BusinessLogic.DTOs;
using Influencers.BusinessLogic.ViewModels;

namespace Influencers.Controllers
{
    public class HomeController : Controller
    {
        private IArticleService _articleService;
        private IAuthorService _authorSerivce;
        
        public HomeController(IArticleService articleService, IAuthorService authorService)
        {
            _articleService = articleService;
            _authorSerivce = authorService;
        }

        public IActionResult Index()
        {
            var articles = _articleService.GetArticles();
            return View(articles);
        }

        [HttpGet]
        public IActionResult ReadMore([FromRoute] int id)
        {
            var article = _articleService.GetArticleBy(id);
            return View(article);
        }

        [HttpGet]
        public IActionResult EditThis(int id)
        {
            var article = _articleService.GetArticleBy(id);
            return View(article); 
        }

        [HttpPost]
        public IActionResult EditThis([FromForm]ArticleViewModel articleViewModel, int id)
        {
            articleViewModel.ArticleId = id;
            _articleService.UpdateArticle(articleViewModel.ArticleId,
                                            articleViewModel.Title,
                                            articleViewModel.Content);
            return Redirect(Url.Action("Index", "Home"));
        }

        [HttpGet]
        public IActionResult Leaderboard()
        {
            var authors = _authorSerivce.GetAuthors();
            return View(authors);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SendVote(VoteDTO voteDTO)
        {
            //
            return Ok();
        } 
    }
}
