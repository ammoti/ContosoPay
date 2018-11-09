using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Model.Entities
{
    public class Report : IEntityBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Seller Seller { get; set; }
        public int SellerId { get; set; }
        public double Discount { get; set; }
        public string OperationType { get; set; }
    }
}
