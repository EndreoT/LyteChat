using System;
using System.Threading.Tasks;
using LyteChat.Server.Persistence.Context;


namespace LyteChat.Server.Persistence.Repositories
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


