using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Safenet.Authorization.Roles;
using Safenet.Authorization.Users;
using Safenet.MultiTenancy;
using Safenet.Bussiness.DepositHistory;
using Safenet.Bussiness.DanCu;

namespace Safenet.EntityFrameworkCore
{
    public class SafenetDbContext : AbpZeroDbContext<Tenant, Role, User, SafenetDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public SafenetDbContext(DbContextOptions<SafenetDbContext> options)
            : base(options)
        {
        }
        public DbSet<AeonMallCustomer> AeonMallCustomer { get; set; }
        public DbSet<AeonVNCustomer> AeonVNCustomer { get; set; }
        public DbSet<AeonVNSup> AeonVNSup { get; set; }
        public DbSet<AVBarcode> AVBarcode { get; set; }
        public DbSet<DepositHistories> DepositHistories { get; set; }
        public DbSet<ProcessedFiles> ProcessedFiles { get; set; }
        public DbSet<DanCu> DanCus { get; set; }

    }
}
