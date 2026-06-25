namespace ModsenCatalog.src.Domain.Events
{
    public class ReviewDeletedEvent
    {
        public Guid ReviewId { get; }
        public Guid ProductId { get; }

        public ReviewDeletedEvent (Guid reviewId, Guid productId)
        {
            ReviewId = reviewId;
            ProductId = productId;
        }
    }
}
