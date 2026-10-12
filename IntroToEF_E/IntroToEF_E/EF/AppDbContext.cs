using Microsoft.EntityFrameworkCore;
using IntroToEF_E.Models;
namespace IntroToEF_E.EF
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Student { set; get; }
    }

    
}
