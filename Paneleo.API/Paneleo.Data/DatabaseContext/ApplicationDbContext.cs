using Microsoft.EntityFrameworkCore;
using Paneleo.Models;
using Paneleo.Models.Model;
using Paneleo.Models.Model.Contractor;
using Paneleo.Models.Model.Order;
using Paneleo.Models.Model.Product;

namespace Paneleo.Data.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}