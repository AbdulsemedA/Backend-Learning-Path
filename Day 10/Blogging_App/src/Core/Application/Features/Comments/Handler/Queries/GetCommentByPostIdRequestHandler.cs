using System;
using MediatR;
using Application.DTOs.Comments;
using Application.Features.Comments.Requests.Queries;
using Application.Persistence.Contracts;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;


namespace Application.Features.Comments.Handler.Queries
{
    public class GetCommentByPostIdRequestHandler : IRequestHandler<GetCommentByPostIdRequest, List<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetCommentByPostIdRequestHandler(ICommentRepository commentRepository , IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<List<CommentDto>> Handle(GetCommentByPostIdRequest request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetCommentsByPostId(request.Id);
            return _mapper.Map<List<CommentDto>>(comments);
        }
    }
}