using System;
using MediatR;
using Application.DTOs.Posts;

namespace Application.Features.Posts.Requests.Commands
{
    public class UpdatePostRequest : IRequest<Unit>
    {
        public UpdatePostDto UpdatePostDto { get; set; }
                  
    }
}