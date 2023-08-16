using System;
using Application.DTOs.Common;

namespace Application.DTOs.Comments
{
    public class UpdateCommentDto : BaseEntityDto
    {
        public string Text { get; set; }
    }
}