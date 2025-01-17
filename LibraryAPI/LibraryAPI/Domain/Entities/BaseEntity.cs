namespace LibraryAPI.Domain.Entities
{
    public class BaseEntity<TId>
    {
        public TId Id { get; protected set; }
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public DateTime? RemovedOn { get; set; }
    }
}
