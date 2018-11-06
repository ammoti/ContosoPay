using Contoso.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static Contoso.Data.Abstract.IRepositories;

namespace Contoso.Data.Repositories
{
    public class OperationRepository : EntityBaseRepository<Operation>, IOperationRepository
    {
        public OperationRepository(ContosoContext context)
            : base(context)
        { }
    }
}
