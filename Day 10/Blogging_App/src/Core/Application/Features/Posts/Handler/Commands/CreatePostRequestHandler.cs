using System;
using MediatR;
using Domain;
using Application.DTOs.Comments;
using Application.DTOs.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Application.Persistence.Contracts;
using AutoMapper;
using Application.Features.Posts.Requests.Commands;


namespace Application.Features.Posts.Handler.Commands
{
    public class CreatePostRequestHandler : IRequestHandler<CreatePostRequest, int>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public CreatePostRequestHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Post>(request);
            await _postRepository.Add(post);
            return post.Id;
        }

    }
}