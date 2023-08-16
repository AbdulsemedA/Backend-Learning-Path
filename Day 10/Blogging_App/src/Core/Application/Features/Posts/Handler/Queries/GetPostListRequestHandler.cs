using System;
using Application.DTOs.Posts;
using Application.Features.Posts.Requests;
using Application.Persistence.Contracts;
using MediatR;
using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;



namespace Application.Features.Posts.Handler.Queries
{
    public class GetPostListRequestHandler : IRequestHandler<GetPostsListRequest, List<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public GetPostListRequestHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<List<PostDto>> Handle(GetPostsListRequest request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAll();
            return _mapper.Map<List<PostDto>>(posts);
        }

    }
}