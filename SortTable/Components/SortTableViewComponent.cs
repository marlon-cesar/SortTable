using Microsoft.AspNetCore.Mvc;
using SortTable.Helpers;
using SortTable.Models;
using System.Reflection;

namespace SortTable.Components
{
    public class SortTableViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(dynamic pagedResult, SortTableOptions options)
        {
            var properties = new List<PropertyInfo>(options.ModelType.GetProperties());

            var model = new SortTableModel()
            {
                TotalItems = pagedResult.TotalItems,
                TotalPages = pagedResult.TotalPages,
                Page = pagedResult.Page,
                Controller = options.Controller,
                Action = options.Action,
                SortProperty = options.SortProperty,
                SortAscending = options.SortAscending,
                FormFilterId = options.FormFilterId
            };

            foreach (var item in properties)
            {
                if (item.GetCustomAttribute(typeof(HiddenInputAttribute), false) != null)
                    continue;

                var property = new SortTableProperty
                {
                    Name = item.Name,
                    DisplayName = item.GetDisplayName(),
                    PropertyType = item.PropertyType
                };
                model.Properties.Add(property);
            }


            foreach (var item in pagedResult.Items)
            {
                var sortTableItem = new SortTableItemsModel();

                foreach (var property in properties.Where(x => model.Properties.Any(p => p.Name.Equals(x.Name))))
                {
                    var value = string.Empty;

                    if (property.PropertyType is DateTime)
                        value = ((DateTime?)property.GetValue(item, null))?.ToString("dd/MM/yyyy");
                    else
                        value = ((object)property.GetValue(item, null))?.ToString();

                    sortTableItem.Values.Add(value);
                }

                model.Items.Add(sortTableItem);
            }


            return View(model);
        }
    }
}
