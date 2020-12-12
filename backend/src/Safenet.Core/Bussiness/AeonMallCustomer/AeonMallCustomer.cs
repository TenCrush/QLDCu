using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safenet.Bussiness.DepositHistory
{
    [Table("AeonMallCustomer")]
    public class AeonMallCustomer : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string Cards { get; set; }

        public string TenantCode { get; set; }

        public string TenantName { get; set; }

        public string TenantShortName { get; set; }

        public string OpenningDate { get; set; }

        public string Note { get; set; }

        public string Type { get; set; }

        public string TimeTag { get; set; }

    }
}
