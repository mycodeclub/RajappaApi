using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.User;
using MyHSE_Backend.Data.DbModels.Profile;

namespace MyHSE_Backend.Data.EF_Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { }
        }

        public DbSet<Users> AppUsers { get; set; }
        public DbSet<UserGroups> UserGroups { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Roles> Roles { get; set; }

        //------ Profiles Entity
        public DbSet<ProfileSettings> ProfileSettings { get; set; }
        public DbSet<Security> Security { get; set; }
        //------ Settings Entity

        public DbSet<MyHSE_Backend.Data.DbModels.Settings.BusinessModules> BusinessModules{ get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.BusinessObjects> BusinessObjects { get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.Classification> Classification { get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.Organizations> Organizations{ get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.Partners> Partners{ get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.Plants> Plants{ get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.PurchasingGroups> PurchasingGroups{ get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.PurchasingOrganizations> PurchasingOrganizations{ get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.Units> Units{ get; set; }

        //-----Docs Entity


        public DbSet<MyHSE_Backend.Data.DbModels.Docs.Documents> Documents{ get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Docs.ObjectStatus> ObjectStatus{ get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Docs.WorkflowLog> WorkflowLog{ get; set; }





    }
}
