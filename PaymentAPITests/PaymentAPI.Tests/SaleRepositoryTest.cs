using NSubstitute;
using tech_test_payment_api.Data;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repository;
using tech_test_payment_api.Repository.Interfaces;

namespace PaymentAPI.Tests
{
    public class SaleRepositoryTest
    {
        private readonly ISaleRepository _repositoryInterface = Substitute.For<ISaleRepository>();
        private readonly SaleRepository _repository;
        private readonly PaymentAPIContext _context;
        public SaleRepositoryTest()
        {
            _repository = new SaleRepository(_context);
        }
        // [Fact]
        public async Task GetSales_ReturnSales_WhenExistsSales()
        {
            Product newProduct = new Product {
                Id = 0,
                Name = "ProductName"
            };

            List<Product> newItems = new List<Product>()
            {
                newProduct
            };

            Seller newSeller = new Seller {
                Id = 0,
                CPF = "123.123.123-45",
                Name = "Teste",
                Email = "teste@email.com",
                PhoneNumber = "21966666666"
            };

            var newSale = new Sale {
                Id = 0,
                Date = new DateTime(),
                Seller = newSeller,
                Items = newItems,
                Status = "Aguardando pagamento"
            };

            var newList = new List<Sale> {
                newSale
            };

            _repositoryInterface.Get().Returns(newList);

            var response = await _repository.Get();

            Assert.NotEmpty(response);
        }
    }
}