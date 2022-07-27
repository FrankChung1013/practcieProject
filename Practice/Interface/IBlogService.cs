using Practice.Repository;
using Practice.Request;
using Practice.Response;

namespace Practice.Interface
{
    public interface IBlogService
    {
        Task<List<BlogResponse>> GetBlogs();
        Task<int> InsertBlog(BlogRequest req);
        Task<int> UpdateBlog(BlogRequest req);
        Task<int> DeleteBlog(BlogRequest req);
        Task<BlogResponse> GetBlog(int blogId);

        Task<DataPageResp<BlogResponse>> GetBlogWith(BlogSearchRequest req);
    }
}
