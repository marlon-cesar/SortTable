namespace SortTable.Models
{
    public class SortTableOptions
    {
        public SortTableOptions(Type modelType, string controller, string action, string sortProperty, bool sortAscending, string formFilterId = null)
        {
            ModelType = modelType;
            Controller = controller;
            Action = action;
            SortProperty = sortProperty;
            SortAscending = sortAscending;
            FormFilterId = formFilterId;
        }

        public Type ModelType { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string SortProperty { get; set; }
        public bool SortAscending { get; set; }
        public string FormFilterId { get; set; }
    }
}
