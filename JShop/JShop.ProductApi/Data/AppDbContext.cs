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

        //Fluent API 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .HasMaxLength(100).
                IsRequired();

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(100).
                IsRequired();

            modelBuilder.Entity<Product>().
                Property(p => p.Description).HasMaxLength(255).
                IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(c => c.Category)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 1,
                Name = "Material Escolar",
            },
            new Category
            {
                CategoryId = 2,
                Name = "Acessórios",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Caneta",
                Price = 5,
                Description = "bic, preta",
                Stock = 30,
                ImageURL = "https://static3.tcdn.com.br/img/img_prod/586385/caneta_esferografica_media_1_0mm_preta_cristal_bic_3729_1_20190905085429.png",
                CategoryId = 1
            });
        }
    }
}
