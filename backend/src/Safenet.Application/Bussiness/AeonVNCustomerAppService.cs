using Abp.Application.Services;
using Abp.Domain.Repositories;
using Safenet.Bussiness.DepositHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safenet.Bussiness
{
    public class AeonVNCustomerAppService : SafenetAppServiceBase
    {
        public readonly IRepository<AeonVNCustomer, long> _aeonVNCustomerRepository;
        public AeonVNCustomerAppService(IRepository<AeonVNCustomer, long> aeonVNCustomerRepository)
        {
            _aeonVNCustomerRepository = aeonVNCustomerRepository;
        }
        public async Task<List<AeonVNCustomer>> GetAll()
        {
            return await Task.FromResult(_aeonVNCustomerRepository.GetAll().ToList());
        }

        public async Task<AeonVNCustomer> InsertOnSubmit(AeonVNCustomer dto)
        {
            var res = await _aeonVNCustomerRepository.InsertAsync(dto);
            return res;
        }

        public async Task DeleteOnSubmit(AeonVNCustomer dto)
        {
            await _aeonVNCustomerRepository.DeleteAsync(dto);
        }
    }
}
