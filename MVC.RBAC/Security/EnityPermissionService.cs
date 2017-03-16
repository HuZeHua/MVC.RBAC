using MVC.RBAC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.RBAC.Security
{
    public class EnityPermissionService : IEnityPermissionService
    {
        private XCodeContext db = new XCodeContext();
        public bool Authorize<T>(T entity) where T : BaseEntity
        {
            var roleIds = WorkContext.CurrentUser.Roles.Select(r => r.ID);
            return db.EntityPermissions.Any(ep => ep.EntityName == typeof(T).Name && ep.EntityID == entity.ID && roleIds.Contains(ep.RoleID));
        }
    }
}