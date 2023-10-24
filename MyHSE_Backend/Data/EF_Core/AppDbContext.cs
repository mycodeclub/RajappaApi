using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.User;

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
       


    }
}
