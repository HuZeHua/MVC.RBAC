using MVC.RBAC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.RBAC.Security
{
    public interface IEnityPermissionService
    {
        bool Authorize<T>(T entity) where T : BaseEntity;
    }
}