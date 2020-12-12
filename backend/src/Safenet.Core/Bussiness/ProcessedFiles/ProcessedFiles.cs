using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safenet.Bussiness.DepositHistory
{
    [Table("ProcessedFiles")]
    public class ProcessedFiles : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string FileName { get; set; }

        public string Status { get; set; }

        public string TimeTag { get; set; }

    }
}
