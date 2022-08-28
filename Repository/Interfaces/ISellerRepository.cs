using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repository.Interfaces
{
    public interface ISellerRepository : IBaseRepository
    {
        IEnumerable<Seller> Get();
        Seller GetById(int id);
    }
}