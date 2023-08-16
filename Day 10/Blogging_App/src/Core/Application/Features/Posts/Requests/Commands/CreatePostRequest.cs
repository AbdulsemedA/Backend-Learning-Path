using System;
using MediatR;

namespace Application.Features.Posts.Requests.Commands
{
    public class CreatePostRequest : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        
    }
}