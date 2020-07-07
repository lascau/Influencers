using Influencers.IRepository;
using Influencers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.Repository
{
    public interface ITagsRepository: IRepository<Tags>
    {
        public void AddTags(String[] tags);

        public bool TagExists(String tagName);

        public Tags GetTagBy(string tagName);
    }
}
