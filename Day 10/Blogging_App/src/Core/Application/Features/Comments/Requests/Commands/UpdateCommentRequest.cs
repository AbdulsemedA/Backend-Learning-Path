using System;
using MediatR;
using Application.DTOs.Comments;

namespace Application.Features.Comments.Requests.Commands
{
    public class UpdateCommentRequest : IRequest<Unit>
    {
        public UpdateCommentDto UpdateCommentDto { get; set; }
    }
}