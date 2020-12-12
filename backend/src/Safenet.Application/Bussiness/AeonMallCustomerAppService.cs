using Abp.Application.Services;
using Abp.Domain.Repositories;
using Safenet.Bussiness.DepositHistory;
using Safenet.Bussiness.DepositHistory.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safenet.Bussiness
{
    public class AeonMallCustomerAppService : SafenetAppServiceBase
    {
        public readonly IRepository<AeonMallCustomer, long> _aeonMallCustomerRepository;
        public AeonMallCustomerAppService(IRepository<AeonMallCustomer, long> aeonMallCustomerRepository)
        {
            _aeonMallCustomerRepository = aeonMallCustomerRepository;
        }
        public async Task<List<AeonMallCustomer>> GetAll()
        {
            return await Task.FromResult(_aeonMallCustomerRepository.GetAll().ToList());
        }
        public async Task<AeonMallCustomer> InsertOnSubmit(AeonMallCustomer dto)
        {
            var res = await _aeonMallCustomerRepository.InsertAsync(dto);
            return res;
        }
        public async Task DeleteOnSubmit(AeonMallCustomer dto)
        {
            await _aeonMallCustomerRepository.DeleteAsync(dto);
        }
    }
}
