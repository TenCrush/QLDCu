using Abp.Application.Services;
using Abp.Domain.Repositories;
using Safenet.Bussiness.DepositHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safenet.Bussiness
{
    public class AVBarcodeAppService : SafenetAppServiceBase
    {
        public readonly IRepository<AVBarcode, long> _AVBarcodeRepository;
        public AVBarcodeAppService(IRepository<AVBarcode, long> AVBarcodeRepository)
        {
            _AVBarcodeRepository = AVBarcodeRepository;
        }
        public async Task<List<AVBarcode>> GetAll()
        {
            return await Task.FromResult(_AVBarcodeRepository.GetAll().ToList());
        }

        public async Task<AVBarcode> InsertOnSubmit(AVBarcode AVBarcode)
        {
            var res = await _AVBarcodeRepository.InsertAsync(AVBarcode);
            return res;
        }
    }
}
