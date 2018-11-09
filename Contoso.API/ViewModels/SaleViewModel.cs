using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.API.ViewModels
{
    public class SaleViewModel
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string CardNo { get; set; }
        public double Price { get; set; }
        public int SellerId { get; set; }
        public SaleType SaleType { get; set; }

    }
    public enum SaleType
    {
        Sale=1,
        CardInitiate=2
    }
}
