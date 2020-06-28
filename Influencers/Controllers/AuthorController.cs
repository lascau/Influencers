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

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
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
            _authorService.AddAuthor(authorViewModel.Nickname,
                                     authorViewModel.Email,
                                     authorViewModel.Votes);
           return Redirect(Url.Action("AddArticle", "Article"));
        }
    }
}