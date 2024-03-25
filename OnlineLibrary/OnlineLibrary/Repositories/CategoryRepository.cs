using OnlineLibrary.Data;
using OnlineLibrary.Models.Domain;

namespace OnlineLibrary.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LibraryDbContext libraryDbContext;

        public CategoryRepository(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public Task<Category> AddAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> UpdateAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
