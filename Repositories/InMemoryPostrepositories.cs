using SocialMediaApp.Models;

namespace SocialMediaApp.Repositories
{
    public class InMemoryPostRepository : IPostRepository
    {
        private readonly List<Post> _posts = new();
        private int _nextId = 1;

        public IEnumerable<Post> GetAll() => _posts;

        public Post? GetById(int id) => _posts.FirstOrDefault(p => p.Id == id);

        public void Create(Post post)
        {
            post.Id = _nextId++;
            _posts.Add(post);
        }

        public void Update(Post post)
        {
            var existing = GetById(post.Id);
            if (existing is not null)
            {
                existing.Content = post.Content;
                existing.UserId = post.UserId;
            }
        }

        public void Delete(int id) => _posts.RemoveAll(p => p.Id == id);
    }
}
