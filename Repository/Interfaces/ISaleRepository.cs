using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repository.Interfaces
{
    public interface ISaleRepository : IBaseRepository
    {
        IEnumerable<Sale> Get();
        Sale GetById(int id);
    }
}