using BookStore.Domain.Entities;
using BookStore.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookStore.Persistence
{
    public interface IApplicationDbContext
    {
        IRepository<Books> Books { get; }
        Task<int> SaveChangesAsync();
    }
}
