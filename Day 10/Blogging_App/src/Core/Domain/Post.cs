using System;
using Domain.Common;

namespace Domain
{
    public class Post : BaseEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public ICollection<Comment>? Comments { get; set; }   
    }
}