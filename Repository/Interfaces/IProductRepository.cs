using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repository.Interfaces
{
    public interface IProductRepository : IBaseRepository
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> GetById(int id);
    }
}