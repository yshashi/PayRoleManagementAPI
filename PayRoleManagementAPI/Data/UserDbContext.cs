using Microsoft.EntityFrameworkCore;
using PayRoleManagementAPI.Models;

namespace PayRoleManagementAPI.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext>options):base(options)
        {

        }
        public DbSet<UserModel> UserModels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("tbl_USER");
        }
    }
}
