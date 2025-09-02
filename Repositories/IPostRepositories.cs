using SocialMediaApp.Models;

namespace SocialMediaApp.Repositories
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        Post? GetById(int id);
        void Create(Post post);
        void Update(Post post);
        void Delete(int id);
    }
}
