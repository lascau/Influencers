using Influencers.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.BusinessLogic
{
    public interface IArticleService
    {
        public List<ArticleViewModel> GetArticles();

        public ArticleViewModel GetArticleBy(int id);

        //Add article
        public void AddArticle(string email, string title, string content, DateTime date);

        //Edit article
    }
}
