using Practice.Models;
using Practice.Request;
using Practice.Response;

namespace Practice.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {

        public MappingProfile()
        {
            CreateMap<Blog, BlogResponse>();
            CreateMap<BlogRequest, Blog>();
        }
    }
}
