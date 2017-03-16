using System.Data.Entity.ModelConfiguration;

namespace MVC.RBAC.Entities.Mapping
{
    public class EntityPermissionMap : EntityTypeConfiguration<EntityPermission>
    {
        public EntityPermissionMap()
        {
            this.HasKey(t => new { t.EntityID, t.EntityName, t.RoleID });
            this.Property(t => t.EntityName).HasMaxLength(20);

            this.HasRequired(t=>t.Role).WithMany().HasForeignKey(t=>t.RoleID).WillCascadeOnDelete(true);
        }
    }
}