using Contoso.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static Contoso.Data.Abstract.IRepositories;

namespace Contoso.Data.Repositories
{
   public class ReportRepository : EntityBaseRepository<Report>, IReportRepository
    {
        public ReportRepository(ContosoContext context)
              : base(context)
        { }
    }
}
