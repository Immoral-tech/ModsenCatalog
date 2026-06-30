using Microsoft.EntityFrameworkCore;
using ModsenCatalog.src.Domain.Entities;
using ModsenCatalog.src.Domain.Interfaces;

namespace ModsenCatalog.Infrastructure.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<Review>> GetByProductIdAsync(int productId)
        {
            return await _dbSet
                .Include(r => r.User)
                .Where(r => r.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetActiveByProductIdAsync(int productId)
        {
            var thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);
            return await _dbSet
                .Include(r => r.User)
                .Where(r => r.ProductId == productId && r.CreatedAt >= thirtyDaysAgo)
                .ToListAsync();
        }

        public async Task<Review?> GetByUserAndProductAsync(Guid userId, int productId)
        {
            return await _dbSet
                .FirstOrDefaultAsync(r => r.UserId == userId && r.ProductId == productId);
        }
    }
}