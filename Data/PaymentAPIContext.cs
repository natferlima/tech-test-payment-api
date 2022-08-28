using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Data
{
    public class PaymentAPIContext : DbContext
    {
        public PaymentAPIContext(DbContextOptions<PaymentAPIContext> options) : base(options)
        { 
        }

        public DbSet<Seller>? Sellers {get; set;}
        public DbSet<Sale>? Sales {get; set;}

        public DbSet<Product>? Products {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasOne<Seller>()
                .WithMany()
                .HasForeignKey(p => p.SellerId)
                .HasPrincipalKey(p => p.Id);

        }
    }
}