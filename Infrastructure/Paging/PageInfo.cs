namespace Infrastructure.Paging
{
    public class PageInfo
    {
        const int MaxPageSize = 1000;
        public int Page { get; set; } = 1;
        public int PageSize = 20;

        //public int PageSize
        //{
        //    get => _pageSize;
        //    set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        //}
    }
}
