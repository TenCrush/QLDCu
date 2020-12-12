using Abp.Application.Services;
using Abp.Domain.Repositories;
using Safenet.Bussiness.DepositHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safenet.Bussiness
{
    public class ProcessedFilesAppService : SafenetAppServiceBase
    {
        public readonly IRepository<ProcessedFiles, long> _processedFilesRepository;
        public ProcessedFilesAppService(IRepository<ProcessedFiles, long> depositHistoriesRepository)
        {
            _processedFilesRepository = depositHistoriesRepository;
        }

        public async Task<List<ProcessedFiles>> GetAll()
        {
            return await Task.FromResult(_processedFilesRepository.GetAll().ToList());
        }

        public async Task<ProcessedFiles> InsertOnSubmit(ProcessedFiles processedFiles)
        {
            ProcessedFiles res = await _processedFilesRepository.InsertAsync(processedFiles);
            return res;
        }
    }
}
