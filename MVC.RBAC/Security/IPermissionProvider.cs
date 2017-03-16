using System.Collections.Generic;
using MVC.RBAC.Entities;

namespace MVC.RBAC.Security
{
    public interface IPermissionProvider
    {
        IEnumerable<Permission> GetPermissions();
    }
}
