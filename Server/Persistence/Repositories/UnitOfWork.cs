using System.Threading.Tasks;
using LearnBlazor.Data.RepositoryInterface;
using LearnBlazor.Persistence.Context;

namespace LearnBlazor.Persistence.Repositories
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