using MVC.RBAC.Entities;

namespace MVC.RBAC.Security
{
    public interface IPermissionService
    {
        bool Authorize(string permissionName, User user);

        bool Authorize(string permissionName);
    }
}
