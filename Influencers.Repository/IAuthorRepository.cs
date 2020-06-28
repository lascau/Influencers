using Influencers.IRepository;
using Influencers.Models;

namespace Influencers.Repository
{
    public interface IAuthorRepository: IRepository<Author>
    {
        public int GetAuthorIdBy(string email);

        public int getVotesBy(int id);

        public int NoAuthorsInTable();

    }
}
