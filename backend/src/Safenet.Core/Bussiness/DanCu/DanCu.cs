using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Safenet.Bussiness.File.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Safenet.Bussiness.DanCu
{
    [Table("DanCu")]
    public class DanCu : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string HoVaTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int? NhomMau { get; set; }
        public int? GioiTinh { get; set; }
        public int? TinhTranHonNhan { get; set; }
        public string NoiDKKhaiSinh { get; set; }
        public string QueQuan { get; set; }
        public string DanToc { get; set; }
        public string TonGiao { get; set; }
        public string QuocTich { get; set; }
        public string CMND { get; set; }
        public string HoChieu { get; set; }
        public string HocVan { get; set; }
        public string ChuyenMon { get; set; }
        public string TiengDanToc { get; set; } 
        public string NgoaiNgu { get; set; }
        public string NgheNghiep { get; set; }
        public string NoiLamViec { get; set; }
        public string ThuongTru { get; set; }
        public string NoiOHienNay { get; set; }
        public int? Loai { get; set; }
        public string SDT { get; set; }
        public string HoVaTenMe { get; set; }
        public string CMNDMe { get; set; }
        public string HoVaTenBo { get; set; }
        public string CMNDBo { get; set; }
        public string HoVaTenVoChong { get; set; }
        public string CMNDVoChong { get; set; }
        public string HoVaTenChuHoKhau { get; set; }
        public string CCCDChuHo { get; set; }
        public string QuanHeVoiChuHo { get; set; }
        public string SoSoHoKhau { get; set; }
        public string HoVaTenChuSoHuuNhaDangO { get; set; }
        public string QuanHeVoiChuSoHuuNhaDangO { get; set; }
        public string SDTChuSoHuuNhaDangO { get; set; }
        public bool TsTa { get; set; }
        public bool DaChet{ get; set; }
        public bool DaDi { get; set; }
        public DateTime? NgayDen { get; set; }
        public string NoiDen { get; set; }
        public DateTime? NgayDi { get; set; }
        public string NoiDi { get; set; }
        public string GhiChu { get; set; }
        public string IdAvatars { get; set; }

    }
}
