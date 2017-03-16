using System;
using System.Linq;
using MVC.RBAC.Entities;

namespace MVC.RBAC.Security
{
    public class PermissionService : IPermissionService
    {
        private XCodeContext db = new XCodeContext();

        public bool Authorize(string permissionName)
        {
            return Authorize(permissionName, WorkContext.CurrentUser);
        }

        public bool Authorize(string permissionName, User user)
        {
            return user.Roles.Where(role => role.Active).Any(role => Authorize(permissionName, role));
        }

        protected virtual bool Authorize(string permissionName, Role role)
        {
            return role.Permissions.Any(p => p.Name.Equals(permissionName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}