namespace Practice.Response;

public class DataPageResp<T>
{
    /// <summary>
    /// 目前在哪一頁
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// 總共有幾筆資料
    /// </summary>
    public int TotalItems { get; set; }

    /// <summary>
    /// 總共有幾頁
    /// </summary>
    public int TotalPages { get; set; }

    public IEnumerable<T> Data { get; set; }
}