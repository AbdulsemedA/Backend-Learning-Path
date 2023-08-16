using System;
using MediatR;

namespace Application.Features.Comments.Requests.Commands
{
    public class CreateCommentRequest : IRequest<int>
    {
        public string Content { get; set; }
        public int PostId { get; set; }
    }
}