using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.DATA
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
           .HasMany(s => s.Address)
           .WithOne(a => a.Student)
           .HasForeignKey(a => a.StudentId);
            base.OnModelCreating(modelBuilder);
        }



    }
}
