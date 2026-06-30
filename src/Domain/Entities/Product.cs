namespace ModsenCatalog.src.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal AverageRating { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<PriceHistory> PriceHistories { get; set; } = new List<PriceHistory>();
    }
}
