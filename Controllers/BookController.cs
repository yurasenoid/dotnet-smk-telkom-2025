using Microsoft.AspNetCore.Mvc;
using BookstoreApp.Dtos;
using BookstoreApp.Services;

namespace BookstoreApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _service;

        public BookController(BookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _service.GetById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateBookDto dto)
        {
            _service.Create(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateBookDto dto)
        {
            var updated = _service.Update(id, dto);
            if (!updated) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted) return NotFound();
            return Ok();
        }
    }
}
