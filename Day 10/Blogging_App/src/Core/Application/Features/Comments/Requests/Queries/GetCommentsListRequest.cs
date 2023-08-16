using System;
using MediatR;
using Application.DTOs.Comments;

namespace Application.Features.Comments.Requests.Queries
{
    public class GetCommentsListRequest : IRequest<List<CommentDto>>
    {}
}