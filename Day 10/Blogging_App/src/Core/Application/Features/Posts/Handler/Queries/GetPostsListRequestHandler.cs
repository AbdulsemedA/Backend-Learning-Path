using System;
using Application.DTOs.Posts;
using Application.Features.Posts.Requests.Queries;
using Application.Persistence.Contracts;
using MediatR;
using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;



namespace Application.Features.Posts.Handler.Queries
{
    public class GetPostsListRequestHandler : IRequestHandler<GetPostsListRequest, List<PostListDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public GetPostsListRequestHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<List<PostListDto>> Handle(GetPostsListRequest request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAll();
            return _mapper.Map<List<PostListDto>>(posts);
        }

    }
}