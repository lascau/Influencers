using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.BusinessLogic.ViewModels
{
    public class AuthorViewModel
    {
        public string Nickname { get; set; }
        
        public string Email { get; set; }
        
        public int? Votes { get; set; }
    }
}
