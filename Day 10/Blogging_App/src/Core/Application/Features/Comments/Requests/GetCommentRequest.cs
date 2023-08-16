using System;
using MediatR;
using Application.DTOs;

namespace Application.Features.Comments.Requests
{
    public class GetCommentRequest : IRequest<CommentDto>
    {
        public int Id { get; set; }
    }
}