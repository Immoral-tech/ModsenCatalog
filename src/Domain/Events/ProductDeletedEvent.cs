namespace ModsenCatalog.src.Domain.Events
{
    public class ProductDeletedEvent
    {
        public Guid ProductId { get; }
        public string? ProductName { get; }
        
        public ProductDeletedEvent(Guid productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
        }
    }
}
