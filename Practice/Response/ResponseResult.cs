namespace Practice.Repository
{
    public class ResponseResult
    {
        public int Status { get; set; }
        public string Msg { get; set; } = string.Empty;
    }

    public class ResponseResult<T>
    {
        public int Status { get; set; }
        public string Msg { get; set; } = string.Empty;
        public T Data { get; set; }
    }
}
