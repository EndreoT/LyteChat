using System;
using System.Threading.Tasks;
using LearnBlazor.Server.Persistence.Context;


namespace LearnBlazor.Server.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}


