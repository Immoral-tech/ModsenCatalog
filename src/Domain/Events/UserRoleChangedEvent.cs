using ModsenCatalog.src.Domain.Enums;

namespace ModsenCatalog.src.Domain.Events
{
    public class UserRoleChangedEvent
    {
        public Guid UserId { get; }
        public string? UserName { get; }
        public UserRole OldRole { get; }
        public UserRole NewRole { get; }

        public UserRoleChangedEvent(Guid userId, string userName, UserRole oldRole, UserRole newRole)
        {
            UserId = userId;
            UserName = userName;
            OldRole = oldRole;
            NewRole = newRole;

        }
    }
}
