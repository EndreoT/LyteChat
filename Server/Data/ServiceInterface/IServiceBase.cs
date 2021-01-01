using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyteChat.Server.Data.ServiceInterface
{
    public interface IServiceBase<T>
    {
        public Task<T> GetByUuidAsync(Guid uuid);
    }
}
