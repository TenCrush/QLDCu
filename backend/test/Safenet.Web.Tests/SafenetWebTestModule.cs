using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Safenet.EntityFrameworkCore;
using Safenet.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Safenet.Web.Tests
{
    [DependsOn(
        typeof(SafenetWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class SafenetWebTestModule : AbpModule
    {
        public SafenetWebTestModule(SafenetEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SafenetWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SafenetWebMvcModule).Assembly);
        }
    }
}