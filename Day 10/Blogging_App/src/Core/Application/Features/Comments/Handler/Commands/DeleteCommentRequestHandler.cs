using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Application.Persistence.Contracts;
using Application.Features.Comments.Requests.Commands;
using Domain;

namespace Application.Features.Comments.Handler.Commands
{
    public class DeleteCommentRequestHandler : IRequestHandler<DeleteCommentRequest, Unit>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public DeleteCommentRequestHandler(IMapper mapper, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public async Task<Unit> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            var commentToDelete = await _commentRepository.GetById(request.Id);

            await _commentRepository.Delete(commentToDelete.Id);

            return Unit.Value;
        }
    }
}