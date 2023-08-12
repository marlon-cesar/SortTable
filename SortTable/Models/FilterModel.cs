namespace SortTable.Models
{
    public class FilterModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; } = 10;
        public string? SortProperty { get; set; }
        public bool SortAscending { get; set; }
    }
}
