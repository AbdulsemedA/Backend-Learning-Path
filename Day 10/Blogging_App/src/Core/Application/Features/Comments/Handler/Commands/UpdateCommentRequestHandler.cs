using System;
using MediatR;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Application.Persistence.Contracts;
using AutoMapper;
using Application.Features.Comments.Requests.Commands;

namespace Application.Features.Comments.Handler.Commands
{
    public class UpdateCommentRequestHandler : IRequestHandler<UpdateCommentRequest, Unit>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public UpdateCommentRequestHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetById(request.UpdateCommentDto.Id);
            _mapper.Map(request.UpdateCommentDto, comment);
            await _commentRepository.Update(comment.Id, comment);
            return Unit.Value;
        }
    }
}