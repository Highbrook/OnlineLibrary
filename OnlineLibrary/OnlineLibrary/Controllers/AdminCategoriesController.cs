using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Data;
using OnlineLibrary.Models.Domain;
using OnlineLibrary.Models.ViewModels;

namespace OnlineLibrary.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminCategoriesController : Controller
    {
        private LibraryDbContext _libraryDbContext;

        public AdminCategoriesController(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        // Check if category with that name and parent already exists

        [HttpGet]
        public IActionResult Add()
        {
            // Fetch all categories from the database
            var categories = _libraryDbContext.categories.ToList();

            // Create a list of SelectListItem for the dropdown
            var categoryList = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            // Pass the category list to the view using ViewBag or ViewData
            ViewBag.Categories = new SelectList(categoryList, "Value", "Text");

            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddCategoryRequest addCategoryRequest)
        {
            if (addCategoryRequest.ParentCategory == null || addCategoryRequest.ParentCategory == "")
            {
                var category = new Category
                {
                    Id = Guid.NewGuid(),
                    Name = addCategoryRequest.Name,
                    Description = addCategoryRequest.Description,
                    parentCategoryId = null 
                    //parentCategoryChecked
                };
                _libraryDbContext.categories.Add(category);
                _libraryDbContext.SaveChanges();
                TempData["SuccessMessage"] = "New category " + addCategoryRequest.Name + " has been successfully added.";
            }
            else
            {
                var category = new Category
                {
                    Id = Guid.NewGuid(),
                    Name = addCategoryRequest.Name,
                    Description = addCategoryRequest.Description,
                    parentCategoryId = new Guid(addCategoryRequest.ParentCategory)
                };

                _libraryDbContext.categories.Add(category);
                _libraryDbContext.SaveChanges();
                TempData["SuccessMessage"] = "New category " + addCategoryRequest.Name + " has been successfully added.";
            }
            return View("Add");
        }
    }
}
