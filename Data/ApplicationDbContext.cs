using Microsoft.EntityFrameworkCore;
using MVCLearning.Web.Models.Entities;

namespace MVCLearning.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}