using System;
using Application.DTOs.Common;

namespace Application.DTOs.Posts
{
    public class CreatePostDto : BaseEntityDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}