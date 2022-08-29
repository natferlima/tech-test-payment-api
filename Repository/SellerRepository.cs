using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Data;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repository.Interfaces;

namespace tech_test_payment_api.Repository
{
    public class SellerRepository : BaseRepository, ISellerRepository
    {
        private readonly PaymentAPIContext _context;
        public SellerRepository(PaymentAPIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seller>> Get()
        {
            var sellers = await _context.Sellers!.ToListAsync();
            return sellers;
        }

        public async Task<Seller> GetById(int id)
        {
            var seller = await _context.Sellers!
                                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return seller!;
        }
    }
}