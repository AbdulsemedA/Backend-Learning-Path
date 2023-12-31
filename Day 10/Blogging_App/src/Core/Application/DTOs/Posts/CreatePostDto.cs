using System;
using Application.DTOs.Common;
using Application.DTOs.Comments;

namespace Application.DTOs.Posts
{
    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<CommentDto>? Comments { get; set; } = new List<CommentDto>();
    }
}