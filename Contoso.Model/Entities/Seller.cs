using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Model.Entities
{
    public class Seller : IEntityBase
    {
        public Seller()
        {
            SaleCreated = new List<Sale>();
            OperationCreated = new List<Operation>();
        }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public ICollection<Sale> SaleCreated { get; set; }
        public ICollection<Operation> OperationCreated { get; set; }


    }
}
