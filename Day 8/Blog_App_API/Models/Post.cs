using System;
namespace Blog_App_API.Models;

public class Post
{
    public int PostId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<Comment>? Comments { get; set; }

}
