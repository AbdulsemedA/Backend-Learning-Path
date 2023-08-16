using System;
using MediatR;
using Application.DTOs;

namespace Application.Features.Comments.Requests
{
    public class GetCommentByPostIdRequest : IRequest<List<CommentDto>>
    {
        public int Id { get; set; }
    }
}