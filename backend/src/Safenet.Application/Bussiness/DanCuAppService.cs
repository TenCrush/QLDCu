using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Safenet.Bussiness.DanCu;
using Safenet.Bussiness.DanCu.Dtos;
using Safenet.Bussiness.File.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace Safenet.Bussiness
{
    //[AbpAuthorize(PermissionNames.DanCu_Permission)]
    public class DanCuAppService : ApplicationService
    {
        public readonly IRepository<DanCu.DanCu> _danCuRepository;
        public readonly IRepository<File.File, long> _fileRepository;


        public DanCuAppService(IRepository<DanCu.DanCu> danCuRepository, IRepository<File.File, long> fileRepository)
        {
            _danCuRepository = danCuRepository;
            _fileRepository = fileRepository;
        }


        public async Task<PagedResultDto<DanCu.DanCu>> GetAllDanCu(FilterDanCuDto input)
        {
            var result = _danCuRepository.GetAll()
                .Where(m =>
                (string.IsNullOrEmpty(input.filterText) || m.HoVaTen.Contains(input.filterText.Trim()) || m.CMND.Contains(input.filterText.Trim())) &&
                (!input.gender.HasValue || (m.GioiTinh.HasValue && m.GioiTinh.Value == input.gender.Value)) &&
                (!input.loaiKT.HasValue || (m.Loai.HasValue && m.Loai.Value == input.loaiKT.Value))
                );

            return new PagedResultDto<DanCu.DanCu>(result.Count(),
                await result.OrderBy(input.Sorting ?? "Id ASC")
                .PageBy(input)
                .ToListAsync());
        }

        public async Task<DanCuDto> GetForEdit([Required] int id)
        {
            var dto = await _danCuRepository.GetAsync(id);
            var avatars = new List<File.File>();

            if (!string.IsNullOrEmpty(dto.IdAvatars))
            {
                try
                {
                    var dsIds = dto.IdAvatars.Split("`", StringSplitOptions.RemoveEmptyEntries).Select(Int64.Parse).ToList();
                    avatars = _fileRepository.GetAll().Where(m => dsIds.Contains(m.Id)).ToList();
                }
                catch (System.Exception)
                {

                }
            }

            return new DanCuDto()
            {
                Id = dto.Id,
                HoVaTen = dto.HoVaTen,
                NgaySinh = dto.NgaySinh,
                NhomMau = dto.NhomMau,
                GioiTinh = dto.GioiTinh,
                TinhTranHonNhan = dto.TinhTranHonNhan,
                NoiDKKhaiSinh = dto.NoiDKKhaiSinh,
                QueQuan = dto.QueQuan,
                DanToc = dto.DanToc,
                TonGiao = dto.TonGiao,
                QuocTich = dto.QuocTich,
                CMND = dto.CMND,
                HoChieu = dto.HoChieu,
                HocVan = dto.HocVan,
                ChuyenMon = dto.ChuyenMon,
                TiengDanToc = dto.TiengDanToc,
                NgoaiNgu = dto.NgoaiNgu,
                NgheNghiep = dto.NgheNghiep,
                NoiLamViec = dto.NoiLamViec,
                ThuongTru = dto.ThuongTru,
                NoiOHienNay = dto.NoiOHienNay,
                Loai = dto.Loai,
                SDT = dto.SDT,
                HoVaTenMe = dto.HoVaTenMe,
                CMNDMe = dto.CMNDMe,
                HoVaTenBo = dto.HoVaTenBo,
                CMNDBo = dto.CMNDBo,
                HoVaTenVoChong = dto.HoVaTenVoChong,
                CMNDVoChong = dto.CMNDVoChong,
                HoVaTenChuHoKhau = dto.HoVaTenChuHoKhau,
                CCCDChuHo = dto.CCCDChuHo,
                QuanHeVoiChuHo = dto.QuanHeVoiChuHo,
                SoSoHoKhau = dto.SoSoHoKhau,
                HoVaTenChuSoHuuNhaDangO = dto.HoVaTenChuSoHuuNhaDangO,
                QuanHeVoiChuSoHuuNhaDangO = dto.QuanHeVoiChuSoHuuNhaDangO,
                SDTChuSoHuuNhaDangO = dto.SDTChuSoHuuNhaDangO,
                TsTa = dto.TsTa,
                DaChet = dto.DaChet,
                DaDi = dto.DaDi,
                NgayDen = dto.NgayDen,
                NoiDen = dto.NoiDen,
                NgayDi = dto.NgayDi,
                NoiDi = dto.NoiDi,
                GhiChu = dto.GhiChu,
                IdAvatar = dto.IdAvatars,
                Avatars = avatars.Select(m => new FileDTO()
                {
                    Id = m.Id,
                    Ten = m.Ten,
                    URL = m.URL
                }).ToList()
            };
        }

        [HttpGet]
        public async Task<bool> Delete([Required] int id)
        {
            await _danCuRepository.DeleteAsync(id);
            return await Task.FromResult(true);

        }

        public async Task<bool> CreateOrEdit(DanCu.DanCu dto)
        {
            if (dto.Id == 0)
            {
                return await Create(dto);
            }
            else
            {
                return await Edit(dto);
            }
        }

        public async Task<bool> Create(DanCu.DanCu dto)
        {
            await _danCuRepository.InsertAsync(dto);
            return await Task.FromResult(true);
        }

        public async Task<bool> Edit(DanCu.DanCu dto)
        {
            var entity = await _danCuRepository.GetAsync(dto.Id);
            entity.HoVaTen = dto.HoVaTen;
            entity.NgaySinh = dto.NgaySinh;
            entity.NhomMau = dto.NhomMau;
            entity.GioiTinh = dto.GioiTinh;
            entity.HoVaTen = dto.HoVaTen;
            entity.TinhTranHonNhan = dto.TinhTranHonNhan;
            entity.NoiDKKhaiSinh = dto.NoiDKKhaiSinh;
            entity.QueQuan = dto.QueQuan;
            entity.DanToc = dto.DanToc;
            entity.TonGiao = dto.TonGiao;
            entity.QuocTich = dto.QuocTich;
            entity.CMND = dto.CMND;
            entity.HoChieu = dto.HoChieu;
            entity.HocVan = dto.HocVan;
            entity.ChuyenMon = dto.ChuyenMon;
            entity.TiengDanToc = dto.TiengDanToc;
            entity.NgoaiNgu = dto.NgoaiNgu;
            entity.NgheNghiep = dto.NgheNghiep;
            entity.NoiLamViec = dto.NoiLamViec;
            entity.ThuongTru = dto.ThuongTru;
            entity.NoiOHienNay = dto.NoiOHienNay;
            entity.Loai = dto.Loai;
            entity.SDT = dto.SDT;
            entity.HoVaTenMe = dto.HoVaTenMe;
            entity.CMNDMe = dto.CMNDMe;
            entity.HoVaTenBo = dto.HoVaTenBo;
            entity.CMNDBo = dto.CMNDBo;
            entity.HoVaTenVoChong = dto.HoVaTenVoChong;
            entity.CMNDVoChong = dto.CMNDVoChong;
            entity.HoVaTenChuHoKhau = dto.HoVaTenChuHoKhau;
            entity.CCCDChuHo = dto.CCCDChuHo;
            entity.QuanHeVoiChuHo = dto.QuanHeVoiChuHo;
            entity.SoSoHoKhau = dto.SoSoHoKhau;
            entity.HoVaTenChuSoHuuNhaDangO = dto.HoVaTenChuSoHuuNhaDangO;
            entity.QuanHeVoiChuSoHuuNhaDangO = dto.QuanHeVoiChuSoHuuNhaDangO;
            entity.SDTChuSoHuuNhaDangO = dto.SDTChuSoHuuNhaDangO;
            entity.TsTa = dto.TsTa;
            entity.DaChet = dto.DaChet;
            entity.DaDi = dto.DaDi;
            entity.NgayDen = dto.NgayDen;
            entity.NoiDen = dto.NoiDen;
            entity.NgayDi = dto.NgayDi;
            entity.NoiDi = dto.NoiDi;
            entity.GhiChu = dto.GhiChu;
            entity.IdAvatars = dto.IdAvatars;
            await _danCuRepository.UpdateAsync(entity);
            return await Task.FromResult(true);
        }
    }
}
