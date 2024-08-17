using Microsoft.EntityFrameworkCore;
using ProductApiRESTful.Models;

namespace ProductApiRESTful.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Products> _products { get; set; }
    }
}
