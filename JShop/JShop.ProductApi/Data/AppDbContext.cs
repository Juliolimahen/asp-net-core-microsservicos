using JShop.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JShop.ProductApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        /// <summary>
        /// Mapear classe Category para a tabela Categories
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Mapear classe Product para a tabela Products
        /// </summary>
        public DbSet<Product> Products { get; set; }
    }
}
