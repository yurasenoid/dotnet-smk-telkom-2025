namespace SocialMediaApp.Dtos
{
    public class CreatePostDto
    {
        public string Content { get; set; } = string.Empty;
        public int UserId { get; set; }
    }

    public class PostResultDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}
