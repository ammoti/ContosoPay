using Contoso.Model.Entities;
using static Contoso.Data.Abstract.IRepositories;

namespace Contoso.Data.Repositories
{
    public class SellerRepository : EntityBaseRepository<Seller>, ISellerRepository
    {
        public SellerRepository(ContosoContext context)
            : base(context)
        { }
    }
}
