using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Models.ViewModels;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Web;

namespace OnlineLibrary.Controllers
{
    public class BrowseBooksController: Controller
    {
        public JsonResult? jsonData;
        [HttpGet]
        public IActionResult Browse()
        {
            if (jsonData != null)
            {
                System.Diagnostics.Debug.WriteLine("[HttpGet] I have received data: " + jsonData.Value);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Browse(string stringified)
        {
            jsonData = Json(new { data = stringified });
            System.Diagnostics.Debug.WriteLine("[HttpPost] I have received data: " + jsonData.Value);
            System.Diagnostics.Debug.WriteLine("[HttpPost] I have received data: " + stringified);

            return View();
        }
    }
}
