using Influencers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.BusinessLogic
{
    public class TagsService: ITagsService
    {
        private ITagsService _tagsService;

        public TagsService(ITagsService tagsService)
        {
            _tagsService = tagsService;
        }

        public void AddTags(string[] tags)
        {
            _tagsService.AddTags(tags);
        }

        public Tags GetTagBy(string tagName)
        {
            return _tagsService.GetTagBy(tagName);
        }

        public bool TagExists(string tagName)
        {
            return _tagsService.TagExists(tagName);
        }
    }
}
