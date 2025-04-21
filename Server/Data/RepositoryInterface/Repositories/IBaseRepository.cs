using System;
using System.Threading.Tasks;

namespace LyteChat.Server.Data.RepositoryInterface.Repositories
{
    public interface IBaseRepository<T>
    {
        public Task<T?> GetByUuidAsync(Guid uuid);
    }
}
