using Microsoft.EntityFrameworkCore;
using ModsenCatalog.src.Domain.Entities;
using ModsenCatalog.src.Domain.Interfaces;

namespace ModsenCatalog.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string searchTerm)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Where(p => EF.Functions.Like(p.Name.ToLower(), $"%{searchTerm.ToLower()}%"))
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetFilteredAsync(
            int? categoryId = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            decimal? minRating = null)
        {
            var query = _dbSet.Include(p => p.Category).AsQueryable();

            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId.Value);

            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            if (minRating.HasValue)
                query = query.Where(p => p.AverageRating >= minRating.Value);

            return await query.ToListAsync();
        }
    }
}