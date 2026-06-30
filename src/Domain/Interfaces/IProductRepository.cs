using ModsenCatalog.src.Domain.Entities;

namespace ModsenCatalog.src.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> SearchByNameAsync(string searchTerm);
        Task<IEnumerable<Product>> GetFilteredAsync(
            int? categoryId = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            decimal? minRating = null);
    }
}
