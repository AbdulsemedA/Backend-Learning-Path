using System;

namespace Application.DTOs.Common
{
    public class BaseEntityDto
    {
        public int id {get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}