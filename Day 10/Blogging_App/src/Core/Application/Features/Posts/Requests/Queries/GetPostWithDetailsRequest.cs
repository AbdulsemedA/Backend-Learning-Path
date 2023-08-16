using System;
using Application.DTOs.Posts;
using MediatR;

namespace Application.Features.Posts.Requests.Queries
{
    public class GetPostWithDetailsRequest : IRequest<PostDto>
    {
        public int Id { get; set; }
    }
}