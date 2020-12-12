using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Safenet.Authorization
{
    public class SafenetAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            var bussiness = context.CreatePermission(PermissionNames.Bussiness, L("Bussiness"));

            var depositHistory = bussiness.CreateChildPermission(PermissionNames.DepositHistorie_Permission, L("DepositHistorie_Permission"));
            depositHistory.CreateChildPermission(PermissionNames.DepositHistorie_Permission_Create, L("DepositHistorie_Permission_Create"));
            depositHistory.CreateChildPermission(PermissionNames.DepositHistorie_Permission_Edit, L("DepositHistorie_Permission_Edit"));
            depositHistory.CreateChildPermission(PermissionNames.DepositHistorie_Permission_Delete, L("DepositHistorie_Permission_Delete"));

            //var depositHistory = bussiness.CreateChildPermission(PermissionNames.DepositHistorie_Permission, L("DepositHistorie_Permission"));
            //depositHistory.CreateChildPermission(PermissionNames.DepositHistorie_Permission_Create, L("DepositHistorie_Permission_Create"));
            //depositHistory.CreateChildPermission(PermissionNames.DepositHistorie_Permission_Edit, L("DepositHistorie_Permission_Edit"));
            //depositHistory.CreateChildPermission(PermissionNames.DepositHistorie_Permission_Delete, L("DepositHistorie_Permission_Delete"));


            var danCu = bussiness.CreateChildPermission(PermissionNames.DanCu_Permission, L("DanCu_Permission"));
            danCu.CreateChildPermission(PermissionNames.DanCu_Permission_Create, L("DanCu_Permission_Create"));
            danCu.CreateChildPermission(PermissionNames.DanCu_Permission_Edit, L("DanCu_Permission_Edit"));
            danCu.CreateChildPermission(PermissionNames.DanCu_Permission_Delete, L("DanCu_Permission_Delete"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SafenetConsts.LocalizationSourceName);
        }
    }
}
