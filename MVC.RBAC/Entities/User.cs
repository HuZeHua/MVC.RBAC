using System.Collections.Generic;

namespace MVC.RBAC.Entities
{
    public class User:BaseEntity
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public bool Actity { get; set; }

        public virtual  ICollection<Role> Roles { get; set; }=new List<Role>();
    }
}