using Influencers.IRepository;
using Influencers.Models;

namespace Influencers.Repository
{
    public interface IArticleRepository: IRepository<Article>
    {
        public void SortDecreasingByDate();
    }
}
