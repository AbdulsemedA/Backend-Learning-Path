using System;
using Application.DTOs.Common;

namespace Application.DTOs.Comments
{
    public class CreateCommentDto
    {
        public string Text { get; set; }
        public int PostId { get; set; }
    }
}