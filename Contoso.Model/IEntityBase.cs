using System;

namespace Contoso.Model
{
    public interface IEntityBase
    {
        int Id { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
        bool IsActive{ get; set; }
        bool IsDeleted { get; set; }
    }
}
