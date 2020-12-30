using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safenet.Bussiness.File
{
    [Table("File")]

    public class File : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public virtual string Ten { get; set; }
        public virtual string Loai { get; set; }
        public virtual string URL { get; set; }
        public virtual long Size { get; set; }
    }
}
