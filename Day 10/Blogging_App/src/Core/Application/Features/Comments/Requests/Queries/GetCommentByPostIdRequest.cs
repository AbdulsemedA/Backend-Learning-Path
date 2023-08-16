using System;
using MediatR;
using Application.DTOs.Comments;

namespace Application.Features.Comments.Requests.Queries
{
    public class GetCommentByPostIdRequest : IRequest<List<CommentDto>>
    {
        public int Id { get; set; }
    }
}