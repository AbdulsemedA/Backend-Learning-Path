using System;
using MediatR;
using Application.DTOs;
using Application.Features.Comments.Requests;
using Application.Persistence.Contracts;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;


namespace Application.Features.Comments.Handler.Queries
{
    public class GetCommentByIdRequestHandler : IRequestHandler<GetCommentByIdRequest, PostDto>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetCommentByPostIdRequestHandler(IPostRepository postRepository , IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<PostDto> Handle(GetCommentByIdRequest request, CancellationToken cancellationToken)
        {
            var post = await _commentRepository.GetById(request.Id);
            return _mapper.Map<PostDto>(post.Comments);
    }
}