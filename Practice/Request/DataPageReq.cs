using Practice.Common.Extensions;

namespace Practice.Request;

public class DataPageReq
{
    /// <summary>
    /// 查詢第幾頁
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// 每頁幾筆
    /// </summary>
    public int Limit { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public List<SortModel> SortModel { get; set; }
}