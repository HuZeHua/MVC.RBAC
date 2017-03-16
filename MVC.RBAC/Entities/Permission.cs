namespace MVC.RBAC.Entities
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }
    }
}