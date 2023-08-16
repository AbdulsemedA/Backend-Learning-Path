using System;
using MediatR;
using Application.DTOs.Comments;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Application.Persistence.Contracts;
using AutoMapper;
using Application.Features.Comments.Requests.Queries;

namespace Application.Features.Comments.Handler.Queries
{
    public class GetCommentsListRequestHandler : IRequestHandler<GetCommentsListRequest, List<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetCommentsListRequestHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<List<CommentDto>> Handle(GetCommentsListRequest request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAll();
            return _mapper.Map<List<CommentDto>>(comments);
        }

    }
}