namespace ModsenCatalog.src.Domain.Entities
{
    public class PriceHistory : BaseEntity
    {
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public DateTime ChangedAt { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}