using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineLibrary.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminCategoriesController : Controller
    {
        public IActionResult Add()
        {
            // Check if category with that name and parent already exists
            return View();
        }
    }
}
