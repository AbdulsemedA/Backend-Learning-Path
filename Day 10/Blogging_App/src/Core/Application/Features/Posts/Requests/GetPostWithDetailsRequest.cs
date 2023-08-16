using System;
using Application.DTOs.Posts;
using MediatR;

namespace Application.Features.Posts.Requests
{
    public class GetPostWithDetailsRequest : IRequest<PostDto>
    {
        public int Id { get; set; }
    }
}