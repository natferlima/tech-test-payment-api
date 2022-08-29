using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models.DTO
{
    public class SaleDTO
    {
        public DateTime Date { get; set; }
        public SellerDTO? Seller { get; set; }
        public List<ProductDTO>? Items { get; set; }
    }
}