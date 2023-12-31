using System;
using MediatR;
using Domain;
// using Application.DTOs.Comments;
using Application.DTOs.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Application.Persistence.Contracts;
using AutoMapper;
using Application.Features.Comments.Requests.Commands;

namespace Application.Features.Comments.Handler.Commands
{
    public class CreateCommentRequestHandler : IRequestHandler<CreateCommentRequest, int>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CreateCommentRequestHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(request.CreateCommentDto);
            await _commentRepository.Add(comment);
            return comment.Id;
        }
    }
}