using Microsoft.EntityFrameworkCore;
using ModsenCatalog.src.Domain.Entities;
using ModsenCatalog.src.Domain.Interfaces;

namespace ModsenCatalog.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _dbSet
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}