namespace SortTable.Models
{
    public class SortTableModel
    {
        public SortTableModel()
        {
            Properties = new List<SortTableProperty>();
            Items = new List<SortTableItemsModel>();
        }

        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public string SortProperty { get; set; }
        public bool SortAscending { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string FormFilterId { get; set; }
        public List<SortTableProperty> Properties { get; set; }
        public List<SortTableItemsModel> Items { get; set; }
    }
    public class SortTableProperty
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public Type PropertyType { get; set; }
    }
    public class SortTableItemsModel
    {
        public SortTableItemsModel()
        {
            Values = new List<string>();
        }
        public List<string> Values { get; set; }
    }
}
