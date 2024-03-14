using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Models.ViewModels;

namespace OnlineLibrary.Controllers
{
    public class BrowseBooksController : Controller
    {
        [HttpGet]
        public IActionResult Browse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Browse(BrowseBooksRequest browseBooksRequest)
        {
            string searchQuery = browseBooksRequest.SearchQuery;
            System.Diagnostics.Debug.WriteLine(searchQuery);
            return View();
        }
    }
}
