using Contoso.Model.Enumration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Model.Entities
{
    public class Operation : IEntityBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }


        public Seller Seller { get; set; }
        public int SellerId { get; set; }
        public int Discount { get; set; }
        public OperationType OperationType { get; set; }
    }
}
