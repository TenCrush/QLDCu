using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safenet.Bussiness.DepositHistory
{
    [Table("DepositHistories")]
    public class DepositHistories : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string Device { get; set; }

        public string DepositDate { get; set; }

        public string SaleDate { get; set; }

        public string CustomerID { get; set; }

        public string BarcodeID { get; set; }

        public string DeclaredAmount { get; set; }

        public string ActualAmount { get; set; }

        public string CounterfeitAmount { get; set; }

        public string DiscrepancyAmount { get; set; }

        public string Quantity { get; set; }

        public string LastEdit { get; set; }

        public string TimeTag { get; set; }

        public string CountingPeople { get; set; }

        public string Checked { get; set; }

    }
}
