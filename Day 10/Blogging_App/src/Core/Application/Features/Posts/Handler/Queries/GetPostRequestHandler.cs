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
    public class GetPostRequestHandler : IRequestHandler<GetPostRequest, PostDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public GetPostRequestHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<PostDto> Handle(GetPostRequest request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetById(request.Id);
            return _mapper.Map<PostDto>(post);
        }

    }
}