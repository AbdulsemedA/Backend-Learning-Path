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
    public class UpdatePostRequestHandler : IRequestHandler<UpdatePostRequest, Unit>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public UpdatePostRequestHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdatePostRequest request, CancellationToken cancellationToken)
        {
            var post = _postRepository.GetById(request.UpdatePostDto.Id);
            _mapper.Map(request.UpdatePostDto, post);
            await _postRepository.Update(post);
            return Unit.Value;
        }

    }
}