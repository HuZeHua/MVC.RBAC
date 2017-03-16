using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace MVC.RBAC.Entities
{
    public class XCodeContext:DbContext
    {
        static XCodeContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<XCodeContext>());
        }

        public XCodeContext() : base("XCodeConnection")
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<EntityPermission> EntityPermissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}