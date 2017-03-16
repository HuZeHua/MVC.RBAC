using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC.RBAC.Entities
{
    public class Role:BaseEntity
    {
        public string Name { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}