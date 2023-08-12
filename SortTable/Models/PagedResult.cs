namespace SortTable.Models
{
    public class PagedResult<TEntity>
    {
        public PagedResult()
        {

        }

        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public List<TEntity> Items { get; set; }
    }
}
