using System;
using MediatR;
using Application.DTOs;

namespace Application.Features.Comments.Requests
{
    public class GetCommentsListRequest : IRequest<List<CommentDto>>
    {}
}