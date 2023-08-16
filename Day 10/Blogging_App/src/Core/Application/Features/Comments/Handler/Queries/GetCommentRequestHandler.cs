using System;
using MediatR;
using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Application.Persistence.Contracts;
using AutoMapper;
using Application.Features.Comments.Requests;


namespace Application.Features.Comments.Handler.Queries
{
    public class GetCommentRequestHandler : IRequestHandler<GetCommentRequest, CommentDto>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetCommentRequestHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<CommentDto> Handle(GetCommentRequest request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetById(request.Id);
            return _mapper.Map<CommentDto>(comment);
        }

    }
}