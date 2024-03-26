using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Add()
        {
            // Check if category with that name and parent already exists
            return View();
        }
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddCategoryRequest addCategoryRequest)
        {
            Guid guidParentCategory = Guid.NewGuid();
            string parentCategoryChecked = guidParentCategory.ToString();
            if (addCategoryRequest.ParentCategory == null || addCategoryRequest.ParentCategory == "")
            {
                var category = new Category
                {
                    Id = Guid.NewGuid(),
                    Name = addCategoryRequest.Name,
                    Description = addCategoryRequest.Description,
                    parentCategoryId = parentCategoryChecked
                };
                // Something is fucky wucky here
                _libraryDbContext.categories.Add(category);
                _libraryDbContext.SaveChanges();
            }
            else
            {
                var category = new Category
                {
                    Id = Guid.NewGuid(),
                    Name = addCategoryRequest.Name,
                    Description = addCategoryRequest.Description,
                    parentCategoryId = addCategoryRequest.ParentCategory
                };

                _libraryDbContext.categories.Add(category);
                _libraryDbContext.SaveChanges();
            }
            return View("Add");
        }
    }
}
