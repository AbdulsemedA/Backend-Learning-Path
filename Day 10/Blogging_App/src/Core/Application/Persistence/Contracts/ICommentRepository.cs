using System;
using Domain;

namespace Application.Persistence.Contracts
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsByPostId(int postId);
    }
}