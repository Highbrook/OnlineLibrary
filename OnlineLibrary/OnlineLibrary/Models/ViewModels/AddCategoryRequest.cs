using OnlineLibrary.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models.ViewModels
{
    public class AddCategoryRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Category ParentCategory { get; set; }
    }
}
