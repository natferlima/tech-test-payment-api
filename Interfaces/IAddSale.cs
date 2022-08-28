using tech_test_payment_api.Models;

namespace tech_test_payment_api.Interfaces
{
    public interface IAddSale
    {
        public DateTime Date { get; set; }
        public int SellerId { get; set; }
        public List<Product>? Items { get; set; }
        public string? Status { get; set; }
    }
}