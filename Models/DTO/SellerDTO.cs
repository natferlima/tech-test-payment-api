using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models.DTO
{
    public class SellerDTO
    {
        public string? CPF { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}