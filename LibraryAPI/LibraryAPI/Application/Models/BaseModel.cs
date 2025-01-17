namespace LibraryAPI.Application.Models
{
    public class BaseModel<T>
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
