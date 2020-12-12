using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Safenet.Bussiness.DepositHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safenet.Bussiness
{
    public class DepositHistoriesAppService : SafenetAppServiceBase
    {
        public readonly IRepository<DepositHistories, long> _depositHistoriesRepository;
        public DepositHistoriesAppService(IRepository<DepositHistories, long> depositHistoriesRepository)
        {
            _depositHistoriesRepository = depositHistoriesRepository;
        }
        [AbpAuthorize]
        public async Task<List<DepositHistories>> GetAll()
        {
            //int? tenantID = CurrentUnitOfWork.GetTenantId();
            //CurrentUnitOfWork.SetTenantId(2);
            return await Task.FromResult(_depositHistoriesRepository.GetAll().ToList());
        }

        public async Task<DepositHistories> InsertOnSubmit(DepositHistories depositHistories)
        {
            DepositHistories res = await _depositHistoriesRepository.InsertAsync(depositHistories);
            return res;
        }
        public async Task<DepositHistories> PostUpdate(DepositHistories depositHistories)
        {
            DepositHistories res = await _depositHistoriesRepository.UpdateAsync(depositHistories);
            return res;
        }
    }
}
