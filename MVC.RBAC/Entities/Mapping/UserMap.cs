using System.Data.Entity.ModelConfiguration;

namespace MVC.RBAC.Entities.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(t => t.ID);
            this.Property(t => t.Name).HasMaxLength(20).IsRequired();
            this.Property(t => t.Password).HasMaxLength(128).IsRequired();

            this.HasMany(t => t.Roles).WithMany().Map(m =>
            {
                m.ToTable("UserRole");
                m.MapLeftKey("UserID");
                m.MapRightKey("RoleID");
            });
        }
    }
}