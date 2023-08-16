using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Posts;
using Application.Features.Posts.Requests;
using Application.Persistence.Contracts;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Posts.Handler.Queries
{
    public class GetPostWithDetailsRequestHandler : IRequestHandler<GetPostWithDetailsRequest, PostDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostWithDetailsRequestHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostDto> Handle(GetPostWithDetailsRequest request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetPostWithDetails(request.Id);
            return _mapper.Map<PostDto>(post);
        }
    }
}