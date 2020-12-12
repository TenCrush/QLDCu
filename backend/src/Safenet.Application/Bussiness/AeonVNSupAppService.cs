using Abp.Application.Services;
using Abp.Domain.Repositories;
using Safenet.Bussiness.DepositHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safenet.Bussiness
{
    public class AeonVNSupAppService : SafenetAppServiceBase
    {
        public readonly IRepository<AeonVNSup, long> _aeonVNSupRepository;
        public AeonVNSupAppService(IRepository<AeonVNSup, long> aeonVNSupsRepository)
        {
            _aeonVNSupRepository = aeonVNSupsRepository;
        }
        public async Task<List<AeonVNSup>> GetAll()
        {
            return await Task.FromResult(_aeonVNSupRepository.GetAll().ToList());
        }
        public async Task<AeonVNSup> InsertOnSubmit(AeonVNSup dto)
        {
            var res = await _aeonVNSupRepository.InsertAsync(dto);
            return res;
        }

        public async Task DeleteOnSubmit(AeonVNSup dto)
        {
            await _aeonVNSupRepository.DeleteAsync(dto);
        }
    }
}
