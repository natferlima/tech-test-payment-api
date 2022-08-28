using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Data;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repository.Interfaces;

namespace tech_test_payment_api.Repository
{
    public class SaleRepository : BaseRepository, ISaleRepository
    {
        private readonly PaymentAPIContext _context;
        public SaleRepository(PaymentAPIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sale>> Get()
        {
            var sales = await _context.Sales.Include( x => x.Items).ToListAsync();
            return sales;
        }

        public async Task<Sale> GetById(int id)
        {
            var sale = await _context.Sales
                                .Include( x => x.Items)
                                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return sale;
        }
    }
}