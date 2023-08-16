using System;
using MediatR;
using Application.DTOs.Posts;

namespace Application.Features.Posts.Requests
{
    public class GetPostRequest : IRequest<PostDto>
    {
        public int Id { get; set; }
    }
}