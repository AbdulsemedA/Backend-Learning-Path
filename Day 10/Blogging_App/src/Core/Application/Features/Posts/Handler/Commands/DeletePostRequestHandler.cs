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
    public class DeletePostRequestHandler : IRequestHandler<DeletePostRequest, Unit>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public DeletePostRequestHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeletePostRequest request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetById(request.Id);
            await _postRepository.Delete(post.Id);
            return Unit.Value;
        }
    }
}