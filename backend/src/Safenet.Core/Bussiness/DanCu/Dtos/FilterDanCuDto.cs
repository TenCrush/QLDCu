using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safenet.Bussiness.DanCu.Dtos
{
    public class FilterDanCuDto : PagedAndSortedResultRequestDto
    {
        public string filterText { get; set; }
        public int? gender { get; set; }
        public int? loaiKT { get; set; }
    }
}
