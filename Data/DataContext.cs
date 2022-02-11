using Microsoft.EntityFrameworkCore;
using ProdamTest.Models;

namespace ProdamTest.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Provider> Providers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
