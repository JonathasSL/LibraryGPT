namespace LibraryAPI.Domain.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; protected set; }
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public DateTime? RemovedOn { get; set; }
    }
}
