namespace ModsenCatalog.src.Domain.Events
{
    public class ReviewAddedEvent
    {
        public Guid ReviewId { get; }
        public Guid ProductId { get; }
        public Guid UserId { get; }

        public ReviewAddedEvent(Guid reviewId, Guid productId, Guid userId)
        {
            ReviewId = reviewId;
            ProductId = productId;
            UserId = userId;
        }
    }
}
