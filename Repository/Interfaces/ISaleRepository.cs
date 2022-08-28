using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repository.Interfaces
{
    public interface ISaleRepository : IBaseRepository
    {
        Task<IEnumerable<Sale>> Get();
        Task<Sale> GetById(int id);
    }
}