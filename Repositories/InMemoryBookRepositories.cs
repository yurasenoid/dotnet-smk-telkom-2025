using BookstoreApp.Models;

namespace BookstoreApp.Repositories
{
    public class InMemoryBookRepository : IBookRepository
    {
        private readonly List<Book> _books = new();
        private int _nextId = 1;

        public IEnumerable<Book> GetAll() => _books;

        public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void Create(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
        }

        public void Update(Book book)
        {
            var existing = GetById(book.Id);
            if (existing is not null)
            {
                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.Price = book.Price;
            }
        }

        public void Delete(int id) => _books.RemoveAll(b => b.Id == id);
    }
}
