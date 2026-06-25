namespace ModsenCatalog.src.Domain.Events
{
    public class UserLoggedEvent
    {
        public string? Username { get; }

        public UserLoggedEvent(string username)
        {
            Username = username;
        }
    }
}
