namespace tech_test_payment_api.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SellerId { get; set; }
        public List<Product>? Items { get; set; }
    }
}