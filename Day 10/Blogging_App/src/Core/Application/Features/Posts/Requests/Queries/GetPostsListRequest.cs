using System;
using MediatR;
using Application.DTOs.Posts;

namespace Application.Features.Posts.Requests.Queries
{
    public class GetPostsListRequest : IRequest<List<PostListDto>>
    {}
}