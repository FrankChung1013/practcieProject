using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Practice.Common.Extensions;

public static class DataPageExtension
{
    /// <summary>
    /// 查詢分頁
    /// </summary>
    /// <param name="query"></param>
    /// <param name="page"></param>
    /// <param name="limit"></param>
    /// <param name="sortModels"></param>
    /// <typeparam name="TModel"></typeparam>
    /// <returns></returns>
    public static async Task<PagesModel<TModel>> PaginateAsync<TModel>(this IQueryable<TModel> query, int page, int limit, IEnumerable<SortModel> sortModels)
        where TModel : class
    {
        var paged = new PagesModel<TModel>();

        page = (page < 0) ? 1 : page;

        paged.CurrentPage = page;
        paged.PageSize = limit;

        var totalItemsCount = await query.CountAsync();

        var startRow = (page - 1) * limit;
        paged.Data = await query
            .OrderBy(sortModels)
            .Skip(startRow)
            .Take(limit)
            .ToListAsync();

        paged.TotalItems = totalItemsCount;
        paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);

        return paged;
    }

    /// <summary>
    /// 排序用
    /// </summary>
    /// <param name="source"></param>
    /// <param name="sortModels"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, IEnumerable<SortModel> sortModels)
    {
        var expression = source.Expression;
        int count = 0;
        foreach (var item in sortModels)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var selector = Expression.PropertyOrField(parameter, item.ColName);

            var method = string.Equals(item.Sort, "desc", StringComparison.OrdinalIgnoreCase) ?
                (count == 0 ? "OrderByDescending" : "ThenByDescending") :
                (count == 0 ? "OrderBy" : "ThenBy");

            expression = Expression.Call(typeof(Queryable), method,
                new Type[] { source.ElementType, selector.Type },
                expression, Expression.Quote(Expression.Lambda(selector, parameter)));

            count++;
        }

        return count > 0 ? source.Provider.CreateQuery<T>(expression) : source;
    }
}