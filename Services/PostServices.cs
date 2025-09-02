using SocialMediaApp.Dtos;
using SocialMediaApp.Models;
using SocialMediaApp.Repositories;

namespace SocialMediaApp.Services
{
    public class PostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<PostResultDto> GetAll()
        {
            return _repository.GetAll().Select(p => new PostResultDto
            {
                Id = p.Id,
                Content = p.Content,
                Username = "Anonymous" // nanti bisa dihubungkan ke User
            });
        }

        public PostResultDto? GetById(int id)
        {
            var post = _repository.GetById(id);
            if (post == null) return null;
            return new PostResultDto
            {
                Id = post.Id,
                Content = post.Content,
                Username = "Anonymous"
            };
        }

        public void Create(CreatePostDto dto)
        {
            var post = new Post { Content = dto.Content, UserId = dto.UserId };
            _repository.Create(post);
        }

        public bool Update(int id, CreatePostDto dto)
        {
            var post = _repository.GetById(id);
            if (post == null) return false;
            post.Content = dto.Content;
            post.UserId = dto.UserId;
            _repository.Update(post);
            return true;
        }

        public bool Delete(int id)
        {
            var post = _repository.GetById(id);
            if (post == null) return false;
            _repository.Delete(id);
            return true;
        }
    }
}
