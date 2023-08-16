using System;
using MediatR;
using Application.DTOs.Posts;

namespace Application.Features.Posts.Requests
{
    public class GetPostsListRequest : IRequest<List<PostDto>>
    {}
}