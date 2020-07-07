using Influencers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.BusinessLogic
{
    public interface ITagsService
    {
        public void AddTags(String[] tags);

        public bool TagExists(String tagName);

        public Tags GetTagBy(string tagName);
    }
}
