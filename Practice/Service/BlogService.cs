using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Practice.Interface;
using Practice.Models;
using Practice.Repository;
using Practice.Request;
using Practice.Response;
using Practice.Common;
using Practice.Common.Extensions;

namespace Practice.Service
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BlogResponse>> GetBlogs()
        {
            var blogs = await _repository.GetAllAsync();
            return _mapper.Map<List<BlogResponse>>(blogs);
        }

        public async Task<int> InsertBlog(BlogRequest req)
        {
            var insertBlog = _mapper.Map<Blog>(req);
            var result = await _repository.InsertAsync(insertBlog);

            return result;
        }

        public async Task<int> UpdateBlog(BlogRequest req)
        {
            var updateBlog = _mapper.Map<Blog>(req);
            var result = await _repository.UpdateAsync(updateBlog);

            return result;
        }

        public async Task<int> DeleteBlog(BlogRequest req)
        {
            var deleteBlog = _mapper.Map<Blog>(req);
            var result = await _repository.DeleteAsync(deleteBlog);

            return result;
        }

        public async Task<BlogResponse> GetBlog(int blogId)
        {
            var result =  _mapper.Map<BlogResponse>(await _repository.GetAsync(x => x.BlogId == blogId));

            return result;
        }

        public async Task<DataPageResp<BlogResponse>> GetBlogWith(BlogSearchRequest req)
        {
            // var result = _mapper.Map<List<BlogResponse>>(await _repository.GetAllAsync());
            var query = _repository.Queryable();

            if (!string.IsNullOrEmpty(req.Name))
            {
                query = query.Where(x => x.Name == req.Name);
            }

            if (req.BlogId != null)
            {
                query = query.Where(x => x.BlogId == req.BlogId);
            }

            if (!string.IsNullOrEmpty(req.Url))
            {
                query = query.Where(x => x.Url == req.Url);
            }

            var pageResult = await query.PaginateAsync(req.Page, req.Limit, new List<SortModel>());

            var resp = new DataPageResp<BlogResponse>()
            {
                TotalPages = pageResult.TotalPages,
                TotalItems = pageResult.TotalItems,
                CurrentPage = pageResult.CurrentPage,
                Data = _mapper.Map<List<BlogResponse>>(pageResult.Data)
            };

            return resp;
        }
    }
}
