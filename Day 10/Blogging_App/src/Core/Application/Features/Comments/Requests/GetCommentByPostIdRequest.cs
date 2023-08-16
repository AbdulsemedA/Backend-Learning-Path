using System;
using MediatR;
using Application.DTOs.Posts;

namespace Application.Features.Comments.Requests
{
    public class GetCommentByPostIdRequest : IRequest<PostDto>
    {
        public int Id { get; set; }
    }
}