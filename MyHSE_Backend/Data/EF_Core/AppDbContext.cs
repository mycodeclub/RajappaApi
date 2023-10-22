using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Models.User;

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

        public DbSet<AppUser> AppUsers { get; set; }

        //[NotMapped]
        //public async Task<int> CallSp(int par1, int par2)
        //{
        //    var parameter = new SqlParameter("@Parameter1", par1);
        //    return await Database.ExecuteSqlRawAsync("EXEC MyStoredProcedure @ParameterName", parameter);
        //}
    }
}
