namespace Practice.Common.Extensions;

public class PagesModel<T>
{
    const int MaxPageSize = 500;

    private int _pageSize;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

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

    public IList<T> Data { get; set; }

    public PagesModel()
    {
        Data = new List<T>();
    }
}

public class SortModel
{
    /// <summary>
    /// 欄位名稱: CreateDate / Id / SeqNo
    /// </summary>
    public string ColName { get; set; }

    /// <summary>
    /// asc / desc
    /// </summary>
    public string Sort { get; set; }
}