using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safenet.Bussiness.DepositHistory
{
    [Table("AVBarcode")]
    public class AVBarcode : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public int? AVCustomerID { get; set; }

        public string SalesBagBarcode { get; set; }

        public string IntermediateBagBarcode { get; set; }

    }
}
