using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.User;
using MyHSE_Backend.Data.DbModels.Profile;
using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.DbModels.WorkFlow;

namespace MyHSE_Backend.Data.EF_Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
             
//            modelBuilder.Entity<Users>().HasIndex(u => u.Login).IsUnique();
            modelBuilder.Entity<UserGroups>().HasIndex(u => u.USGRP).IsUnique();
            modelBuilder.Entity<Roles>().HasIndex(u => u.Role).IsUnique();
            modelBuilder.Entity<RolePermission>().HasIndex(u => u.ROLEID).IsUnique();

           // modelBuilder.Entity<RolePermission>().HasIndex(u => u.ROLE).IsUnique();

            modelBuilder.Entity<RolePermission>().HasIndex(u => u.BUSMTYPE).IsUnique();

            modelBuilder.Entity<RolePermission>().HasIndex(u => u.BUSOBJTYPE).IsUnique();

            modelBuilder.Entity<RolePermission>().HasIndex(u => u.BUSFTYPE).IsUnique();



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

        public DbSet<MyHSE_Backend.Data.DbModels.Settings.BusinessModules> BusinessModules { get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.BusinessObjects> BusinessObjects { get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.Classification> Classification { get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.Organizations> Organizations { get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.Partners> Partners { get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.Plants> Plants { get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.PurchasingGroups> PurchasingGroups { get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.PurchasingOrganizations> PurchasingOrganizations { get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Settings.Units> Units { get; set; }

        //-----Docs Entity


        public DbSet<MyHSE_Backend.Data.DbModels.Docs.Documents> Documents { get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Docs.ObjectStatus> ObjectStatus { get; set; }
        public DbSet<MyHSE_Backend.Data.DbModels.Docs.WorkflowLog> WorkflowLog { get; set; }


        public DbSet<Incident> Incidents { get; set; }

        public DbSet<IncidentCategory> IncidentCategories { get; set; }

        public DbSet<IncidentClassification> IncidentClassifications { get; set; }

        public DbSet<Victim> Victims { get; set; }

        public DbSet<VictimCategory> VictimCategories { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<WFGeneral> WFGenerals { get; set; }

        public DbSet<WFApprover> WFApprovers { get; set; }

        public DbSet<WFApprX> WFApprXs { get; set; }

        public DbSet<WFContent> WFContents { get; set; }


    }
}
