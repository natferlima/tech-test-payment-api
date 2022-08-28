using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Data;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repository.Interfaces;

namespace tech_test_payment_api.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly PaymentAPIContext _context;
        public ProductRepository(PaymentAPIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _context.Products
                                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return product;
        }
    }
}