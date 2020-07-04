using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Influencers.BusinessLogic.ViewModels
{
    public class AuthorViewModel
    {
        public string Nickname { get; set; }

        [Required]
        [EmailAddressAttribute]
        public string Email { get; set; }

        public int? Votes { get; set; }

        public string ArticleContent {get; set;}

        public string ArticleTitle { get; set; }
    }
}
