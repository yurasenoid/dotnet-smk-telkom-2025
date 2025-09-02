using BookstoreApp.Dtos;
using BookstoreApp.Models;
using BookstoreApp.Repositories;

namespace BookstoreApp.Services
{
    public class BookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BookResultDto> GetAll()
        {
            return _repository.GetAll().Select(b => new BookResultDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Price = b.Price
            });
        }

        public BookResultDto? GetById(int id)
        {
            var book = _repository.GetById(id);
            if (book == null) return null;
            return new BookResultDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            };
        }

        public void Create(CreateBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Price = dto.Price
            };
            _repository.Create(book);
        }

        public bool Update(int id, CreateBookDto dto)
        {
            var book = _repository.GetById(id);
            if (book == null) return false;
            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Price = dto.Price;
            _repository.Update(book);
            return true;
        }

        public bool Delete(int id)
        {
            var book = _repository.GetById(id);
            if (book == null) return false;
            _repository.Delete(id);
            return true;
        }
    }
}
