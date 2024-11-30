using LyteChat.Server.Data.RepositoryInterface;
using LyteChat.Server.Persistence.Context;
using System.Threading.Tasks;

namespace LyteChat.Server.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}