using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnBlazor.Server.Services
{
    public class ServiceBase
    {
        protected string ResourceNotFoundMessage(string resourceName, Guid resourceUuid)
        {
            return $"{resourceName} with UUID {resourceUuid} does not exist";
        }
    }
}
