using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safenet.Bussiness.DepositHistory
{
    public class AeonVNCustomerDTO
    {
        public string Floor { get; set; }

        public string PosLocation { get; set; }

        public string PosNumber { get; set; }

        public string PosName { get; set; }

        public string SalesBagPOS { get; set; }

        public string SaleBagBarcode { get; set; }

        public string IntermediateBagPOS { get; set; }

        public string IntermediateBagBarcode { get; set; }

        public string Type { get; set; }

        public string TimeTag { get; set; }

    }
}
