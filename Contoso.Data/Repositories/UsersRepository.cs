using Contoso.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static Contoso.Data.Abstract.IRepositories;

namespace Contoso.Data.Repositories
{
    public class UsersRepository : EntityBaseRepository<Users>, IUsersRepository
    {
        public UsersRepository(ContosoContext context)
            : base(context)
        { }
    }
}
