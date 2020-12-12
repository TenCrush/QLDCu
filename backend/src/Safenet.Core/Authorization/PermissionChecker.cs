using Abp.Authorization;
using Safenet.Authorization.Roles;
using Safenet.Authorization.Users;

namespace Safenet.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
