using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Domain.Entities
{
    public class BaseEntity<TId> where TId : struct
    {
        public TId Id { get; protected set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime? RemovedOn { get; set; }

        public BaseEntity()
        {
            Id = GenerateId();
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
            RemovedOn = null;
        }

        private TId GenerateId()
        {
            return typeof(TId) switch
            {
                Type t when t == typeof(Guid) => (TId)(object)Guid.NewGuid(),
                Type t when t == typeof(int) => default,
                Type t when t == typeof(long) => default,
                _ => throw new InvalidOperationException($"Tipo de ID {typeof(TId).Name} não suportado.")
            };
        }

        protected void SetAsUpdated() => LastModifiedDate = DateTime.UtcNow;
    }
}
