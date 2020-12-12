using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Safenet.Authorization;

namespace Safenet
{
    [DependsOn(
        typeof(SafenetCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SafenetApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SafenetAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SafenetApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
