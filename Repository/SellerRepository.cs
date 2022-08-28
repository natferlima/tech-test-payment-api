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

        public IEnumerable<Seller> Get()
        {
            var seller = _context.Sellers.ToList();
            return seller;
        }

        public Seller GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}