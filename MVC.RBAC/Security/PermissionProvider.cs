using System.Collections.Generic;
using MVC.RBAC.Entities;

namespace MVC.RBAC.Security
{
    public class PermissionProvider : IPermissionProvider
    {
        public IEnumerable<Permission> GetPermissions()
        {
            var permissions = new List<Permission>
                              {
                                  new Permission { Name = "ManagerList", Category = "后台管理", Description = "列表" }
                              };
            return permissions;
        }
    }
}