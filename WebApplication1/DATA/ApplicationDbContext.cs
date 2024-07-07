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
    }
}
