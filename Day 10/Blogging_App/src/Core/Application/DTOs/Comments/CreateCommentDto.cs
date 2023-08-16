using System;
using Application.DTOs.Common;

namespace Application.DTOs.Comments
{
    public class CreateCommentDto : BaseEntityDto
    {
        public string Text { get; set; }
        public int PostId { get; set; }
    }
}