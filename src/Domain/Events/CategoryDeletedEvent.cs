namespace ModsenCatalog.src.Domain.Events
{
    public class CategoryDeletedEvent
    {
        public string? CategoryName { get; }

        public CategoryDeletedEvent(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
