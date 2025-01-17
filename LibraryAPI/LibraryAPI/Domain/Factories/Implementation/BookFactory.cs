using LibraryAPI.Application.Models;

namespace LibraryAPI.Domain.Factories.Implementation
{
    public class BookFactory : IFactory<Book>
    {
        private string _title;
        private string _author;

        public BookFactory(string title, string author)
        {
            _title = title;
            _author = author;
        }

        public Book Create()
        {
            return new Book()
            {
                Title = _title,
                Author = _author,
                IsAvailable = true
            };
        }
    }
}
