using System;
using MediatR;
using Application.DTOs.Comments;

namespace Application.Features.Comments.Requests.Commands
{
    public class CreateCommentRequest : IRequest<int>
    {
        public CreateCommentDto CreateCommentDto { get; set; }
    }
}