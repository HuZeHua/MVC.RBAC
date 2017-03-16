using System.Data.Entity.ModelConfiguration;

namespace MVC.RBAC.Entities.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.HasKey(t => t.ID);
            this.Property(t => t.Name).HasMaxLength(20).IsRequired();

            this.HasMany(t => t.Permissions).WithMany().Map(m =>
            {
                m.ToTable("RolePermission");
                m.MapLeftKey("RoleID");
                m.MapRightKey("PermissionID");
            });
        }
    }
}