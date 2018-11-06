using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.API.ViewModels
{
    public class SellerViewModel
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
    }
}
