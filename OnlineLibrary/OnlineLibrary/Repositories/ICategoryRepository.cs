using OnlineLibrary.Models.Domain;

namespace OnlineLibrary.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetAsync(Guid id);
        Task<Category> AddAsync(Category category);
        Task<Category?> UpdateAsync(Guid id);
        Task<Category?> DeleteAsync(Guid id);
    }
}
