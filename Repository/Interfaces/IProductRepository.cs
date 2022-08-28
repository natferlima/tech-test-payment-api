using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repository.Interfaces
{
    public interface IProductRepository : IBaseRepository
    {
        IEnumerable<Product> Get();
        Product GetById(int id);
    }
}