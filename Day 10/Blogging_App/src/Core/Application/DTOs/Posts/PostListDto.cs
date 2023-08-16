using System;
using Application.DTOs.Common;

namespace Application.DTOs.Posts
{
    public class PostListDto : BaseEntityDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}