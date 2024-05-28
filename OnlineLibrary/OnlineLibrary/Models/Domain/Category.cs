using OnlineLibrary.Models.ViewModels;

namespace OnlineLibrary.Models.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? parentCategoryId { get; set;}
        public ICollection<BookViewModel> Books { get; set; }

    }
}
