using System.Threading.Tasks;
using LearnBlazor.Server.Data.RepositoryInterface;
using LearnBlazor.Server.Persistence.Context;

namespace LearnBlazor.Server.Persistence.Repositories
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