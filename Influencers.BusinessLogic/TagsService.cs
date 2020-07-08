using Influencers.Models;
using Influencers.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.BusinessLogic
{
    public class TagsService: ITagsService
    {
        private ITagsRepository _tagsRepository;

        public TagsService(ITagsRepository tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }

        public void AddTags(string[] tags)
        {
            _tagsRepository.AddTags(tags);
        }

        public Tags GetTagBy(string tagName)
        {
            return _tagsRepository.GetTagBy(tagName);
        }

        public bool TagExists(string tagName)
        {
            return _tagsRepository.TagExists(tagName);
        }
    }
}
