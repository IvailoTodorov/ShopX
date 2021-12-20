namespace ShopXWeb.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ShopXWeb.Data.Models;

    public class ShopXDbContext : IdentityDbContext
    {
        public ShopXDbContext(DbContextOptions<ShopXDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; init; }

        public DbSet<Category> Categories { get; init; }

        public DbSet<CurrencyType> CurrencyTypes { get; init; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Post>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
