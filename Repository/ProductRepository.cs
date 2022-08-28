using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IEnumerable<Product> Get()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}