using ModsenCatalog.src.Domain.Entities;

public class PriceHistory
{
    public int Id { get; set; }
    public decimal OldPrice { get; set; }
    public decimal NewPrice { get; set; }
    public DateTime ChangedAt { get; set; }
    public int ProductId { get; set; }

    public Product Product { get; set; }
}