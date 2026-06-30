using ModsenCatalog.src.Domain.Enums;

namespace ModsenCatalog.src.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
