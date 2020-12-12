using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Safenet.Bussiness
{
    //[AbpAuthorize(PermissionNames.DanCu_Permission)]
    public class DanCuAppService : ApplicationService
    {
        public readonly IRepository<DanCu.DanCu> _danCuRepository;

        public DanCuAppService(IRepository<DanCu.DanCu> danCuRepository)
        {
            _danCuRepository = danCuRepository;
        }


        public async Task<ListResultDto<DanCu.DanCu>> GetAllDanCu()
        {
            return new ListResultDto<DanCu.DanCu>(await _danCuRepository.GetAll().ToListAsync());
        }

        public async Task<DanCu.DanCu> GetForEdit([Required] int id)
        {
            return await _danCuRepository.GetAsync(id);
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
            await _danCuRepository.UpdateAsync(entity);
            return await Task.FromResult(true);
        }
    }
}
