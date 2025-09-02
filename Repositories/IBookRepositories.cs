using BookstoreApp.Models;

namespace BookstoreApp.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book? GetById(int id);
        void Create(Book book);
        void Update(Book book);
        void Delete(int id);
    }
}
