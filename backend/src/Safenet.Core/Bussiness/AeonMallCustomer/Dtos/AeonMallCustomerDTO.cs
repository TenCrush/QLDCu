using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safenet.Bussiness.DepositHistory.Dtos
{
    public class AeonMallCustomerDTO : EntityDto
    {
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
