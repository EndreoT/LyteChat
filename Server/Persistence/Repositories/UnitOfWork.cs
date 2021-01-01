using System.Threading.Tasks;
using LyteChat.Server.Data.RepositoryInterface;
using LyteChat.Server.Persistence.Context;

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