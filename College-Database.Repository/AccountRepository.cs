using College_Database.Contracts;
using College_Database.Core.Database;
using College_Database.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace College_Database.Repository
{
    public class AccountRepository : RepositoryBase<User>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { 
        }
    }
}
