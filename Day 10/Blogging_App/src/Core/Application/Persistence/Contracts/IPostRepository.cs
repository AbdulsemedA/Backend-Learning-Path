using System;
using Domain;

namespace Application.Persistence.Contracts
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<Post> GetPostWithDetails(int id);
    }
}