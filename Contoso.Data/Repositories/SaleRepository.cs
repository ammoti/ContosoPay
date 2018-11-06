using Contoso.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static Contoso.Data.Abstract.IRepositories;

namespace Contoso.Data.Repositories
{
    public class SaleRepository : EntityBaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(ContosoContext context)
            : base(context)
        { }
    }
}
