using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnBlazor.Server.Data.RepositoryInterface.Repositories
{
    public interface IBaseRepository<T>
    {
        public Task<T> GetByUuid(Guid uuid);
    }
}
