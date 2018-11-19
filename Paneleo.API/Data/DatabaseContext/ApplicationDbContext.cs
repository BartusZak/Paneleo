using Microsoft.EntityFrameworkCore;
using Paneleo.API.Models;
using Paneleo.API.Models.Model;

namespace Paneleo.API.Repository.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}