
using demoWebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace demoWebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; } = null!;
    }
}
