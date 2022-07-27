using Microsoft.AspNetCore.Mvc.RazorPages;
using Practice.Common.Extensions;

namespace Practice.Request;

public class BlogSearchRequest : DataPageReq
{
    public int? BlogId { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
}