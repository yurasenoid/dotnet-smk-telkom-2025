using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Dtos;
using SocialMediaApp.Services;

namespace SocialMediaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostService _service;

        public PostController(PostService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = _service.GetById(id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePostDto dto)
        {
            _service.Create(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreatePostDto dto)
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
