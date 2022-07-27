using Microsoft.AspNetCore.Mvc;
using Practice.Interface;
using Practice.Models;
using Practice.Repository;
using Practice.Request;
using Practice.Response;

namespace Practice.Controllers
{
    public class BlogController : BaseApiController
    {
        private readonly IBlogService _blogService;
        private readonly PracticeContext _dbContext;

        public BlogController(IBlogService blogService, PracticeContext dbContext)
        {
            this._blogService = blogService;
            _dbContext = dbContext;
        }

        [HttpPost("GetBlogs")]
        public async Task<ResponseResult<List<BlogResponse>>> GetBlogs()
        {
            var result = await _blogService.GetBlogs();

            return SuccessResult(result);
        }
        
        [HttpPost("GetBlogWith")]

        public async Task<ResponseResult<DataPageResp<BlogResponse>>> GetBlogWith(BlogSearchRequest req)
        {
            var result = await _blogService.GetBlogWith(req);

            return SuccessResult(result);
        }

        [HttpPost("GetBlog")]
        public async Task<ResponseResult<BlogResponse>> GetBlog(int blogId)
        {
            var result = await _blogService.GetBlog(blogId);

            return SuccessResult(result);
        }

        [HttpPost("InsertBlog")]
        public async Task<ResponseResult> InsertBlog(BlogRequest req)
        {
            var result = await _blogService.InsertBlog(req);
            await _dbContext.SaveChangesAsync();
            
            if (result != 1) return FailureResult();

            return SuccessResult();
        }

        [HttpPost("UpdateBlog")]
        public async Task<ResponseResult> UpdateBlog(BlogRequest req)
        {
            var result = await _blogService.UpdateBlog(req);
            await _dbContext.SaveChangesAsync();

            if (result != 1) return FailureResult();

            return SuccessResult();
        }

        [HttpPost("DeleteBlog")]
        public async Task<ResponseResult> DeleteBlog(BlogRequest req)
        {
            var result = await _blogService.DeleteBlog(req);
            await _dbContext.SaveChangesAsync();

            if (result != 1) return FailureResult();

            return SuccessResult();
        }
    }
}
