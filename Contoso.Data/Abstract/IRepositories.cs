using Contoso.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Data.Abstract
{
    public class IRepositories
    {
        public interface IUsersRepository : IEntityBaseRepository<Users> { }

        public interface ISaleRepository : IEntityBaseRepository<Sale> { }

        public interface ISellerRepository : IEntityBaseRepository<Seller> { }

        public interface IOperationRepository : IEntityBaseRepository<Operation> { }
    }
}
