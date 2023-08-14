using System;
using Domain.Common;

namespace Domain
{
    public class Comment : BaseEntity
    {
        public string? Text { get; set; }
        public int PostId { get; set; }
    }
}