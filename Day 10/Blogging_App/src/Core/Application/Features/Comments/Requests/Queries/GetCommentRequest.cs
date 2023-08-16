using System;
using MediatR;
using Application.DTOs.Comments;

namespace Application.Features.Comments.Requests.Queries
{
    public class GetCommentRequest : IRequest<CommentDto>
    {
        public int Id { get; set; }
    }
}