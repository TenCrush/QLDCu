using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Safenet.Controllers
{
    public abstract class SafenetControllerBase: AbpController
    {
        protected SafenetControllerBase()
        {
            LocalizationSourceName = SafenetConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
