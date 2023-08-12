using Microsoft.AspNetCore.Mvc;
using SortTable.Models;

namespace SortTable.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private List<UserModel> _users => new List<UserModel>
        {
            new UserModel(1, "Test 1", 1),
            new UserModel(2, "Test 2", 2),
            new UserModel(3, "Test 3", 3),
            new UserModel(4, "Test 4", 4),
            new UserModel(5, "Test 5", 5),
            new UserModel(6, "Test 6", 6),
            new UserModel(7, "Test 7", 7),
            new UserModel(8, "Test 8", 8),
            new UserModel(9, "Test 9", 9),
            new UserModel(10, "Test 10", 10),
            new UserModel(11, "Test 11", 11),
            new UserModel(12, "Test 12", 12),
            new UserModel(13, "Test 13", 13),
            new UserModel(14, "Test 14", 14),
            new UserModel(15, "Test 15", 15),
        };


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = SearchUser(new UserFilterModel
            {
                Page = 1,
                PageSize = 10
            });

            return View(model);
        }

        [HttpPost]
        public IActionResult FilterUsers([FromBody] UserFilterModel filterModel)
        {

            ViewData["SortProperty"] = filterModel.SortProperty;
            ViewData["SortAscending"] = filterModel.SortAscending;

            return PartialView("_UserTableResult", SearchUser(filterModel));
        }


        private PagedResult<UserModel> SearchUser(UserFilterModel filterModel)
        {
            var result = new PagedResult<UserModel>()
            {
                Page = filterModel.Page,
                PageSize = filterModel.PageSize
            };

            var users = _users.Where(u => string.IsNullOrEmpty(filterModel.Name) || u.Name.Contains(filterModel.Name, StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrEmpty(filterModel.SortProperty))
            {
                switch (filterModel.SortProperty.ToLower().Trim())
                {
                    case "name":
                        users = filterModel.SortAscending ? users.OrderBy(u => u.Name) : users.OrderByDescending(u => u.Name);
                        break;
                    case "document":
                        users = filterModel.SortAscending ? users.OrderBy(u => u.Document) : users.OrderByDescending(u => u.Document);
                        break;
                }
            }

            result.TotalItems = users.Count();
            result.TotalPages = (int)Math.Ceiling((decimal)users.Count() / (decimal)filterModel.PageSize);

            users = users
                .Skip((filterModel.Page - 1) * filterModel.PageSize)
                .Take(filterModel.PageSize);

            result.Items = users.ToList();

            return result;
        }

    }
}