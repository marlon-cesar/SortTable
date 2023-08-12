using Microsoft.AspNetCore.Mvc;
using SortTable.Models;

namespace SortTable.Components
{
    public class PaginatorViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(SortTableModel model)
        {
            return View(model);
        }
    }
}
