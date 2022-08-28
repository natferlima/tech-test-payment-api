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

        public IEnumerable<Sale> Get()
        {
            var sale = _context.Sales.Include( x => x.Items).ToList();
            return sale;
        }

        public Sale GetById(int id)
        {
            var sale = _context.Sales.Include( x => x.Items).Where(x => x.Id == id).FirstOrDefault();
            return sale;
        }
    }
}