using Microsoft.EntityFrameworkCore;
using Paneleo.Models;
using Paneleo.Models.Model;

namespace Paneleo.Data.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Contractor> Contractors { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}