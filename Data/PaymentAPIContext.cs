using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Data
{
    public class PaymentAPIContext : DbContext
    {
        public PaymentAPIContext(DbContextOptions<PaymentAPIContext> options) : base(options)
        {
            
        }

        public DbSet<Seller> Sellers {get; set;}
    }
}