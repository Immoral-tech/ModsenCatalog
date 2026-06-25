namespace ModsenCatalog.src.Domain.Events
{
    public class PriceChangedEvent
    {
        public Guid ProductId { get; }
        public string ProductName { get; }
        public decimal OldPrice { get; }
        public decimal NewPrice { get; }

        public PriceChangedEvent(Guid productId, string productName, decimal oldPrice, decimal newPrice)
        {
            ProductId = productId;
            ProductName = productName;
            OldPrice = oldPrice;
            NewPrice = newPrice;
        }
    }
}
