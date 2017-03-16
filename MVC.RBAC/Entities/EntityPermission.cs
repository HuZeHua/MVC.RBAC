using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.RBAC.Entities
{
    public class EntityPermission
    {
        public int EntityID { get; set; }

        public string EntityName { get; set; }

        public int RoleID { get; set; }

        public virtual Role Role { get; set; }
    }
}