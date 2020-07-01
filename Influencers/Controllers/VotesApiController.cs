using Influencers.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Influencers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotesApiController: ControllerBase
    {
        IAuthorService _authorService;

        public VotesApiController(IAuthorService authorService)
        {
            _authorService = authorService;
        }


        [HttpPost]
        [Route("VotesApi/SaveScore/{id, vote}")]
        public IActionResult SaveScore(int id, int vote)
        {
            _authorService.UpdateScoreByAddingWith(id, vote);
            return Ok();
        }
    }
}
