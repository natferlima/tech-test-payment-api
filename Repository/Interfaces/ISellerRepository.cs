using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repository.Interfaces
{
    public interface ISellerRepository : IBaseRepository
    {
        Task<IEnumerable<Seller>> Get();
        Task<Seller> GetById(int id);
    }
}