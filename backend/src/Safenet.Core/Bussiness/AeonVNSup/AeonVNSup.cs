using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safenet.Bussiness.DepositHistory
{
    [Table("AeonVNSup")]
    public class AeonVNSup : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string SupCode{ get; set; }

        public string SupName{ get; set; }

        public string RegisterDay{ get; set; }

        public string Note{ get; set; }

        public string Type{ get; set; }

        public string TimeTag{ get; set; }

    }
}
