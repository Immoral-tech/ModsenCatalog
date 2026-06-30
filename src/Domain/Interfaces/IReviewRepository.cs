using ModsenCatalog.src.Domain.Entities;

namespace ModsenCatalog.src.Domain.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<IEnumerable<Review>> GetByProductIdAsync(int productId);
        Task<IEnumerable<Review>> GetActiveByProductIdAsync(int productId);
        Task<Review?> GetByUserAndProductAsync(Guid userId, int productId);
    }
}
