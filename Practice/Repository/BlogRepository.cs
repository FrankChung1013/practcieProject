using Practice.Models;
using Practice.Common;
using Practice.Request;

namespace Practice.Repository
{
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        private readonly PracticeContext _context;

        public BlogRepository(PracticeContext context) : base(context)
        {
            _context = context;
        }
    }

    public interface IBlogRepository : IBaseRepository<Blog>
    {
    }
}
