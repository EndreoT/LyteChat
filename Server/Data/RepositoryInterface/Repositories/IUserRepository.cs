﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Server.Data.Models;

namespace LearnBlazor.Server.Data.RepositoryInterface.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetAnonymousUserAsync();
    }
}
